using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMove : MonoBehaviour
{

    public LayerMask hitLayer;//射線使用層
    public Transform myCursor;//光標物件
    public Texture[] mouse_pic;//游標圖片

    int i = 0;//游標參數
    float walkSp = 1.04f;//走路速度
    bool isWalk;
    Vector3 pos;//移動座標
    Transform Switch;//物件開關

    public static bool isGui;//GUI隔絕射線

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;//隱藏預設鼠標

        myCursor.gameObject.SetActive(false);
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //射線偵測
        if (Physics.Raycast(ray, out RaycastHit hit, 100, hitLayer) && !isGui)
        {
            //當碰到開關
            if (hit.transform.tag == "Switch")
            {
                Switch = hit.transform;
                var SwitchPos = new Vector3(Switch.position.x, 0, Switch.position.z);
                var myPos = new Vector3(transform.position.x, 0, transform.position.z);
                var dist = Vector3.Distance(myPos, SwitchPos);

                //能開啟的範圍
                if (dist > 0.2 && dist < 3)
                {
                    i = 1;
                    if (Input.GetMouseButtonDown(0))
                    {
                        Switch.SendMessageUpwards("Switch", SendMessageOptions.DontRequireReceiver);
                        pos = transform.position;
                    }
                }
            }
            //平常移動
            else
            {
                i = 0;
                if (Input.GetMouseButtonDown(0))
                {
                    pos = hit.point;
                    pos.y = 0.05f;
                    myCursor.gameObject.SetActive(true);//顯示光標
                    myCursor.transform.position = pos;
                }
            }
            Debug.DrawLine(ray.origin, hit.point);
        }
        MoveTowards(pos);
    }

    void MoveTowards(Vector3 position)
    {
        var forward = transform.TransformDirection(Vector3.forward);
        var direction = position - transform.position;
        direction.y = 0;

        //人物轉身
        if (direction.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 5 * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        //隱藏光標
        else
            myCursor.gameObject.SetActive(false);

        var speedModifier = Vector3.Dot(forward, direction.normalized);
        speedModifier = Mathf.Clamp01(speedModifier);
        direction = forward * walkSp * speedModifier;
        GetComponent<CharacterController>().SimpleMove(direction);//人物移動

        PlayAnimation(1 * speedModifier);
    }

    //腳色動畫
    void PlayAnimation(float speed)
    {
        if (speed > 0.5f && !isWalk)
        {
            isWalk = true;
            GetComponent<Animator>().SetTrigger("walk");
        }
        else if (speed <= 0.5f && isWalk)
        {
            isWalk = false;
            GetComponent<Animator>().SetTrigger("idle");
        }            
    }

    //顯示鼠標與鼠標位置
    void OnGUI()
    {
        GUI.depth = 0;
        Vector3 mouse_pos = Input.mousePosition;
        GUI.DrawTexture(new Rect(mouse_pos.x, Screen.height - mouse_pos.y, 64, 64), mouse_pic[i]);
    }
}
