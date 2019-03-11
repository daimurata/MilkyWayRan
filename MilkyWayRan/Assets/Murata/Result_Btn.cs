using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// リザルトのボタン処理
/// </summary>
public class Result_Btn : MonoBehaviour
{
    //リザルトボタン
    public Image[] Rett_Btn = new Image[2];

    //シーン名
    public string[] Go_Scene_Name = new string[2];

    //表示タイム
    public float Bt_tim = 5;

    //タイトル行く
    public bool[] Ply_Title = new bool[4];

    //ゲームへ行く
    public bool[] Ply_Game = new bool[4];

    //シーンへ移動するタイム
    public float Secn_Time=10;

    //120秒設定
    public float GOGOTitle = 120f;

    //アルファ値
    public float[] btn_a =new float[2];

    //Fadeを参照
    Fade Fade;
    void Start()
    {
        //初期設定
        SetOption();
    }
    void Update()
    {
        //タイトル選択
        Plyer_Title();
        //ゲーム選択
        Plyer_Game();

        //強制でタイトルへ
        GotoTitle();
        //表示
        Set_OK();
    }
    //初期設定
    public void SetOption()
    {
        //α値を同じに
        btn_a[0] = Rett_Btn[0].color.a;
        btn_a[1] = Rett_Btn[1].color.a;

        //αを0に
        btn_a[0] = 0;
        btn_a[1] = 0;


        //ボタンオブジェクト非表示（タイトル）（ゲーム）
        Rett_Btn[0].enabled=false;
        Rett_Btn[1].enabled=false;

        //タイトル行く&&ゲームへ行く　false  1P～4P
        Ply_Title[0] = false;
        Ply_Title[1] = false;
        Ply_Title[2] = false;
        Ply_Title[3] = false;

        Ply_Game[0] = false;
        Ply_Game[1] = false;
        Ply_Game[2] = false;
        Ply_Game[3] = false;

    }

    //文字表示
    public void Set_OK()
    {
        //表示するまでカウントダウン
        Bt_tim -= Time.deltaTime;

        //0以下になったら
        if (Bt_tim<=0)
        {
            //αを加算
            btn_a[0] += 0.02f;
            btn_a[1] += 0.02f;
            //反映
            Rett_Btn[0].color = new Color(255, 255, 255, btn_a[0]);
            Rett_Btn[1].color = new Color(255, 255, 255, btn_a[1]);
            //表示する
            Rett_Btn[0].enabled = true;
            Rett_Btn[1].enabled = true;
            if (btn_a[0]>=1&&btn_a[1]>=1)
            {
                //αを固定
                btn_a[0] = 2;
                btn_a[1] = 2;

                //タイトル行きます
                Go_Title();
                //ゲーム行きます
                Go_Game();

                //-1にする
                Bt_tim = -1;
            }
        }
    }

    //タイトルへコントローラーキー〇
    public void Plyer_Title()
    {
        //1P
        if (Input.GetButtonDown("PlayerLoad_Title1"))
        {
            //タイトル行きたい
            Ply_Title[0] = true;
            //ゲーム行かない
            Ply_Game[0] = false;
            //タイムのリセット
            Secn_Time = 10;
        }
        //2P
        if (Input.GetButtonDown("PlayerLoad_Title2"))
        {
            //タイトル行きたい
            Ply_Title[1] = true;
            //ゲーム行かない
            Ply_Game[1] = false;
            //タイムのリセット
            Secn_Time = 10;
        }
        //3P
        if (Input.GetButtonDown("PlayerLoad_Title3"))
        {
            //タイトル行きたい
            Ply_Title[2] = true;
            //ゲーム行かない
            Ply_Game[2] = false;
            //タイムのリセット
            Secn_Time = 10;
        }
        //4P
        if (Input.GetButtonDown("PlayerLoad_Title4"))
        {
            //タイトル行きたい
            Ply_Title[3] = true;
            //ゲーム行かない
            Ply_Game[3] = false;
            //タイムのリセット
            Secn_Time = 10;
        }
    }
    //ゲームへコントローラーキー×
    public void Plyer_Game()
    {
        //1P
        if (Input.GetButtonDown("PlayerLoad_Game1"))
        {
            //ゲーム行きたい
            Ply_Game[0] = true;
            // タイトル行かない
            Ply_Title[0] = false;
            //タイムのリセット
            Secn_Time = 10;
        }
        //2P
        if (Input.GetButtonDown("PlayerLoad_Game2"))
        {
            //ゲーム行きたい
            Ply_Game[1] = true;
            // タイトル行かない
            Ply_Title[1] = false;
            //タイムのリセット
            Secn_Time = 10;
        }
        //3P
        if (Input.GetButtonDown("PlayerLoad_Game3"))
        {
            //ゲーム行きたい
            Ply_Game[2] = true;
            // タイトル行かない
            Ply_Title[2] = false;
            //タイムのリセット
            Secn_Time = 10;
        }
        //4P
        if (Input.GetButtonDown("PlayerLoad_Game4"))
        {
            //ゲーム行きたい
            Ply_Game[3] = true;
            // タイトル行かない
            Ply_Title[3] = false;
            //タイムのリセット
            Secn_Time = 10;
        }
    }

    //タイトル移動
    public void Go_Title()
    {
        //タイマーを減らす
        Secn_Time -= Time.deltaTime;
        //0以下なら
        if (Secn_Time <= 0)
        {
            //全員がタイトルへ
            if (Ply_Title[0] && Ply_Title[1] && Ply_Title[2] && Ply_Title[3])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //1P～3P
            if (Ply_Title[0] && Ply_Title[1] && Ply_Title[2])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //1P、2P、4P
            if (Ply_Title[0] && Ply_Title[1] && Ply_Title[3])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //1P、3P、4P
            if (Ply_Title[0] && Ply_Title[2] && Ply_Title[3])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //2P～4P
            if (Ply_Title[1] && Ply_Title[2] && Ply_Title[3])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //1P、2P
            if (Ply_Title[0] && Ply_Title[1])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //1P、3P
            if (Ply_Title[0] && Ply_Title[2])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //1P、4P
            if (Ply_Title[0] && Ply_Title[3])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //2P、3P
            if (Ply_Title[1] && Ply_Title[2])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //2P、4P
            if (Ply_Title[1] && Ply_Title[3])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //3P、4P
            if (Ply_Title[2] && Ply_Title[3])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //1P
            if (Ply_Title[0])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //2P
            if (Ply_Title[1])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //3P
            if (Ply_Title[2])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //4P
            if (Ply_Title[3])
            {
                //タイトルシーンへ
                Title_Scen();
            }
            //0にする
            Secn_Time = 0;
        }
    }
    //ゲーム移動
    public void Go_Game()
    {
        //タイマーを減らす
        Secn_Time -= Time.deltaTime;
        //0以下なら
        if (Secn_Time <= 0)
        {
            //全員がゲームへ
            if (Ply_Game[0] && Ply_Game[1] && Ply_Game[2] && Ply_Game[3])
            {
                //ゲームシーンへ
                Game_Scen();
            }
            //1P～3P
            if (Ply_Game[0] && Ply_Game[1] && Ply_Game[2])
            {
                //ゲームシーンヘ
                Game_Scen();
            }
            //1P、2P、4P
            if (Ply_Game[0] && Ply_Game[1] && Ply_Game[3])
            {
                //ゲームシーンヘ
                Game_Scen();
            }
            //1P、3P、4P
            if (Ply_Game[0] && Ply_Game[2] && Ply_Game[3])
            {
                //ゲームシーンヘ
                Game_Scen();
            }
            //2P、3P、4P
            if (Ply_Game[1] && Ply_Game[2] && Ply_Game[3])
            {
                //ゲームシーンヘ
                Game_Scen();
            }
            //1P,2P
            if (Ply_Game[0] && Ply_Game[1])
            {
                //ゲームシーンヘ
                Game_Scen();
            }
            //1P、3P
            if (Ply_Game[0] && Ply_Game[2])
            {
                //ゲームシーンヘ
                Game_Scen();
            }
            //1P、4P
            if (Ply_Game[0] && Ply_Game[3])
            {
                //ゲームシーンヘ
                Game_Scen();
            }
            //2P、3P
            if (Ply_Game[1] && Ply_Game[2])
            {
                //ゲームシーンヘ
                Game_Scen();
            }
            //2P、4P
            if (Ply_Game[1] && Ply_Game[3])
            {
                //ゲームシーンヘ
                Game_Scen();
            }
            //3P、4P
            if (Ply_Game[2] && Ply_Game[3])
            {
                //ゲームシーンヘ
                Game_Scen();
            }
            //1P
            if (Ply_Game[0])
            {
                //ゲームシーンヘ
                Game_Scen();
            }
            //2P
            if (Ply_Game[1])
            {
                //ゲームシーンヘ
                Game_Scen();
            }
            //3P
            if (Ply_Game[2])
            {
                //ゲームシーンヘ
                Game_Scen();
            }
            //4P
            if (Ply_Game[3])
            {
                //ゲームシーンヘ
                Game_Scen();
            }
            //0にする
            Secn_Time = 0;
        }
    }

    //シーン強制タイトルへ
    public void GotoTitle()
    {
        //カウントダウン強制タイトルへ
        GOGOTitle -= Time.deltaTime;
        //0以下なら
        if (GOGOTitle<=0)
        {
            //タイトルへ
            Title_Scen();
            //0にする
            GOGOTitle = 0;
        }
    }


    //シーン移動タイトル
    public void Title_Scen()
    {
        //タイトル
        Fade.Sen_Titl();
    }
    //シーン移動ゲーム
    public void Game_Scen()
    {
        //ゲーム
        Fade.Sen_Game();
    }
}
