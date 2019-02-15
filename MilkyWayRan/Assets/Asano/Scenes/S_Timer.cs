using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Timer : MonoBehaviour
{
    //画像管理
    public GameObject ST;   //星をまとめたオブジェクト
    public bool s_timer=false;    //切り替え

    //星画像
    public Image t_star1;
    public Image t_star2;
    public Image t_star3;
    public Image t_star4;
    public Image t_star5;
    public Image t_star6;

    public Text s_timerText;//表示テキスト
    void Start()
    {
        //テキスト参照
        s_timerText = GetComponentInChildren<Text>();
        if (s_timer == false)
        {
            ST.gameObject.SetActive(false);
        }

    }
    void Update()
    {
        
        if (s_timerText.text == "START!")
        {
            s_timer = true;
        }
        if (s_timer == true)
        {
            ST.SetActive(true);
        }
    }
}
