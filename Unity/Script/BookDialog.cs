using UnityEngine;
using UnityEngine.UI;

public class BookDialog : MonoBehaviour
{
    public Transform player;//主角
    public GameObject dialogUI;

    

    // Use this for initialization
    void Start()
    {
        
        dialogUI.GetComponentInChildren<Button>().onClick.AddListener(DialogClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider")
            {
                Debug.Log("Playerenter");
                dialogUI.SetActive(true);
                
                
            }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider")
            {
                Debug.Log("Playeexit");
                dialogUI.SetActive(false);
            
            }
    }


    void DialogClick()
    {
        dialogUI.SetActive(false);
        
    }
}
