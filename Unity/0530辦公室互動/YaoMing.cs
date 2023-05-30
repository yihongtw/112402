using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;

//附加音效播放器組件
[RequireComponent(typeof(AudioSource))]

public class YaoMing : MonoBehaviour
{
    
    [SerializeField]
    ESMessageSystem msgSys;
    
    private Transform playerTransform;
    private Transform playerTransform1;
    public Transform backDoor;

    public AudioClip openAudio;//開啟音效
    AudioSource source;


    
    private int progress = 0;
   
    
    private bool isSign = false; 

    void Start()
    {
       
        // Define your customized keyword functions.
        msgSys.AddSpecialCharToFuncMap("UsageCase", CustomizedFunction);

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerTransform1 = GameObject.FindGameObjectWithTag("woman").GetComponent<Transform>();
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
                    msgSys.ReadTextFromResource("sit");
                    
                    break;
                case 1:
                                
                                msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                msgSys.SetupButtonItem("DefaultButtonItemPrefab","你是小明嗎?",()=>{
                                    msgSys.Resume();
                                    msgSys.RemoveButtonUI();
                                    msgSys.ReadTextFromResource("sit2");
                                    msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                    msgSys.SetupButtonItem("DefaultButtonItemPrefab","你被開除了!",()=>{ 
                                        msgSys.Resume();
                                        msgSys.RemoveButtonUI();
                                        msgSys.ReadTextFromResource("sit3");
                                        msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                        msgSys.SetupButtonItem("DefaultButtonItemPrefab","將小明踢出辦公室",()=>{ 
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            playerTransform1.position = backDoor.position;
                                            source.PlayOneShot(openAudio);
                                        });


                                                                                                                          
                                    });                                
                                });      
               
                    
                   
                    break;
                case 2:                                                                    
                                                                      

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
