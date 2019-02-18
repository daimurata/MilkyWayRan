using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnTitle : MonoBehaviour
{
    //ボタン
    public GameObject bottons;
    //シーン名
    public string Titru;
   //ボタンをクリックしたら
    public void OnClick()
    {
        //タイトルにシーン遷移
        SceneManager.LoadScene(Titru);
    }
    // Start is called before the first frame updat
    void Start()
    {
        
        
    }
    void Update()
    {
        //ボタンのSetActiveがtrueなら
        if (bottons.activeSelf)
        {
            //3分間何もしなかったらタイトルに遷移するようにする
            Invoke("ReTitleSeni", 180.0f);
        }
    }
    // Update is called once per frame
    //タイトルに強制遷移する
    void ReTitleSeni()
    {
        SceneManager.LoadScene(Titru);
    }
}
