using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;

//附加音效播放器組件
[RequireComponent(typeof(AudioSource))]

public class Officewoman : MonoBehaviour
{
    
    [SerializeField]
    ESMessageSystem msgSys;
    
    private Transform playerTransform;

    
    private int progress = 0;
   
    
    private bool isSign = false; 

    void Start()
    {
       
        // Define your customized keyword functions.
        msgSys.AddSpecialCharToFuncMap("UsageCase", CustomizedFunction);

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
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
                    msgSys.ReadTextFromResource("officewoman");
                    
                    break;
                case 1:
                    //msgSys.SetDisplayVariable("MyName", myName);
                    msgSys.ReadTextFromResource("officewoman2");
                    
                   
                    break;
                case 2:                                                                    
                                msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                msgSys.SetupButtonItem("DefaultButtonItemPrefab","了解",()=>{   
                                    msgSys.Resume();
                                    msgSys.RemoveButtonUI();
                                    msgSys.ReadTextFromResource("Hide");
                                                                                                                          
                                });
        
                                msgSys.SetupButtonItem("DefaultButtonItemPrefab","為何小明上個月缺席5天",()=>{
                                    msgSys.Resume();
                                    msgSys.RemoveButtonUI();
                                    msgSys.ReadTextFromResource("officewoman3");
                                    msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                    msgSys.SetupButtonItem("DefaultButtonItemPrefab","我明天親自問他看看",()=>{ 
                                        msgSys.Resume();
                                        msgSys.RemoveButtonUI();
                                        msgSys.ReadTextFromResource("officewoman4");
                                                                                                                          
                                    });
                                    msgSys.SetupButtonItem("DefaultButtonItemPrefab","跟小明說明天別來了",()=>{ 
                                        msgSys.Resume();
                                        msgSys.RemoveButtonUI();
                                        msgSys.ReadTextFromResource("officewoman4");
                                                                                                                          
                                    });


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
