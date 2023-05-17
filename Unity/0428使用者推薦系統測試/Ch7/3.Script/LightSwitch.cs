using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light lighton;//光源
    public GameObject objects;//開燈狀態的物件
    public GameObject objecting;//關燈狀態的物件

    bool open = false;

    // Use this for initialization
    void Start()
    {
        //一開始先將光源關閉，開燈狀態的物件隱藏
        lighton.GetComponent<Light>().enabled = false;
        objects.GetComponent<MeshRenderer>().enabled = false;
    }

    //接受訊息後執行以下功能
    void Switch()
    {
        open = !open;//每接受一次訊息，變換一次型態(on/off)
       
        if (!open) //off
        {
            lighton.GetComponent<Light>().enabled = false;//關閉光源
            objects.GetComponent<MeshRenderer>().enabled = false;
            objecting.GetComponent<MeshRenderer>().enabled = true;//顯示關燈狀態的物件
        }
        else//on
        {
            lighton.GetComponent<Light>().enabled = true;//開啟光源
            objecting.GetComponent<MeshRenderer>().enabled = false;
            objects.GetComponent<MeshRenderer>().enabled = true;//顯示開燈狀態的物件
        }
    }
}
