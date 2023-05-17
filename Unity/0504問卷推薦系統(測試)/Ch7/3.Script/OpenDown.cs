using UnityEngine;

//附加音效播放器組件
[RequireComponent(typeof(AudioSource))]
public class OpenDown : MonoBehaviour
{

    public AudioClip openAudio;//開啟音效
    public AudioClip downAudio;//關閉音效

    bool open;
    float openTime = 1.5f;
    float curTime = -2;

    Animator anim;
    AudioSource source;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    void Switch()
    {
        if (Time.time < curTime + openTime)
            return;

        curTime = Time.time;
        open = !open;
        if (open)
        {//開啟
            anim.Play("open");
            source.PlayOneShot(openAudio);
        }
        else
        {//關閉
            anim.Play("down");
            source.PlayOneShot(downAudio);
        }
    }
}
