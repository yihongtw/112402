using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;

//附加音效播放器組件
[RequireComponent(typeof(AudioSource))]

public class NFTfinal : MonoBehaviour
{
    public AudioClip openAudio;//開啟音效
    public AudioClip openAudio1;//開啟音效
    AudioSource source;

    public Text Money;
    public Text Draw;
    public GameObject moneypanel;
    public GameObject moneyuppanel;
    
    [SerializeField]
    ESMessageSystem msgSys;
    
    private Transform playerTransform;
    
    private int progress = 0;
   
    private bool isSign = false; 
    private bool end = false;

    public Transform backDoor;
    private bool isDoor;

    

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
       
        string draw ="";
        string drawText = Draw.text;
        draw = drawText + draw;  
        
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
        if(msgSys.isCompleted && isSign ){
            switch(progress){
                case 0:
                    msgSys.Resume();
                    msgSys.ReadTextFromResource("是否結束且顯示金額");
                    
                    break;
                case 1:
                    //msgSys.SetDisplayVariable("MyName", myName);
                    
                    
                   
                    break;
                case 2:                                  
                    msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                    msgSys.SetupButtonItem("DefaultButtonItemPrefab","好的",()=>{ 
                        msgSys.Resume();
                        msgSys.RemoveButtonUI();
                        msgSys.ReadTextFromResource("Hide");
                        moneypanel.SetActive(true);
                        moneyuppanel.SetActive(false);
                        end = true;
                        source.PlayOneShot(openAudio1);
                        Money.text = money.ToString();  
                        Draw.text = draw;
                    });
                    msgSys.SetupButtonItem("DefaultButtonItemPrefab","我想繼續體驗",()=>{
                        msgSys.Resume();
                        msgSys.RemoveButtonUI();
                        msgSys.ReadTextFromResource("Hide");
                     });
                                                

                            break;
            }
            progress ++ ;    
        }
        if(end){
            if(Input.GetKeyDown(KeyCode.Space))
            {
                end = false;
                moneypanel.SetActive(false);
                playerTransform.position = backDoor.position;
                source.PlayOneShot(openAudio);

            }

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
