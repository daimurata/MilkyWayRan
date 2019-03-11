using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// タイトル移動コントローラー
/// </summary>
public class Title_btn : MonoBehaviour
{

    Fade Fade;

    void Start()
    {
        
    }

    void Update()
    {
        //コントローラ処理
        St_1P();
        St_2P();
        St_3P();
        St_4P();
    }

    //1Pコントローラー
    public void St_1P()
    {
        //コントローラー処理1P
        if (Input.GetButtonDown("PlayerLoad_Game1"))
        {
            //ゲーム画面へ
            Fade.Sen_Game();
        }
    }
    //2Pコントローラー
    public void St_2P()
    {
        //コントローラー処理2P
        if (Input.GetButtonDown("PlayerLoad_Game2"))
        {
            //ゲーム画面へ
            Fade.Sen_Game();
        }
    }
    //3Pコントローラー
    public void St_3P()
    {
        //コントローラー処理3P
        if (Input.GetButtonDown("PlayerLoad_Game3"))
        {
            //ゲーム画面へ
            Fade.Sen_Game();
        }
    }
    //4Pコントローラー
    public void St_4P()
    {
        //コントローラー処理4P
        if (Input.GetButtonDown("PlayerLoad_Game4"))
        {
            //ゲーム画面へ
            Fade.Sen_Game();
        }
    }
}
