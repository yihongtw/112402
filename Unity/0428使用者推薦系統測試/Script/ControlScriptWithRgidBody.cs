using UnityEngine;
using System.Collections;

namespace UnityChan
{
// 所需組件列表
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CapsuleCollider))]
	[RequireComponent(typeof(Rigidbody))]

	public class ControlScriptWithRgidBody : MonoBehaviour
	{
		public Texture[] mouse_pic;//游標圖片
		int i = 0;//游標參數
		

		public float animSpeed = 1.5f;	// 動畫速度

		// 以下為腳色控制
		// 前進速度
		public float forwardSpeed = 7.0f;
		// 後退速度
		public float backwardSpeed = 2.0f;
		// 旋轉速度
		public float rotateSpeed = 2.0f;
		
		// 角色移動量（膠囊碰撞器）
		private Vector3 velocity;
		// 腳色對映的動畫
		private Animator anim;

		// 初始
		void Start ()
		{
			//隱藏預設鼠標
			Cursor.visible = false; 
			
			// 取得Animator
			anim = GetComponent<Animator> ();
			
		}
	
	
		// 以下處理腳色動作，在FixedUpdate內處理
		void FixedUpdate ()
		{
			
			
			float h = Input.GetAxis ("Horizontal");	// h 定義水平軸
			float v = Input.GetAxis ("Vertical");	// v 定義垂直軸
			anim.SetFloat ("Direction", h); 		// 將 h 傳遞給 Animator 端設置的“Direction”參數
			anim.SetFloat ("Speed", v);				// 將 v 傳遞給 Animator 端設置的“Speed”參數
			anim.speed = animSpeed;				    // animSpeed為Animator的動作速度

            //按下垂直按鍵會啟動走路動作，否則啟動閒置動作
			if(Input.GetButton("Vertical")){
				anim.SetTrigger("isWalking");
			}else  {
				anim.SetTrigger("isIdle");
			}

			// 以下為人物移動處理
			// 從上下鍵輸入獲取Z軸的移動量
			velocity = new Vector3 (0, 0, v);		
			// 為角色移動速度
			velocity = transform.TransformDirection (velocity);
			//以下為v 值與預設速度一起調整
			if (v > 0.1) {
				velocity *= forwardSpeed;		// 乘上往前移動速度
			} else if (v < -0.1) {
				velocity *= backwardSpeed;	// 乘上往後移動速度
			}

			// 上下鍵移動角色
			transform.localPosition += velocity * Time.fixedDeltaTime;

			// 左右鍵改變水平的旋轉
			transform.Rotate (0, h * rotateSpeed, 0);	
			



			   
		}

	


		
		


		//螢幕上GUI顯示
		void OnGUI ()
		{
			GUI.Box (new Rect (Screen.width - 260, 10, 250, 90), "Interaction");
			GUI.Label (new Rect (Screen.width - 245, 30, 250, 30), "W/S : Go Forwald/Go Back");
			GUI.Label (new Rect (Screen.width - 245, 50, 250, 30), "A/D : Turn Left/Turn Right");
			GUI.Label (new Rect (Screen.width - 245, 70, 250, 30), "右鍵調整視角");
			//顯示鼠標與鼠標位置
			GUI.depth = 0;
            Vector3 mouse_pos = Input.mousePosition;
            GUI.DrawTexture(new Rect(mouse_pos.x, Screen.height - mouse_pos.y, 64, 64), mouse_pic[i]);
		}
	}
}