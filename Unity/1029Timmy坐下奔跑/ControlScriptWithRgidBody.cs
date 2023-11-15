using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityChan
{
    // 所需組件列表
    //附加音效播放器組件
    //[RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class ControlScriptWithRgidBody : MonoBehaviour
    {
        public GameObject dialogBox;
        public Text dialogBoxText;
        public string signText;
        private bool isPlayerInSign;
        public Transform backDoor;
        private bool isDoor;
        private Transform playerTransform;

        //public AudioClip openAudio;//開啟音效
        //AudioSource source;
        public Texture[] mouse_pic; //游標圖片
        int i = 0; //游標參數

        public float animSpeed = 1.5f; // 動畫速度

        // 以下為腳色控制
        // 前進速度
        public float forwardSpeed = 7.0f;
        public float RunSpeed = 10.0f;

        // 後退速度
        public float backwardSpeed = 2.0f;

        // 旋轉速度
        public float rotateSpeed = 2.0f;

        // 角色移動量（膠囊碰撞器）
        private Vector3 velocity;

        // 腳色對映的動畫
        private Animator anim;
        private bool isSitting = false; // 布尔变量用于跟踪"Sitting"状态
        private bool isSittingChair = false;

        // 初始
        void Start()
        {
            //隱藏預設鼠標
            Cursor.visible = false;

            // 取得Animator
            anim = GetComponent<Animator>();
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        // 以下處理腳色動作，在FixedUpdate內處理
        void FixedUpdate()
        {
            int i = 0;
            float h = Input.GetAxis("Horizontal"); // h 定義水平軸
            float v = Input.GetAxis("Vertical"); // v 定義垂直軸
            //anim.SetFloat("Direction", h); // 將 h 傳遞給 Animator 端設置的“Direction”參數
            //anim.SetFloat("Speed", v); // 將 v 傳遞給 Animator 端設置的“Speed”參數
            anim.speed = animSpeed; // animSpeed為Animator的動作速度
            if (isDoor)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    if (!isSitting)
                    {
                        isSittingChair = true;
                        StartCoroutine(PerformSittingAction());
                        playerTransform.position = backDoor.position;
                    }
                    else
                    {
                        isSittingChair = false;
                        StartCoroutine(PerformSittingAction1());

                        // 如果"Sitting"状态为true，将其设置为false
                    }
                }
            }

            if (isPlayerInSign)
            {
                dialogBoxText.text = signText;
                dialogBox.SetActive(true);
            }

            //按下垂直按鍵會啟動走路動作，否則啟動閒置動作
            if (Input.GetButton("Vertical"))
            {
                if (Input.GetButton("left shift"))
                {
                    anim.SetTrigger("Running");
                    i = 1;
                }
                else
                {
                    anim.SetTrigger("Walking");
                    anim.SetBool("Running", false);
                    i = 0;
                }
            }
            else
            {
                i = 0;
                anim.SetBool("Walking", false);
                anim.SetBool("Running", false);
            }
            if (!isSittingChair)
            {
                // 以下為人物移動處理
                // 從上下鍵輸入獲取Z軸的移動量
                velocity = new Vector3(0, 0, v);
                // 為角色移動速度
                velocity = transform.TransformDirection(velocity);
                //以下為v 值與預設速度一起調整
                if (v > 0.1)
                {
                    if (i == 1)
                    {
                        velocity = velocity * RunSpeed;
                    }
                    velocity *= forwardSpeed; // 乘上往前移動速度
                }
                else if (v < -0.1)
                {
                    velocity *= backwardSpeed; // 乘上往後移動速度
                }

                // 上下鍵移動角色
                transform.localPosition += velocity * Time.fixedDeltaTime;
            }

            // 左右鍵改變水平的旋轉
            transform.Rotate(0, h * rotateSpeed, 0);
        }

        void OnTriggerEnter(Collider other)
        {
            if (
                other.gameObject.CompareTag("chair")
                && other.GetType().ToString() == "UnityEngine.CapsuleCollider"
            )
            {
                Debug.Log("Playerenter");
                isDoor = true;
                isPlayerInSign = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (
                other.gameObject.CompareTag("chair")
                && other.GetType().ToString() == "UnityEngine.CapsuleCollider"
            )
            {
                Debug.Log("Playeexit");
                isDoor = false;
                isPlayerInSign = false;
                dialogBox.SetActive(false);
            }
        }

        IEnumerator PerformSittingAction()
        {
            // 触发坐下动作
            anim.SetTrigger("Sitting");

            // 等待坐下动作完成（你需要根据实际动画的长度来设置等待时间）
            float waitTime = 1.0f; // 假设坐下动作需要2秒
            yield return new WaitForSeconds(waitTime);
            isSitting = true;
        }

        IEnumerator PerformSittingAction1()
        {
            anim.SetBool("Sitting", false);

            // 等待坐下动作完成（你需要根据实际动画的长度来设置等待时间）
            float waitTime = 1.0f; // 假设坐下动作需要2秒
            yield return new WaitForSeconds(waitTime);
            isSitting = false;
        }

        //螢幕上GUI顯示
        void OnGUI()
        {
            //GUI.Box (new Rect (Screen.width - 180, 10, 180, 101), "移動教學");
            //GUI.Label (new Rect (Screen.width - 180, 30, 180, 30), "W/S : 向前/向後");
            //GUI.Label (new Rect (Screen.width - 180, 50, 180, 30), "A/D : 向左轉/向右轉");
            //GUI.Label (new Rect (Screen.width - 180, 70, 180, 30), "按住右鍵調整視角/左鍵可翻書");
            //GUI.Label (new Rect (Screen.width - 180, 90, 180, 30), "按Space跳下一個對話框");
            //顯示鼠標與鼠標位置
            GUI.depth = 0;
            Vector3 mouse_pos = Input.mousePosition;
            GUI.DrawTexture(
                new Rect(mouse_pos.x, Screen.height - mouse_pos.y, 64, 64),
                mouse_pic[i]
            );
        }
    }
}
