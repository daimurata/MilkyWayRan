using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public Image death; //画像
    public Sprite Free; //通常時
    public Sprite Max;  //MAX時
    public bool flg = false;
    public float PP=0.2f;

    // Start is called before the first frame update
    void Start()
    {
        death = GetComponent<Image>();
        death = this.GetComponent<Image>();
        death.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //減る
        if (Input.GetKeyDown(KeyCode.D))
        {
            death.fillAmount -= 1.0f / PP * 0.02f;
        }
        //増える
        if (Input.GetKeyDown(KeyCode.S))
        {
            death.fillAmount += 1.0f / PP * 0.02f;
        }

        //MAX時の処理
        if(death.fillAmount >= 1)
        {
            MaxDeath();
        }
        else
        {
            flg = false;
            death.sprite = Free;
        }
    }
    void MaxDeath()
    {
        flg = true;
        if(flg == true)
        {
            Image death = GetComponent<Image>();
            death.sprite = Max;

            Attack();
        }
    }
    void Attack()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            //必殺技の処理

            //使用後ゲージ０
            death.fillAmount = 0;
        }
    }
}
