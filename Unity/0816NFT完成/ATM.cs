using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;

//附加音效播放器組件
[RequireComponent(typeof(AudioSource))]

public class ATM : MonoBehaviour
{
    public AudioClip openAudio;//開啟音效
    AudioSource source;

    public Text Money;
    public Text Account;
    public Text MoneyF;
    public Text AccountF;
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
        MoneyF.text = Money.text;
        AccountF.text = Account.text;

        int money = 0 ;
        int account = 5000;
        if (int.TryParse(Money.text, out int moneyValue))
        {
            money = moneyValue;
        }
        else
        {
            Debug.LogError("Failed to convert Money.text to integer.");
        }
        if (int.TryParse(Account.text, out int accountValue))
        {
            account = accountValue;
        }
        else
        {
            Debug.LogError("Failed to convert Money.text to integer.");
        }
        // ----- Integration DEMO -----
        // Your own logic control.
        if(msgSys.isCompleted && isSign){
            switch(progress){
                case 0:
                    msgSys.Resume();
                    
                    
                    break;
                case 1:
                    //msgSys.SetDisplayVariable("MyName", myName);
                    msgSys.ReadTextFromResource("加值多少");
                    
                   
                    break;
                case 2:                                                                    
                                msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                msgSys.SetupButtonItem("DefaultButtonItemPrefab","1,000",()=>{   
                                    msgSys.Resume();
                                    msgSys.RemoveButtonUI();
                                    msgSys.ReadTextFromResource("Hide");
                                    
                                    if (account >= 1000){
                                        money = money + 1000;
                                        account = account -1000;
                                        source.PlayOneShot(openAudio);
                                    }
                                    else{
                                        msgSys.ReadTextFromResource("戶頭金額不足");
                                    }
                                    Money.text = money.ToString();
                                    Account.text = account.ToString();

                                                                                                                          
                                });
        
                                msgSys.SetupButtonItem("DefaultButtonItemPrefab","5,000",()=>{
                                    msgSys.Resume();
                                    msgSys.RemoveButtonUI();
                                    msgSys.ReadTextFromResource("Hide");
                                    
                                    if(account >= 5000){
                                        money = money + 5000;
                                        account = account -5000;
                                        source.PlayOneShot(openAudio);
                                    }
                                    else{
                                        msgSys.ReadTextFromResource("戶頭金額不足");
                                    }
                                    Money.text = money.ToString();
                                    Account.text = account.ToString();
                                });         
                                msgSys.SetupButtonItem("DefaultButtonItemPrefab","10,000",()=>{   
                                    msgSys.Resume();
                                    msgSys.RemoveButtonUI();
                                    msgSys.ReadTextFromResource("Hide");
                                   
                                    if(account >= 10000){
                                        money = money + 10000;
                                        account = account -10000;
                                        source.PlayOneShot(openAudio);
                                    }
                                    else{
                                        msgSys.ReadTextFromResource("戶頭金額不足");
                                    }
                                    Money.text = money.ToString();
                                    Account.text = account.ToString();
                                                                                                                          
                                });
                                msgSys.SetupButtonItem("DefaultButtonItemPrefab","100,000",()=>{   
                                    msgSys.Resume();
                                    msgSys.RemoveButtonUI();
                                    msgSys.ReadTextFromResource("Hide");
                                    
                                    if(account >= 100000){
                                        money = money + 100000;
                                        account = account -100000;
                                        source.PlayOneShot(openAudio);
                                    }
                                    else{
                                        msgSys.ReadTextFromResource("戶頭金額不足");
                                    }
                                    Money.text = money.ToString();
                                    Account.text = account.ToString();
                                                                                                                          
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
