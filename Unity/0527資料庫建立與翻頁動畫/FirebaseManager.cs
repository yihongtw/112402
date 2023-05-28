using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseManager : MonoBehaviour
{
    public Firebase.Auth.FirebaseAuth auth;
    public Firebase.Auth.FirebaseUser user;
    // Start is called before the first frame update
    void Start()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Register(string email, string password){//ContinueWith為了接收task
        auth.CreateUserWithEmailAndPasswordAsync(email,password).ContinueWith( task =>{
            //檢查task最後處理的狀態
            if(task.IsCanceled){
                return;
            }
            if(task.IsFaulted){
                return;
            }
            if(task.IsCompletedSuccessfully){
                print("Registered!");
            }

        });

    }
}
