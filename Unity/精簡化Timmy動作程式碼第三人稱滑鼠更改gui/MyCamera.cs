using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour
{
    public Transform target;//鏡頭鎖定物件
    public LayerMask hitLayer;//射線使用層

    Vector3 pos;

    // Use this for initialization
    void Start()
    {
        pos.x = 5;
        pos.y = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = target.position + new Vector3(0, 1.5f, 0);
        Vector2 vec2 = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        //按下滑鼠右鍵，才能控制鏡頭
        if (Input.GetMouseButton(1))
        {
            pos.x += vec2.x * 10;
            pos.y -= vec2.y * 10;
            pos.y = Mathf.Clamp(pos.y, -30, 45);//鏡頭仰角限制
        }

        RaycastHit hit;
        var rotation = Quaternion.Euler(new Vector3(pos.y, pos.x, 0));
        var position = rotation * new Vector3(0, 0, -pos.z);
        pos.z = 3.4f;
        //當碰到障礙物，鏡頭會拉往目標方向
        if (Physics.Raycast(point, position, out hit, pos.z + 0.1f, hitLayer))
            pos.z = Mathf.Clamp(hit.distance - 0.2f, 0.1f, 1.4f);
        Debug.DrawRay(point, rotation * new Vector3(0, 0, -pos.z - 0.1f), Color.green);

        transform.position = position + point;//鏡頭跟隨目標
        transform.LookAt(point);//視角注視目標	
    }
}
