using UnityEngine;
using UnityEngine.Video;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(VideoPlayer))]
public class Movie : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogBoxText;
    public string signText;
    private bool isPlayerInSign;

    bool open;

    Material mat;
    VideoPlayer video;


    void Start()
    {
        mat = GetComponent<Renderer>().material;
        video = GetComponent<VideoPlayer>();

        mat.color = new Color(0, 0, 0, 255);//材質球顏色=黑、不透明
        
    }


    void Update()
    {
      
        if(open)
        {
                if (Input.GetMouseButtonDown(0))
                {
                    mat.color = Color.white;//材質球顏色=白
                    video.Play();//播放
                }
                if (Input.GetMouseButtonDown(1))
                {
                    mat.color = Color.black;//材質球顏色=黑
                    video.Stop();//停止播放
                }

        }
        if(isPlayerInSign)
        {
            dialogBoxText.text = signText;
            dialogBox.SetActive(true);
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider")
            {
                open = true;
                Debug.Log("Playerenter");

                isPlayerInSign = true;
                
               
                
            }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider")
            {
                open = false; 
                Debug.Log("Playeexit");

                isPlayerInSign = false;
                dialogBox.SetActive(false);

                
                
            }
    }
    

  

}
