using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;

//附加音效播放器組件
[RequireComponent(typeof(AudioSource))]
public class Draw2 : MonoBehaviour
{
    public AudioClip openAudio; //開啟音效
    AudioSource source;
    public GameObject box;
    public Text Account;
    public Text Money;
    public Text Draw;
    public Text MoneyF;
    public Text DrawF;

    [SerializeField]
    ESMessageSystem msgSys;

    private Transform playerTransform;

    private int progress = 0;

    private bool isSign = false;

    void Start()
    {
        // Define your customized keyword functions.
        msgSys.AddSpecialCharToFuncMap("UsageCase", CustomizedFunction);
        source = GetComponent<AudioSource>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void CustomizedFunction()
    {
        Debug.Log("Hi! This is called by CustomizedFunction!");
    }

    void Update()
    {
        bool sold = false;
        string draw = "";
        string drawText = Draw.text;
        draw = drawText + draw;
        DrawF.text = Draw.text;
        MoneyF.text = Money.text;
        if (drawText.Contains("蒼穹雪夢"))
        {
            sold = true;
        }

        int money = 0;
        if (int.TryParse(Money.text, out int moneyValue))
        {
            money = moneyValue;
        }
        else
        {
            Debug.LogError("Failed to convert Money.text to integer.");
        }
        int account = 0;
        if (int.TryParse(Account.text, out int accountValue))
        {
            account = accountValue;
        }
        else
        {
            Debug.LogError("Failed to convert Account.text to integer.");
        }
        // ----- Integration DEMO -----
        // Your own logic control.
        if (msgSys.isCompleted && isSign && !sold)
        {
            switch (progress)
            {
                case 0:
                    msgSys.Resume();
                    msgSys.ReadTextFromResource("蒼穹雪夢1");

                    break;
                case 1:
                    //msgSys.SetDisplayVariable("MyName", myName);
                    msgSys.ReadTextFromResource("蒼穹雪夢");

                    break;
                case 2:
                    msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                    msgSys.SetupButtonItem(
                        "DefaultButtonItemPrefab",
                        "直接購買",
                        () =>
                        {
                            msgSys.Resume();
                            msgSys.RemoveButtonUI();
                            msgSys.ReadTextFromResource("Hide");
                            if (money >= 10000)
                            {
                                money = money - 10000;
                                draw = draw + "蒼穹雪夢\n";
                                source.PlayOneShot(openAudio);
                                msgSys.ReadTextFromResource("交易成功");
                                box.SetActive(true);
                            }
                            else
                            {
                                msgSys.ReadTextFromResource("金錢不夠");
                            }
                            Money.text = money.ToString();
                            Draw.text = draw;
                        }
                    );
                    msgSys.SetupButtonItem(
                        "DefaultButtonItemPrefab",
                        "提出報價",
                        () =>
                        {
                            msgSys.Resume();
                            msgSys.RemoveButtonUI();
                            msgSys.ReadTextFromResource("選擇報價");
                            msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                            msgSys.SetupButtonItem(
                                "DefaultButtonItemPrefab",
                                "9,000",
                                () =>
                                {
                                    msgSys.Resume();
                                    msgSys.RemoveButtonUI();
                                    msgSys.ReadTextFromResource("買家接受此報價");
                                    if (money >= 9000)
                                    {
                                        money = money - 9000;
                                        draw = draw + "蒼穹雪夢\n";
                                        source.PlayOneShot(openAudio);
                                        box.SetActive(true);
                                    }
                                    else
                                    {
                                        msgSys.ReadTextFromResource("金錢不夠");
                                    }
                                    Money.text = money.ToString();
                                    Draw.text = draw;
                                }
                            );
                            msgSys.SetupButtonItem(
                                "DefaultButtonItemPrefab",
                                "8,000",
                                () =>
                                {
                                    msgSys.Resume();
                                    msgSys.RemoveButtonUI();
                                    msgSys.ReadTextFromResource("買家不接受此報價");
                                    msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                    msgSys.SetupButtonItem(
                                        "DefaultButtonItemPrefab",
                                        "9,000",
                                        () =>
                                        {
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            msgSys.ReadTextFromResource("買家接受此報價");
                                            if (money >= 9000)
                                            {
                                                money = money - 9000;
                                                draw = draw + "蒼穹雪夢\n";
                                                box.SetActive(true);
                                                source.PlayOneShot(openAudio);
                                            }
                                            else
                                            {
                                                msgSys.ReadTextFromResource("金錢不夠");
                                            }
                                            Money.text = money.ToString();
                                            Draw.text = draw;
                                        }
                                    );
                                    msgSys.SetupButtonItem(
                                        "DefaultButtonItemPrefab",
                                        "7,000",
                                        () =>
                                        {
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            msgSys.ReadTextFromResource("買家不接受此報價");
                                            Money.text = money.ToString();
                                            msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                            msgSys.SetupButtonItem(
                                                "DefaultButtonItemPrefab",
                                                "9,000",
                                                () =>
                                                {
                                                    msgSys.Resume();
                                                    msgSys.RemoveButtonUI();
                                                    msgSys.ReadTextFromResource("買家接受此報價");
                                                    if (money >= 9000)
                                                    {
                                                        money = money - 9000;
                                                        draw = draw + "蒼穹雪夢\n";
                                                        box.SetActive(true);
                                                        source.PlayOneShot(openAudio);
                                                    }
                                                    else
                                                    {
                                                        msgSys.ReadTextFromResource("金錢不夠");
                                                    }
                                                    Money.text = money.ToString();
                                                    Draw.text = draw;
                                                }
                                            );
                                        }
                                    );
                                }
                            );
                            msgSys.SetupButtonItem(
                                "DefaultButtonItemPrefab",
                                "7,000",
                                () =>
                                {
                                    msgSys.Resume();
                                    msgSys.RemoveButtonUI();
                                    msgSys.ReadTextFromResource("買家不接受此報價");
                                    msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                    msgSys.SetupButtonItem(
                                        "DefaultButtonItemPrefab",
                                        "9,000",
                                        () =>
                                        {
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            msgSys.ReadTextFromResource("買家接受此報價");
                                            if (money >= 9000)
                                            {
                                                money = money - 9000;
                                                draw = draw + "蒼穹雪夢\n";
                                                box.SetActive(true);
                                                source.PlayOneShot(openAudio);
                                            }
                                            else
                                            {
                                                msgSys.ReadTextFromResource("金錢不夠");
                                            }
                                            Money.text = money.ToString();
                                            Draw.text = draw;
                                        }
                                    );
                                    msgSys.SetupButtonItem(
                                        "DefaultButtonItemPrefab",
                                        "8,000",
                                        () =>
                                        {
                                            msgSys.Resume();
                                            msgSys.RemoveButtonUI();
                                            msgSys.ReadTextFromResource("買家不接受此報價");
                                            Money.text = money.ToString();
                                            msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                                            msgSys.SetupButtonItem(
                                                "DefaultButtonItemPrefab",
                                                "9,000",
                                                () =>
                                                {
                                                    msgSys.Resume();
                                                    msgSys.RemoveButtonUI();
                                                    msgSys.ReadTextFromResource("買家接受此報價");
                                                    if (money >= 9000)
                                                    {
                                                        money = money - 9000;
                                                        draw = draw + "蒼穹雪夢\n";
                                                        box.SetActive(true);
                                                        source.PlayOneShot(openAudio);
                                                    }
                                                    else
                                                    {
                                                        msgSys.ReadTextFromResource("金錢不夠");
                                                    }
                                                    Money.text = money.ToString();
                                                    Draw.text = draw;
                                                }
                                            );
                                        }
                                    );
                                }
                            );
                        }
                    );

                    break;
            }
            progress++;
        }
        if (msgSys.isCompleted && isSign && sold)
        {
            switch (progress)
            {
                case 0:
                    msgSys.Resume();
                    msgSys.ReadTextFromResource("要以多少錢出售");

                    break;
                case 1:
                    //msgSys.SetDisplayVariable("MyName", myName);



                    break;
                case 2:
                    msgSys.SetupButtonUIPrefab("DefaultButtonUIPrefab");
                    msgSys.SetupButtonItem(
                        "DefaultButtonItemPrefab",
                        "12,000",
                        () =>
                        {
                            msgSys.Resume();
                            msgSys.RemoveButtonUI();
                            msgSys.ReadTextFromResource("Hide");
                            account = account + 12000;
                            string houseNameToRemove = "蒼穹雪夢";
                            int index = draw.IndexOf(houseNameToRemove);
                            box.SetActive(false);
                            if (index != -1)
                            {
                                // 找到子字符串，刪除它及其後面的換行符號
                                draw = draw.Remove(index, houseNameToRemove.Length + 1); // +1 是為了刪除換行符號
                            }
                            source.PlayOneShot(openAudio);
                            msgSys.ReadTextFromResource("交易成功");
                            Account.text = account.ToString();
                            Draw.text = draw;
                        }
                    );
                    msgSys.SetupButtonItem(
                        "DefaultButtonItemPrefab",
                        "13,000",
                        () =>
                        {
                            msgSys.Resume();
                            msgSys.RemoveButtonUI();
                            msgSys.ReadTextFromResource("Hide");
                            msgSys.ReadTextFromResource("沒有買家購買");
                        }
                    );
                    msgSys.SetupButtonItem(
                        "DefaultButtonItemPrefab",
                        "14,000",
                        () =>
                        {
                            msgSys.Resume();
                            msgSys.RemoveButtonUI();
                            msgSys.ReadTextFromResource("Hide");
                            msgSys.ReadTextFromResource("沒有買家購買");
                        }
                    );

                    break;
            }
            progress++;
        }

        if (!isSign)
        {
            msgSys.ReadTextFromResource("Hide");
            progress = 0;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Continue the messages, stoping by [w] or [lr] keywords.
            msgSys.Next();
        }
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
        }
    }
}
