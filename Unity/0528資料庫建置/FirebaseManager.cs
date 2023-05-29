using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;

//附加音效播放器組件
[RequireComponent(typeof(AudioSource))]

public class FirebaseManager : MonoBehaviour
{
    public AudioClip openAudio2;
    AudioSource source2;
    public AudioClip openAudio;//開啟音效
    AudioSource source;
    
    public Transform backDoor;
    private Transform playerTransform;
    public Firebase.Auth.FirebaseAuth auth;
    public Firebase.Auth.FirebaseUser user;
    public GameObject Loginfalse;
    public GameObject Registerfalse;
   

    // Start is called before the first frame update
    void Start()
    {
        source2 = GetComponent<AudioSource>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        source = GetComponent<AudioSource>();
        
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;//先等待Manager讀取資料才到MainScene完成註冊
        auth.StateChanged += AuthStateChanged;//訂閱時
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Register(string email, string password){//ContinueWith為了接收task
        Registerfalse.SetActive(true);
        source2.PlayOneShot(openAudio2);
        auth.CreateUserWithEmailAndPasswordAsync(email,password).ContinueWith( task =>{
            //檢查task最後處理的狀態
            if(task.IsCanceled){
                return;
            }
            if(task.IsFaulted){
                
                print(task.Exception.InnerException.Message);
                
                return;
            }
            if(task.IsCompletedSuccessfully){
                print("Registered!");
            }
            
        });
    }

    public void Login(string email, string password){
        source2.PlayOneShot(openAudio2);
        Loginfalse.SetActive(true);
        auth.SignInWithEmailAndPasswordAsync(email,password).ContinueWith(task =>{
            if(task.IsFaulted){
                print(task.Exception.InnerException.Message);
                
                return;
            }
            if(task.IsCompletedSuccessfully){
                print("Login!");
            }
            
        });

    }

    public void Logout(){
        auth.SignOut();
        playerTransform.position = backDoor.position;
        source.PlayOneShot(openAudio);

    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs){
        //角色從登入或角色從登入到登出的角色切換觸發以下事件
        if(auth.CurrentUser != user){
            user = auth.CurrentUser;
            if(user != null){
                print($"Login - {user.Email}");//顯示使用者Email
                //firebase會自動顯示使用者登入狀態到Unity
            }
        }
    }
    public void SaveData(string data){
        if(user != null){
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
            reference.Child(user.UserId).Child("email").SetValueAsync(user.Email).ContinueWith(task =>{
                if(task.IsCompletedSuccessfully){
                    print("Saved!");
                }

            });
            reference.Child(user.UserId).Child("data").SetValueAsync(data).ContinueWith(task =>{
                if(task.IsCompletedSuccessfully){
                    print("Saved!");
                }

            });
        }else{
            print("no user");
        }

    }
    public void LoadData(){
        if(user != null){
            DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
            reference.Child(user.UserId).Child("data").GetValueAsync().ContinueWith(task=>{
                DataSnapshot snapshot = task.Result;
                print(snapshot.Value);
                
            });
        }else {
            print("No user");
        }
    }

    public DatabaseReference GetUserReference(){
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        return reference.Child(user.UserId);
    }

    void OnDestroy() {
        auth.StateChanged -= AuthStateChanged;//將元件刪除
    }
}
