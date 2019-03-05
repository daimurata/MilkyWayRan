using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    //必殺技ゲージ＝必殺技と連動

    public Image death; //画像
    //public float PP=0.2f;

    //Playerの必殺技を取得するため、Playerを入れればおｋ
    public Hisatu hisatu;

    //bool One;

    // Start is called before the first frame update
    void Start()
    {
        death = GetComponent<Image>();
        death.fillAmount = 0;
        //One = true;
    }
    // Update is called once per frame
    void Update()
    {
        //if (One)
        //{
        //    int SPcount = hisatu.Special;
        //    death.fillAmount += SPcount * 0.1f;
        //    One = false;
        //    Invoke("isOne", 0.1f);
        //}
        
        
        ////減る
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    death.fillAmount -= 1.0f / PP * 0.02f;
        //}
        ////増える
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    death.fillAmount += 1.0f / PP * 0.02f;
        //}
    }
    public void isOne()
    {
        //One = true;
    }
    public void Gage(int gage)
    {
        death.fillAmount += gage * 0.1f;
    }
    public void Gage0()
    {
        death.fillAmount = 0;
    }
}
