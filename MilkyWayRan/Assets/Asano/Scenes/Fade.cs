using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//フェード遷移
public class Fade : MonoBehaviour
{
    float fadeSpeed = 0.02f;        //透明度が変わるスピードを管理
    float red, green, blue, alfa=0;   //パネルの色、不透明度を管理

    public static bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
    public static bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

    public Image fadeImage;                //透明度を変更するパネルのイメージ

    public string[] NextSceneName =new string[6];//シーン移動

    public static bool[] Secne_Go = new bool[6];//シーンを分岐

   // public static bool[] SecneOK = new bool[2];//シーンを連続飛びしない

    public static bool GOTO=true;//連続処理防止
    //1個のみ
    public static Fade Instance
    {
        get;private set;
    }

    void Awake()
    {
        //もしインスタンスが複数存在するなら、自らを破壊する
        if (Instance !=null)
        {
            //消える
            Destroy(this);
            //繰り返す
            return;
        }
        //シングルトン
        Instance = this;

        //消えないようにする
        DontDestroyOnLoad(this);
    }

    void Start()
    { 
        //fadeImage = GetComponent<Image>();
        //参照
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;

        //シーン移動処理分け
        Secne_Go[0] = false;//タイトルシーン
        Secne_Go[1] = false;//メインシーン
        Secne_Go[2] = false;//1
        Secne_Go[3] = false;//2
        Secne_Go[4] = false;//3
        Secne_Go[5] = false;//4

        //シーンを連続呼び防止
        //ゲームに行くため
       // SecneOK[0] = true;
        //SecneOK[1] = false;
    }

    void Update()
    {
        //trueなら
        if (isFadeIn)
        {
            //フェードイン（画像）
            StartFadeIn();
        }

        //trueなら
        if (isFadeOut)
        {
            //フェードアウト（画像）
            StartFadeOut();
        }
        //FadeOption();
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            Sen_Titl();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Sen_Game();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Sen_Result();
        }*/

    }

    /// <summary>
    /// フェードイン（画像）
    /// </summary>
    void StartFadeIn()
    {
        alfa -= fadeSpeed;                //不透明度を徐々に下げる
        SetAlpha();                      //変更した不透明度パネルに反映する
        //アルファ値が０以下
        if (alfa <= 0)
        {
            //完全に透明になったら処理を抜ける
            //ファードイン終了
            isFadeIn = false;
            fadeImage.enabled = false;    //パネルの表示をオフにする
            GOTO = true;
        }
    }

    /// <summary>
    /// フェードアウト（画像）
    /// </summary>
    void StartFadeOut()
    {
        fadeImage.enabled = true;  // パネルの表示をオンにする
        alfa += fadeSpeed;         // 不透明度を徐々にあげる
        SetAlpha();               // 変更した透明度をパネルに反映する
        //アルファーが1以上
        if (alfa >= 1)
        {
            //タイトルへ
            if (Secne_Go[0])
            {
                // 完全に不透明になったら処理を抜ける
                //フェードアウト終了
                isFadeOut = false;
                //シーン遷移タイトル
                SceneManager.LoadScene(NextSceneName[0]);
                //フェードインする
                isFadeIn = true;
                //終了
                Secne_Go[0] = false;
                //タイトル移動可能
                //SecneOK[0] = true;
            }
            //ゲームへ
            if (Secne_Go[1])
            {
                // 完全に不透明になったら処理を抜ける
                //フェードアウト終了
                isFadeOut = false;
                //シーン遷移タイトル
                SceneManager.LoadScene(NextSceneName[1]);
                //フェードインする
                isFadeIn = true;
                //終了
                Secne_Go[1] = false;
            }
            //リザルトへ
            if (Secne_Go[2])
            {
                // 完全に不透明になったら処理を抜ける
                //フェードアウト終了
                isFadeOut = false;
                //シーン遷移タイトル
                SceneManager.LoadScene(NextSceneName[2]);
                //フェードインする
                isFadeIn = true;
                //終了
                Secne_Go[2] = false;

                /*
                //タイトル移動可能
                SecneOK[0] = true;
                //ゲーム移動可能
                SecneOK[1] = true;
                */
            }
            if (Secne_Go[3])
            {
                // 完全に不透明になったら処理を抜ける
                //フェードアウト終了
                isFadeOut = false;
                //シーン遷移タイトル
                SceneManager.LoadScene(NextSceneName[3]);
                //フェードインする
                isFadeIn = true;
                //終了
                Secne_Go[3] = false;

                /*
                //タイトル移動可能
                SecneOK[0] = true;
                //ゲーム移動可能
                SecneOK[1] = true;
                */
            }
            if (Secne_Go[4])
            {
                // 完全に不透明になったら処理を抜ける
                //フェードアウト終了
                isFadeOut = false;
                //シーン遷移タイトル
                SceneManager.LoadScene(NextSceneName[4]);
                //フェードインする
                isFadeIn = true;
                //終了
                Secne_Go[4] = false;

                /*
                //タイトル移動可能
                SecneOK[0] = true;
                //ゲーム移動可能
                SecneOK[1] = true;
                */
            }
            if (Secne_Go[5])
            {
                // 完全に不透明になったら処理を抜ける
                //フェードアウト終了
                isFadeOut = false;
                //シーン遷移タイトル
                SceneManager.LoadScene(NextSceneName[5]);
                //フェードインする
                isFadeIn = true;
                //終了
                Secne_Go[5] = false;

                /*
                //タイトル移動可能
                SecneOK[0] = true;
                //ゲーム移動可能
                SecneOK[1] = true;
                */
            }
        }
    }

    /// <summary>
    /// 画像反映
    /// </summary>
    void SetAlpha()
    {
        //RGBA
        fadeImage.color = new Color(red, green, blue, alfa);
    }
    /*
    /// <summary>
    /// フェードを行うコントローラー（手動処理）
    /// </summary>
    public void FadeOption()
    {
        //コントローラー1P
        Controller_1P();

        //コントローラー2P
        Controller_2P();

        //コントローラー3P
        Controller_3P();

        //コントローラー4P
        Controller_4P();
    }

    /// <summary>
    /// コントローラ処理1P
    /// </summary>
    public void Controller_1P()
    {
        //キー移動　タイトルへ　手動
        if (Input.GetButton("PlayerLoad_Title1") && SecneOK[0] == true)//中島Buttonスクリプト参照
        {
            //シーン移動先タイトル
            Secne_Go[0] = true;

            //フェードの処理
            isFadeOut = true;

            //ゲーム中に遷移しない処理
            SecneOK[0] = false;
        }
        //キー移動　ゲームへ　手動
        if (Input.GetButton("PlayerLoad_Game1") && SecneOK[1] == true)//中島Buttonスクリプト参照
        {
            //シーン移動先ゲーム
            Secne_Go[1] = true;

            //フェードの処理
            isFadeOut = true;

            //ゲーム中に遷移しない処理
            SecneOK[1] = false;
        }
    }
    /// <summary>
    /// コントローラ処理2P
    /// </summary>
    public void Controller_2P()
    {
        //キー移動　タイトルへ　手動
        if (Input.GetButton("PlayerLoad_Title2") && SecneOK[0] == true)//中島Buttonスクリプト参照
        {
            //シーン移動先タイトル
            Secne_Go[0] = true;

            //フェードの処理
            isFadeOut = true;

            //ゲーム中に遷移しない処理
            SecneOK[0] = false;
        }
        //キー移動　ゲームへ　手動
        if (Input.GetButton("PlayerLoad_Game2") && SecneOK[1] == true)//中島Buttonスクリプト参照
        {
            //シーン移動先ゲーム
            Secne_Go[1] = true;

            //フェードの処理
            isFadeOut = true;

            //ゲーム中に遷移しない処理
            SecneOK[1] = false;
        }
    }
    /// <summary>
    /// コントローラ処理3P
    /// </summary>
    public void Controller_3P()
    {
        //キー移動　タイトルへ　手動
        if (Input.GetButton("PlayerLoad_Title3") && SecneOK[0] == true)//中島Buttonスクリプト参照
        {
            //シーン移動先タイトル
            Secne_Go[0] = true;

            //フェードの処理
            isFadeOut = true;

            //ゲーム中に遷移しない処理
            SecneOK[0] = false;
        }
        //キー移動　ゲームへ　手動
        if (Input.GetButton("PlayerLoad_Game3") && SecneOK[1] == true)//中島Buttonスクリプト参照
        {
            //シーン移動先ゲーム
            Secne_Go[1] = true;

            //フェードの処理
            isFadeOut = true;

            //ゲーム中に遷移しない処理
            SecneOK[1] = false;
        }
    }
    /// <summary>
    /// コントローラ処理4P
    /// </summary>
    public void Controller_4P()
    {
        //キー移動　タイトルへ　手動
        if (Input.GetButton("PlayerLoad_Title4") && SecneOK[0] == true)//中島Buttonスクリプト参照
        {
            //シーン移動先タイトル
            Secne_Go[0] = true;

            //フェードの処理
            isFadeOut = true;

            //ゲーム中に遷移しない処理
            SecneOK[0] = false;
        }
        //キー移動　ゲームへ　手動
        if (Input.GetButton("PlayerLoad_Game4") && SecneOK[1] == true)//中島Buttonスクリプト参照
        {
            //シーン移動先ゲーム
            Secne_Go[1] = true;

            //フェードの処理
            isFadeOut = true;

            //ゲーム中に遷移しない処理
            SecneOK[1] = false;
        }
    }
    */
    //呼ばれたらタイトルシーンへ移動　自動
    public static void Sen_Titl()
    {
        if (GOTO==true)
        {
            GOTO = false;
            if (GOTO==false)
            {
                //シーン移動先　タイトル
                Secne_Go[0] = true;
                //フェードの処理
                isFadeOut = true;
            }
        }

    }

    public static void Sen_Game()
    {
        if (GOTO == true)
        {
            GOTO = false;
            if (GOTO == false)
            {
                //シーン移動先 ゲーム
                Secne_Go[1] = true;
                //フェードの処理
                isFadeOut = true;
            }
        }
    }

    //呼ばれたらリザルトシーンへ移動　自動
    public static void Sen_Result(int PNum)//一番HPの多いプレイヤーの番号を受け取る
    {
        if (GOTO == true)
        {
            GOTO = false;
            if (GOTO == false)
            {
                //シーン移動先　リザルト
                //番号＋１で無理やりScene_Go
                Secne_Go[PNum += 1] = true;
                //フェードの処理
                isFadeOut = true;
            }
        }
    }
}
