using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;

//附加音效播放器組件
[RequireComponent(typeof(AudioSource))]

public class Computer : MonoBehaviour
{
    
    [SerializeField]
    ESMessageSystem msgSys;
    
    public AudioClip openAudio;//開啟音效
    AudioSource source;
    public Transform backDoor;
    
    private Transform playerTransform;

    
    private int progress = 0;
   
    
    private bool isSign = false; 

    void Start()
    {
       
        // Define your customized keyword functions.
        msgSys.AddSpecialCharToFuncMap("UsageCase", CustomizedFunction);

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        source = GetComponent<AudioSource>();
    }
    private void CustomizedFunction()
    {
        Debug.Log("Hi! This is called by CustomizedFunction!");
    }

    void Update()
    {
        // ----- Integration DEMO -----
        // Your own logic control.
        if(msgSys.isCompleted && isSign){
            switch(progress){
                case 0:
                    msgSys.Resume();
                    msgSys.ReadTextFromResource("computer1");
                    
                    break;
                case 1:
                    //msgSys.SetDisplayVariable("MyName", myName);
                    msgSys.ReadTextFromResource("computer2");
                    
                   
                    break;
                case 2:                                                                    
                                msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                msgSys.SetupButtonItem("DefaultButtonItemPrefab","好呀",()=>{   
                                    msgSys.Resume();
                                    msgSys.RemoveButtonUI();
                                    playerTransform.position = backDoor.position;
                                    source.PlayOneShot(openAudio);                                                                                        
                                });
        
                                msgSys.SetupButtonItem("DefaultButtonItemPrefab","我想先參觀創業樓層",()=>{
                                    msgSys.Resume();
                                    msgSys.RemoveButtonUI();
                                    msgSys.ReadTextFromResource("computer3");
                                });                                            

                            break;
            }
            progress ++ ;    
        }

        

        if(!isSign)
        {
            msgSys.ReadTextFromResource("Hide");  

            
            progress = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Continue the messages, stoping by [w] or [lr] keywords.
            msgSys.Next();
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") 
        && other.GetType().ToString() == "UnityEngine.CapsuleCollider")
        {
            isSign = true;
            Debug.Log("ya");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player") 
        && other.GetType().ToString() == "UnityEngine.CapsuleCollider")
        {
            isSign = false;
            Debug.Log("no");
        }
    }
}
