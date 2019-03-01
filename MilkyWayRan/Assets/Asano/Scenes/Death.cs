using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    //必殺技ゲージ＝必殺技と連動

    public Image death; //画像
    public float PP=0.2f;

    //Playerの必殺技を取得するため、Playerを入れればおｋ
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        death = GetComponent<Image>();
        death.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ここで取得
        int Specialcount = gameObject.GetComponent<Hisatu>().Special;
        

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
}
