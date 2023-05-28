using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainScene : MonoBehaviour
{
    [SerializeField]
    FirebaseManager firebaseManager;
    [SerializeField]
    InputField inputEmail;
    [SerializeField]
    InputField inputPassword;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Register(){
        firebaseManager.Register(inputEmail.text, inputPassword.text);
    }
}
