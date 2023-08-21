using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;

//附加音效播放器組件
[RequireComponent(typeof(AudioSource))]

public class SaleDraw3 : MonoBehaviour
{
    public AudioClip openAudio;//開啟音效
    AudioSource source;

    public Text Money;
    public Text Draw;
    
    [SerializeField]
    ESMessageSystem msgSys;
    
    private Transform playerTransform;
    
    private int progress = 0;
   
    private bool isSign = false; 
    

    void Start()
    {
       
        // Define your customized keyword functions.
        msgSys.AddSpecialCharToFuncMap("UsageCase", CustomizedFunction);
        source = GetComponent<AudioSource>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }
    private void CustomizedFunction()
    {
        Debug.Log("Hi! This is called by CustomizedFunction!");
    }

    void Update()
    {
        bool draw1 = false;
        string draw ="";
        string drawText = Draw.text;
        draw = drawText + draw;
        if (drawText.Contains("霞光萬丈"))
        {
            draw1 = true;
        }    
        
        int money = 0 ;
        if (int.TryParse(Money.text, out int moneyValue))
        {
            money = moneyValue;
        }
        else
        {
            Debug.LogError("Failed to convert Money.text to integer.");
        }
        // ----- Integration DEMO -----
        // Your own logic control.
        if(msgSys.isCompleted && isSign && draw1 ){
            switch(progress){
                case 0:
                    msgSys.Resume();
                    msgSys.ReadTextFromResource("要以多少錢出售");
                    
                    break;
                case 1:
                    //msgSys.SetDisplayVariable("MyName", myName);
                    
                    
                   
                    break;
                case 2:                                  
                    msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                    msgSys.SetupButtonItem("DefaultButtonItemPrefab","50,000",()=>{ 
                        msgSys.Resume();
                        msgSys.RemoveButtonUI();
                        msgSys.ReadTextFromResource("Hide");
                        money = money + 50000;
                        string substringToRemove = "霞光萬丈";
                        draw = draw.Replace(substringToRemove, "");
                        source.PlayOneShot(openAudio);
                        msgSys.ReadTextFromResource("交易成功");
                        Money.text = money.ToString();  
                        Draw.text = draw;
                    });
                    msgSys.SetupButtonItem("DefaultButtonItemPrefab","55,000",()=>{ 
                        msgSys.Resume();
                        msgSys.RemoveButtonUI();
                        msgSys.ReadTextFromResource("Hide");
                        msgSys.ReadTextFromResource("沒有買家購買");
                    });    
                    msgSys.SetupButtonItem("DefaultButtonItemPrefab","60,000",()=>{ 
                        msgSys.Resume();
                        msgSys.RemoveButtonUI();
                        msgSys.ReadTextFromResource("Hide");
                        msgSys.ReadTextFromResource("沒有買家購買");
                    });                                                   

                            break;
            }
            progress ++ ;    
        }
        if(msgSys.isCompleted && isSign && !draw1){
            switch(progress){
                case 0:
                    msgSys.Resume();
                    msgSys.ReadTextFromResource("尚未購買資產");
                    break;
            }
            progress++;
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
