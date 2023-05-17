using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//附加音效播放器組件
[RequireComponent(typeof(AudioSource))]

public class DoorEnter : MonoBehaviour
{
    
    

    public AudioClip openAudio;//開啟音效
    AudioSource source;

    public GameObject dialogBox;
    public Text dialogBoxText;
    public string signText;
    private bool isPlayerInSign;

    public Transform backDoor;

    private bool isDoor;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        source = GetComponent<AudioSource>();
        
        
        
    }

   

    // Update is called once per frame
    void Update()
    {
        if(isDoor)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
            playerTransform.position = backDoor.position;
            source.PlayOneShot(openAudio);
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
                Debug.Log("Playerenter");
                isDoor = true;
                isPlayerInSign = true;
                
            }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider")
            {
                Debug.Log("Playeexit");
                isDoor = false;
                isPlayerInSign = false;
                dialogBox.SetActive(false);
            }
    }
}
