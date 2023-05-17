using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;

public class UsageCase : MonoBehaviour
{
    [SerializeField]
    ESMessageSystem msgSys;
    
    private string myName;
    private int progress = 0;
    private bool pickedUpTheKey = false;
    private bool isGameEnd = false;
    private bool isLocked = false;
    
    private bool isSign = false; 
    void Start()
    {
        myName = "Rempty (｢･ω･)｢";
        // Define your customized keyword functions.
        msgSys.AddSpecialCharToFuncMap("UsageCase", CustomizedFunction);
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
                    msgSys.ReadTextFromResource("Yao1");
                    break;
                case 1:
                    msgSys.SetDisplayVariable("MyName", myName);
                    msgSys.ReadTextFromResource("Yao2");
                    break;
                case 2:
                    msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                    
                    msgSys.SetupButtonItem("DefaultButtonItemPrefab","是",()=>{                            
                            msgSys.Resume();
                            msgSys.RemoveButtonUI();
                            msgSys.ReadTextFromResource("Financialyes");                          
                        });
                    
                    msgSys.SetupButtonItem("DefaultButtonItemPrefab","否",()=>{
                            msgSys.Resume();
                            msgSys.RemoveButtonUI();
                            msgSys.ReadTextFromResource("Financialno");

                    });
                    //isLocked=true;
                    break;
                //case 3:
                    
                    //break;
                    
            }
            progress ++;
            
            
        }
        if(!isSign)
        {
            progress = 0;
        }

        if (/*!isGameEnd &&*/ Input.GetKeyDown(KeyCode.Space))
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
