using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;

//附加音效播放器組件
[RequireComponent(typeof(AudioSource))]
public class House3 : MonoBehaviour
{
    public AudioClip openAudio; //開啟音效
    AudioSource source;

    public Text Money;
    public Text Draw;
    public Text MoneyF;
    public Text DrawF;
    public Text AccountF;
    public Text Income;
    public GameObject box;
    public GameObject dialogBox;
    public GameObject dialogBox2;
    public GameObject dialogBox3;
    public Text dialogBoxText;
    public Text dialogBoxText2;
    public Text dialogBoxText3;
    public string signText;
    public string signText2;
    private bool isSign = false;

    private Transform playerTransform;

    int houseprice = 800;
    bool buy = false;

    void Start()
    {
        StartCoroutine(UpdateStockPrice());
        source = GetComponent<AudioSource>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        string draw = "";
        string drawText = Draw.text;
        draw = drawText + draw;
        DrawF.text = Draw.text;
        MoneyF.text = Income.text;
        AccountF.text = Money.text;
        if (drawText.Contains("陽光別墅"))
        {
            buy = true;
        }

        int money = 1000;
        int income = 0;

        if (int.TryParse(Money.text, out int moneyValue))
        {
            money = moneyValue;
        }
        else
        {
            Debug.LogError("Failed to convert Money.text to integer.");
        }

        if (isSign && !buy)
        {
            dialogBoxText.text = signText + houseprice.ToString() + "萬";
            if (money >= houseprice)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    money = money - houseprice;
                    draw = draw + "陽光別墅\n";
                    source.PlayOneShot(openAudio);
                    Money.text = money.ToString();
                    Draw.text = draw;
                    dialogBox.SetActive(false);
                    dialogBox3.SetActive(true);
                    box.SetActive(true);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    dialogBox2.SetActive(true);
                    dialogBox.SetActive(false);
                    dialogBoxText2.text = "金額不夠";
                    StartCoroutine(Price());
                }
            }
        }
        if (isSign && buy)
        {
            dialogBoxText3.text = signText2 + houseprice.ToString() + "萬";
            if (Input.GetKeyDown(KeyCode.E))
            {
                money = money + houseprice;
                income = money - 1000;
                string houseNameToRemove = "陽光別墅";
                int index = draw.IndexOf(houseNameToRemove);
                box.SetActive(false);
                if (index != -1)
                {
                    // 找到子字符串，刪除它及其後面的換行符號
                    draw = draw.Remove(index, houseNameToRemove.Length + 1); // +1 是為了刪除換行符號
                }
                buy = false;
                source.PlayOneShot(openAudio);
                Money.text = money.ToString();
                Income.text = income.ToString();
                Draw.text = draw;
                dialogBox.SetActive(true);
                dialogBox3.SetActive(false);
            }
        }
    }

    IEnumerator UpdateStockPrice()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f); // 更新一次股票價格
            houseprice = Random.Range(600, 2000); // 隨機生成新的價格
        }
    }

    IEnumerator Price()
    {
        yield return new WaitForSeconds(1.5f);
        dialogBox.SetActive(true);
        dialogBox2.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (
            other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider"
        )
        {
            isSign = true;
            Debug.Log("ya");
            if (!buy)
            {
                dialogBox.SetActive(true);
            }
            else
            {
                dialogBox3.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (
            other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider"
        )
        {
            isSign = false;
            Debug.Log("no");
            dialogBox.SetActive(false);
            dialogBox2.SetActive(false);
            dialogBox3.SetActive(false);
        }
    }
}
