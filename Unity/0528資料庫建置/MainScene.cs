using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;

public class MainScene : MonoBehaviour
{
   
    [SerializeField]
    FirebaseManager firebaseManager;
    [SerializeField]
    InputField inputEmail;
    [SerializeField]
    InputField inputPassword;

    [SerializeField]
    GameObject panelLogin;
    [SerializeField]
    GameObject panelInfo;
    [SerializeField]
    GameObject Door;

    [SerializeField]
    Text textEmail;

    [SerializeField]
    InputField inputNote;
    public GameObject Loginfalse;
    public GameObject Registerfalse;


    // Start is called before the first frame update
    void Start()
    {
        firebaseManager.auth.StateChanged += AuthStateChanged; //訂閱時
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Register(){
        firebaseManager.Register(inputEmail.text, inputPassword.text);
    }
    public void Login(){
        firebaseManager.Login(inputEmail.text, inputPassword.text);
    }
    public void Logout(){
        inputEmail.text = "";
        inputPassword.text = "";
        firebaseManager.Logout();
        
    }

    public void SaveNote(){
        firebaseManager.SaveData(inputNote.text);
    }
    public void LoadNote(){
        //firebaseManager.LoadData();
        StartCoroutine(LoadNoteTask());
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs){
        //角色從登入或角色從登入到登出的角色切換觸發以下事件
        if(firebaseManager.user == null){ //角色已經登出
            textEmail.text = "";//登出時，信箱資訊為空
            Door.SetActive(false);//登出時，園區大門碰撞區關閉
            panelLogin.SetActive(true); //登入介面跳出
            panelInfo.SetActive(false);//資訊頁面關閉
            
        }else{
            Loginfalse.SetActive(false);
            Registerfalse.SetActive(false);
            textEmail.text = firebaseManager.user.Email;
            StartCoroutine(LoadNoteTask());
            Door.SetActive(true);
            panelLogin.SetActive(false);
            panelInfo.SetActive(true);
        }

    }

    void OnDestroy() {
        firebaseManager.auth.StateChanged -= AuthStateChanged;
    }

    IEnumerator LoadNoteTask(){
        var task = firebaseManager.GetUserReference().Child("data").GetValueAsync();
        yield return new WaitUntil(()=>task.IsCompleted);
        DataSnapshot snapshot = task.Result;
        if(snapshot.Value != null){
            string note = snapshot.Value.ToString();
            print(note);
            inputNote.text = note;
        }else{
            print("No note");
            inputNote.text = "";
        }
        
    }
}
