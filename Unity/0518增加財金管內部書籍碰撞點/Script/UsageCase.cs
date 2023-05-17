using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;

//附加音效播放器組件
[RequireComponent(typeof(AudioSource))]

public class UsageCase : MonoBehaviour
{
    
    [SerializeField]
    ESMessageSystem msgSys;
    
    public AudioClip openAudio;//開啟音效
    AudioSource source;
    public Transform backDoor;
    public Transform backDoor2;
    public Transform backDoor3;
    private Transform playerTransform;

    private string myName;
    private int progress = 0;
   
    
    private bool isSign = false; 

    void Start()
    {
        myName = "Rempty (｢･ω･)｢";
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
        if(msgSys.isCompleted && isSign  ){
            switch(progress){
                case 0:
                    msgSys.Resume();
                    msgSys.ReadTextFromResource("Yao1");
                    
                    break;
                case 1:
                    msgSys.SetDisplayVariable("MyName", myName);
                    msgSys.ReadTextFromResource("Yao2");
                    
                   
                    break;
                case 2:
                    msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                    msgSys.SetupButtonItem("DefaultButtonItemPrefab","好啊",()=>
                    {         
                        msgSys.Resume();
                        msgSys.RemoveButtonUI();
                        /////////////////////////////////////////////////////////////////////////////////
                        msgSys.ReadTextFromResource("Financialyes");

                               msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                               msgSys.SetupButtonItem("DefaultButtonItemPrefab","有曾經想過",()=>{                            
                               msgSys.Resume();
                               msgSys.RemoveButtonUI();
                               msgSys.ReadTextFromResource("創業yes");

                                     msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                     msgSys.SetupButtonItem("DefaultButtonItemPrefab","有開始規劃了",()=>{                            
                                     msgSys.Resume();
                                     msgSys.RemoveButtonUI();
                                     msgSys.ReadTextFromResource("創業規劃yes");

                                            msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                            msgSys.SetupButtonItem("DefaultButtonItemPrefab","閱讀過且有需要尋找更多書籍",()=>{                            
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            msgSys.ReadTextFromResource("創業需要更多");
                                                   msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                                   msgSys.SetupButtonItem("DefaultButtonItemPrefab","是",()=>{                            
                                                   msgSys.Resume();
                                                   msgSys.RemoveButtonUI();
                                                   playerTransform.position = backDoor.position;
                                                   source.PlayOneShot(openAudio);                                                                                        
                                                   });
                    
                                                   msgSys.SetupButtonItem("DefaultButtonItemPrefab","否",()=>{
                                                   msgSys.Resume();
                                                   msgSys.RemoveButtonUI();
                                                   msgSys.ReadTextFromResource("不前往");
                                                   });
                                             

                                            });
                    
                                            msgSys.SetupButtonItem("DefaultButtonItemPrefab","只閱讀過幾本",()=>{
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            msgSys.ReadTextFromResource("創業讀過幾本");
                                                   msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                                   msgSys.SetupButtonItem("DefaultButtonItemPrefab","是",()=>{                            
                                                   msgSys.Resume();
                                                   msgSys.RemoveButtonUI();
                                                   playerTransform.position = backDoor.position;
                                                   source.PlayOneShot(openAudio);                                                                                        
                                                   });
                    
                                                   msgSys.SetupButtonItem("DefaultButtonItemPrefab","否",()=>{
                                                   msgSys.Resume();
                                                   msgSys.RemoveButtonUI();
                                                   msgSys.ReadTextFromResource("不前往");
                                                   });
                                            });

                                     });
                    
                                     msgSys.SetupButtonItem("DefaultButtonItemPrefab","沒有規劃過，只是想過而已",()=>{
                                     msgSys.Resume();
                                     msgSys.RemoveButtonUI();
                                     msgSys.ReadTextFromResource("創業規劃no");
                                        
                                            msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                            msgSys.SetupButtonItem("DefaultButtonItemPrefab","是",()=>{                            
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            playerTransform.position = backDoor.position;
                                            source.PlayOneShot(openAudio);

                                            
                                             

                                            });
                    
                                            msgSys.SetupButtonItem("DefaultButtonItemPrefab","否",()=>{
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            msgSys.ReadTextFromResource("不前往");
                                            });
                                     });
                               });/////




                               
                               ////////////////////////////////////////////////////////////////////////////////////////
                               msgSys.SetupButtonItem("DefaultButtonItemPrefab","沒有過",()=>{
                               msgSys.Resume();
                               msgSys.RemoveButtonUI();
                               ////////////////////////////////////////////////////////////////////////////////////////
                               msgSys.ReadTextFromResource("創業no");
                                           msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                           msgSys.SetupButtonItem("DefaultButtonItemPrefab","有曾經想過",()=>{                            
                                           msgSys.Resume();
                                           msgSys.RemoveButtonUI();
                                           msgSys.ReadTextFromResource("投資yes");

                                           msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                           msgSys.SetupButtonItem("DefaultButtonItemPrefab","有試過投資",()=>{                            
                                           msgSys.Resume();
                                           msgSys.RemoveButtonUI();
                                           msgSys.ReadTextFromResource("投資規劃yes");

                                            msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                            msgSys.SetupButtonItem("DefaultButtonItemPrefab","閱讀過且有需要尋找更多書籍",()=>{                            
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            msgSys.ReadTextFromResource("投資需要更多");
                                                   msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                                   msgSys.SetupButtonItem("DefaultButtonItemPrefab","是",()=>{                            
                                                   msgSys.Resume();
                                                   msgSys.RemoveButtonUI();
                                                   playerTransform.position = backDoor2.position;
                                                   source.PlayOneShot(openAudio);                                                                                        
                                                   });
                    
                                                   msgSys.SetupButtonItem("DefaultButtonItemPrefab","否",()=>{
                                                   msgSys.Resume();
                                                   msgSys.RemoveButtonUI();
                                                   msgSys.ReadTextFromResource("不前往");
                                                   });
                                             

                                            });
                    
                                            msgSys.SetupButtonItem("DefaultButtonItemPrefab","只閱讀過幾本",()=>{
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            msgSys.ReadTextFromResource("投資讀過幾本");
                                                   msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                                   msgSys.SetupButtonItem("DefaultButtonItemPrefab","是",()=>{                            
                                                   msgSys.Resume();
                                                   msgSys.RemoveButtonUI();
                                                   playerTransform.position = backDoor2.position;
                                                   source.PlayOneShot(openAudio);                                                                                        
                                                   });
                    
                                                   msgSys.SetupButtonItem("DefaultButtonItemPrefab","否",()=>{
                                                   msgSys.Resume();
                                                   msgSys.RemoveButtonUI();
                                                   msgSys.ReadTextFromResource("不前往");
                                                   });
                                            });

                                     });

                    
                                     msgSys.SetupButtonItem("DefaultButtonItemPrefab","沒有投資過，以後有機會在試",()=>{
                                     msgSys.Resume();
                                     msgSys.RemoveButtonUI();
                                     msgSys.ReadTextFromResource("投資規劃no");
                                        
                                            msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                            msgSys.SetupButtonItem("DefaultButtonItemPrefab","是",()=>{                            
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            playerTransform.position = backDoor2.position;
                                            source.PlayOneShot(openAudio);

                                            
                                             

                                            });
                    
                                            msgSys.SetupButtonItem("DefaultButtonItemPrefab","否",()=>{
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            msgSys.ReadTextFromResource("不前往");
                                            });
                                             });
                                            });/////////
                                           msgSys.SetupButtonItem("DefaultButtonItemPrefab","沒有過",()=>{
                                           msgSys.Resume();
                                           msgSys.RemoveButtonUI();
                               ////////////////////////////////////////////////////////////////////////////////////////
                                           msgSys.ReadTextFromResource("投資no");
                                           msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                           msgSys.SetupButtonItem("DefaultButtonItemPrefab","有曾經想過",()=>{                            
                                           msgSys.Resume();
                                           msgSys.RemoveButtonUI();
                                           msgSys.ReadTextFromResource("國際yes");

                                           msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                           msgSys.SetupButtonItem("DefaultButtonItemPrefab","有試著了解國際情勢",()=>{                            
                                           msgSys.Resume();
                                           msgSys.RemoveButtonUI();
                                           msgSys.ReadTextFromResource("國際規劃yes");

                                            msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                            msgSys.SetupButtonItem("DefaultButtonItemPrefab","閱讀過且有需要尋找更多書籍",()=>{                            
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            msgSys.ReadTextFromResource("國際需要更多");
                                                   msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                                   msgSys.SetupButtonItem("DefaultButtonItemPrefab","是",()=>{                            
                                                   msgSys.Resume();
                                                   msgSys.RemoveButtonUI();
                                                   playerTransform.position = backDoor3.position;
                                                   source.PlayOneShot(openAudio);                                                                                        
                                                   });
                    
                                                   msgSys.SetupButtonItem("DefaultButtonItemPrefab","否",()=>{
                                                   msgSys.Resume();
                                                   msgSys.RemoveButtonUI();
                                                   msgSys.ReadTextFromResource("不前往");
                                                   });
                                             

                                            });
                    
                                            msgSys.SetupButtonItem("DefaultButtonItemPrefab","只閱讀過幾本",()=>{
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            msgSys.ReadTextFromResource("國際讀過幾本");
                                                   msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                                   msgSys.SetupButtonItem("DefaultButtonItemPrefab","是",()=>{                            
                                                   msgSys.Resume();
                                                   msgSys.RemoveButtonUI();
                                                   playerTransform.position = backDoor3.position;
                                                   source.PlayOneShot(openAudio);                                                                                        
                                                   });
                    
                                                   msgSys.SetupButtonItem("DefaultButtonItemPrefab","否",()=>{
                                                   msgSys.Resume();
                                                   msgSys.RemoveButtonUI();
                                                   msgSys.ReadTextFromResource("不前往");
                                                   });
                                            });

                                     });

                    
                                     msgSys.SetupButtonItem("DefaultButtonItemPrefab","還沒試著了解，不知道該從何處下手",()=>{
                                     msgSys.Resume();
                                     msgSys.RemoveButtonUI();
                                     msgSys.ReadTextFromResource("國際規劃no");
                                        
                                            msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                            msgSys.SetupButtonItem("DefaultButtonItemPrefab","是",()=>{                            
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            playerTransform.position = backDoor3.position;
                                            source.PlayOneShot(openAudio);

                                            
                                             

                                            });
                    
                                            msgSys.SetupButtonItem("DefaultButtonItemPrefab","否",()=>{
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            msgSys.ReadTextFromResource("不前往");
                                            });
                                             });
                                            });/////////
                                            msgSys.SetupButtonItem("DefaultButtonItemPrefab","沒有過",()=>{
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                              msgSys.ReadTextFromResource("國際no");
                                                   msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                                   msgSys.SetupButtonItem("DefaultButtonItemPrefab","是",()=>{                            
                                                   msgSys.Resume();
                                                   msgSys.RemoveButtonUI();
                                                   playerTransform.position = backDoor.position;
                                                   source.PlayOneShot(openAudio);                                                                                        
                                                   });
                    
                                                   msgSys.SetupButtonItem("DefaultButtonItemPrefab","否",()=>{
                                                   msgSys.Resume();
                                                   msgSys.RemoveButtonUI();
                                                   msgSys.ReadTextFromResource("不前往");
                                                   });
                                            });
                                           //////////////////////////
                                           
                                            

                                            
                                            


                               
                               
                               }); 

                                            
                                            


                               
                               
                               }); 
                    });









                    
                    msgSys.SetupButtonItem("DefaultButtonItemPrefab","我想直接參觀園區",()=>{
                            msgSys.Resume();
                            msgSys.RemoveButtonUI();
                            msgSys.ReadTextFromResource("Financialno");
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
