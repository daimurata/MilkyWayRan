using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Timer : MonoBehaviour
{
    public Image s_timerText;//表示テキスト
    public float minute = 3.0f;//スタートカウント
    public float mainminute = 10.0f;//ゲームカウント
    public bool Sta_Mai = false;//切り替えスタート＆メイン
    int Seconds;//変換
    public float interval = 1.0f;//インターバル
    public string NextSceneName;//シーン名

    //星画像
    public Image t_star1;
    public Image t_star2;
    public Image t_star3;
    public Image t_star4;
    public Image t_star5;
    public Image t_star6;

    //時間
    private float count1;
    private float count2;
    private float count3;
    private float count4;
    private float count5;
    private float count6;

    //点滅速度
    private float Step1 = 0.033f;
    private float Step2 = 0.033f;
    private float Step3 = 0.033f;
    private float Step4 = 0.033f;
    private float Step5 = 0.033f;
    private float Step6 = 0.033f;

    //Playerを1~4までいれる
    public GameObject playerMove1;
    public GameObject playerMove2;
    public GameObject playerMove3;
    public GameObject playerMove4;

    //一番HPの多いプレイヤー番号を入れる変数
    private int TopNum;

    void Start()
    {
        //テキスト参照
        s_timerText = GetComponentInChildren<Image>();
        //わざとtrue
        Sta_Mai = true;

        //メインカウント初期値
        count1 = 12;
        count2 = 12;
        count3 = 12;
        count4 = 12;
        count5 = 12;
        count6 = 12;
    }

    void Update()
    {
        //配列を入れてるメソッドの呼び出し
        Info();
        //時間制限内でプレイヤーが1人になった際にシーン移動させるためのメソッド
        LastPlayerNum();


        //押されたら
        if (Input.GetKeyDown(KeyCode.A))
        {
            Sta_Mai = false;
        }
        //スタート
        TimeCount_False();
        //メイン
        TimeCount_True();
    }
    //メインtimeの表示切替

    //スタートです
    public void TimeCount_False()
    {
        //スタートカウントダウン
        if (Sta_Mai == false)
        {
            //スタートカウントダウン開始
            minute -= Time.deltaTime;
            //int型に直すよ
            Seconds = (int)minute;
            //テキストに反映するよ
            //Image s_timerText_compornent = s_timerText.GetCompornent<Image>();

            //minuteが０になるまでやる
            if (minute <= 0)
            {
                //minuteを０で止めるよ！
                minute = 0f;
                //メインに行ける
                Sta_Mai = true;
            }
        }
        //minuteが1になったら表示
        if (minute <= 1)
        {
            //スタートを表示
            //s_timerText.text = "START!";
            interval -= Time.deltaTime;
        }


    }
    //メインです
    public void TimeCount_True()
    {
        //メインカウントダウン
        if (Sta_Mai == true && interval <= 0)
        {
            interval = 0.0f;
            Destroy(s_timerText);
            Star1();

            //--------------

            //メインのカウントダウン準備
            //if (mainminute == 10.0f)
            //{
            //    //textの更新
            //    s_timerText.text = mainminute.ToString("00");


            //}


            //カウントダウン開始
            //mainminute -= Time.deltaTime;
            ////int型に直すよ
            //Seconds = (int)mainminute;
            ////テキストに反映するよ
            //s_timerText.text = Seconds.ToString();

            //mainminuteが０までやる
            //if (mainminute <= 0)
            //{
            //    //mainminuteを０にする
            //    mainminute = 0;
            //    //シーン移動
            //    SceneGoto();
            //}
            //--------------

        }
    }
    //星が点滅する処理を書いて
    public void Star1()
    {
        count1 -= Time.deltaTime;

        //現在のアルファ値を取得
        float toColor = t_star1.GetComponent<Image>().color.a;
        //アルファが 0　または 1 なったら増減値を反転
        if (toColor < 0 || toColor > 1)
        {
            Step1 = Step1 * -1;
        }
        //アルファ値を反映
        t_star1.GetComponent<Image>().color = new Color(255, 255, 255, toColor + Step1);

        //カウント０で終了
        if (count1 <= 0)
        {
            count1 = 0;
            Step1 = 0;
            t_star1.GetComponent<Image>().color = new Color(0, 0, 0 + Step1);
            Star2();
        }
    }
    public void Star2()
    {
        count2 -= Time.deltaTime;
        //現在のアルファ値を取得
        float toColor = t_star2.GetComponent<Image>().color.a;
        //アルファが 0　または 1 なったら増減値を反転
        if (toColor < 0 || toColor > 1)
        {
            Step2 = Step2 * -1;
        }
        //アルファ値を反映
        t_star2.GetComponent<Image>().color = new Color(255, 255, 255, toColor + Step2);

        //カウント０で終了
        if (count2 <= 0)
        {
            count2 = 0;
            Step2 = 0;
            t_star2.GetComponent<Image>().color = new Color(0, 0, 0 + Step2);
            Star3();
        }
    }
    public void Star3()
    {
        count3 -= Time.deltaTime;
        //現在のアルファ値を取得
        float toColor = t_star3.GetComponent<Image>().color.a;
        //アルファが 0　または 1 なったら増減値を反転
        if (toColor < 0 || toColor > 1)
        {
            Step3 = Step3 * -1;
        }
        //アルファ値を反映
        t_star3.GetComponent<Image>().color = new Color(255, 255, 255, toColor + Step3);

        //カウント０で終了
        if (count3 <= 0)
        {
            count3 = 0;
            Step3 = 0;
            t_star3.GetComponent<Image>().color = new Color(0, 0, 0 + Step3);
            Star4();
        }
    }
    public void Star4()
    {
        count4 -= Time.deltaTime;
        //現在のアルファ値を取得
        float toColor = t_star4.GetComponent<Image>().color.a;
        //アルファが 0　または 1 なったら増減値を反転
        if (toColor < 0 || toColor > 1)
        {
            Step4 = Step4 * -1;
        }
        //アルファ値を反映
        t_star4.GetComponent<Image>().color = new Color(255, 255, 255, toColor + Step4);

        //カウント０で終了
        if (count4 <= 0)
        {
            count4 = 0;
            Step4 = 0;
            t_star4.GetComponent<Image>().color = new Color(0, 0, 0 + Step4);
            Star5();
        }
    }
    public void Star5()
    {
        count5 -= Time.deltaTime;
        //現在のアルファ値を取得
        float toColor = t_star5.GetComponent<Image>().color.a;
        //アルファが 0　または 1 なったら増減値を反転
        if (toColor < 0 || toColor > 1)
        {
            Step5 = Step5 * -1;
        }
        //アルファ値を反映
        t_star5.GetComponent<Image>().color = new Color(255, 255, 255, toColor + Step5);

        //カウント０で終了
        if (count5 <= 0)
        {
            count5 = 0;
            Step5 = 0;
            t_star5.GetComponent<Image>().color = new Color(0, 0, 0 + Step5);
            Star6();
        }
    }
    public void Star6()
    {
        count6 -= Time.deltaTime;
        //現在のアルファ値を取得
        float toColor = t_star6.GetComponent<Image>().color.a;
        //アルファが 0　または 1 なったら増減値を反転
        if (toColor < 0 || toColor > 1)
        {
            Step6 = Step6 * -1;
        }
        //アルファ値を反映
        t_star6.GetComponent<Image>().color = new Color(255, 255, 255, toColor + Step6);

        //カウント０で終了
        if (count6 <= 0)
        {
            count6 = 0;
            Step6 = 0;
            t_star6.GetComponent<Image>().color = new Color(0, 0, 0 + Step6);

            //シーン移動
            SceneGoto();
        }
    }

    //シーン移動してくれます。
    public void SceneGoto()
    {
        //シーン移動処理
        //シーン名＋番号でシーン移動する場所を決める
        //シーン名の最後に番号を入れてほしい１～４まで、そうすればTopNumに合わせて呼び出されるシーンが変更されると思う
        SceneManager.LoadScene(NextSceneName+TopNum);       
    }
    public void Info()//配列を入れてるメソッド
    {
        //HPの変数
        var PName1 = playerMove1;
        int PHp1 = PName1.GetComponent<PlayerMove>().PlayerHP;
        var PName2 = playerMove2;
        int PHp2 = PName2.GetComponent<PlayerMove>().PlayerHP;
        var PName3 = playerMove3;
        int PHp3 = PName3.GetComponent<PlayerMove>().PlayerHP;
        var PName4 = playerMove4;
        int PHp4 = PName4.GetComponent<PlayerMove>().PlayerHP;

        //Nameがプレイヤー番号、PHpがそのプレイヤーのHP
        var src = new[]
        {
            new {Name = 1,HP = PHp1 },
            new {Name = 2,HP = PHp2 },
            new {Name = 3,HP = PHp3 },
            new {Name = 4,HP = PHp4 },
        };

        //HPが降順
        var orderByDescendingList = src.OrderByDescending(x => x.HP).ToList();
    
        //多分HPが一番多いプレイヤーの番号が入っていると思う
        TopNum = orderByDescendingList[0].Name;

        //一番HPの多いPlayerの名前とHPを表示
        //Debug.Log(orderByDescendingList[0].Name + "のHPが" + orderByDescendingList[0].HP);
    }

    public void LastPlayerNum()//最後に残ったプレイヤーを判別するメソッド
    {
        //シーン名の後にTopNumが入っていないのはきちんとそのシーンに移動しているか判別するため
        //1Pの勝利判定
        //SetActiveが1P以外Falseの場合1Pの勝利にしてシーン移動させる
        if (playerMove2.activeSelf == false && playerMove3.activeSelf == false && playerMove4.activeSelf == false)
        {
            SceneManager.LoadScene(NextSceneName + 1);
        }
        //2Pの勝利判定
        //SetActiveが2P以外Falseの場合2Pの勝利にしてシーン移動させる
        if (playerMove1.activeSelf == false && playerMove3.activeSelf == false && playerMove4.activeSelf == false)
        {
            SceneManager.LoadScene(NextSceneName + 2);
        }
        //3Pの勝利判定
        //SetActiveが3P以外Falseの場合3Pの勝利にしてシーン移動させる
        if (playerMove1.activeSelf == false && playerMove2.activeSelf == false && playerMove4.activeSelf == false)
        {
            SceneManager.LoadScene(NextSceneName + 3);
        }
        //4Pの勝利判定
        //SetActiveが4P以外Falseの場合4Pの勝利にしてシーン移動させる
        if (playerMove1.activeSelf == false && playerMove2.activeSelf == false && playerMove3.activeSelf == false)
        {
            SceneManager.LoadScene(NextSceneName + 4);
        }
    }
}
//public class Timer : MonoBehaviour
//{
//    public Text s_timerText;//表示テキスト
//    public float minute = 3.0f;//スタートカウント
//    public float mainminute = 10.0f;//ゲームカウント
//    public bool Sta_Mai = false;//切り替えスタート＆メイン
//    int Seconds;//変換
//    public float interval = 1.0f;//インターバル
//    public string NextSceneName;//シーン名

//    //星画像
//    public Image t_star1;
//    public Image t_star2;
//    public Image t_star3;
//    public Image t_star4;
//    public Image t_star5;
//    public Image t_star6;

//    //時間
//    private float count1;
//    private float count2;
//    private float count3;
//    private float count4;
//    private float count5;
//    private float count6;

//    //点滅速度
//    private float Step1 = 0.033f;
//    private float Step2 = 0.033f;
//    private float Step3 = 0.033f;
//    private float Step4 = 0.033f;
//    private float Step5 = 0.033f;
//    private float Step6 = 0.033f;
//    void Start()
//    {
//        //テキスト参照
//        s_timerText = GetComponentInChildren<Text>();
//        //わざとtrue
//        Sta_Mai = true;

//        //メインカウント初期値
//        count1 = 12;
//        count2 = 12;
//        count3 = 12;
//        count4 = 12;
//        count5 = 12;
//        count6 = 12;
//    }

//    void Update()
//    {
//        //押されたら
//        if (Input.GetKeyDown(KeyCode.A))
//        {
//            Sta_Mai = false;
//        }
//        //スタート
//        TimeCount_False();
//        //メイン
//        TimeCount_True();
//    }
//    //メインtimeの表示切替

//    //スタートです
//    public void TimeCount_False()
//    {
//        //スタートカウントダウン
//        if (Sta_Mai == false)
//        {
//            //スタートカウントダウン開始
//            minute -= Time.deltaTime;
//            //int型に直すよ
//            Seconds = (int)minute;
//            //テキストに反映するよ
//            s_timerText.text = Seconds.ToString();

//            //minuteが０になるまでやる
//            if (minute <= 0)
//            {
//                //minuteを０で止めるよ！
//                minute = 0f;
//                //メインに行ける
//                Sta_Mai = true;
//            }
//        }
//        //minuteが1になったら表示
//        if (minute <= 1)
//        {
//            //スタートを表示
//            s_timerText.text = "START!";
//            interval -= Time.deltaTime;
//        }


//    }
//    //メインです
//    public void TimeCount_True()
//    {
//        //メインカウントダウン
//        if (Sta_Mai == true && interval <= 0)
//        {
//            interval = 0.0f;
//            Destroy(s_timerText);
//            Star1();

//            //--------------

//            //メインのカウントダウン準備
//            //if (mainminute == 10.0f)
//            //{
//            //    //textの更新
//            //    s_timerText.text = mainminute.ToString("00");


//            //}


//            //カウントダウン開始
//            //mainminute -= Time.deltaTime;
//            ////int型に直すよ
//            //Seconds = (int)mainminute;
//            ////テキストに反映するよ
//            //s_timerText.text = Seconds.ToString();

//            //mainminuteが０までやる
//            //if (mainminute <= 0)
//            //{
//            //    //mainminuteを０にする
//            //    mainminute = 0;
//            //    //シーン移動
//            //    SceneGoto();
//            //}
//            //--------------

//        }
//    }
//    //星が点滅する処理を書いて
//    public void Star1()
//    {
//        count1 -= Time.deltaTime;

//        //現在のアルファ値を取得
//        float toColor = t_star1.GetComponent<Image>().color.a;
//        //アルファが 0　または 1 なったら増減値を反転
//        if (toColor < 0 || toColor > 1)
//        {
//            Step1 = Step1 * -1;
//        }
//        //アルファ値を反映
//        t_star1.GetComponent<Image>().color = new Color(255, 255, 255, toColor + Step1);

//        //カウント０で終了
//        if (count1 <= 0)
//        {
//            count1 = 0;
//            Step1 = 0;
//            t_star1.GetComponent<Image>().color = new Color(0, 0, 0 + Step1);
//            Star2();
//        }
//    }
//    public void Star2()
//    {
//        count2 -= Time.deltaTime;
//        //現在のアルファ値を取得
//        float toColor = t_star2.GetComponent<Image>().color.a;
//        //アルファが 0　または 1 なったら増減値を反転
//        if (toColor < 0 || toColor > 1)
//        {
//            Step2 = Step2 * -1;
//        }
//        //アルファ値を反映
//        t_star2.GetComponent<Image>().color = new Color(255, 255, 255, toColor + Step2);

//        //カウント０で終了
//        if (count2 <= 0)
//        {
//            count2 = 0;
//            Step2 = 0;
//            t_star2.GetComponent<Image>().color = new Color(0, 0, 0 + Step2);
//            Star3();
//        }
//    }
//    public void Star3()
//    {
//        count3 -= Time.deltaTime;
//        //現在のアルファ値を取得
//        float toColor = t_star3.GetComponent<Image>().color.a;
//        //アルファが 0　または 1 なったら増減値を反転
//        if (toColor < 0 || toColor > 1)
//        {
//            Step3 = Step3 * -1;
//        }
//        //アルファ値を反映
//        t_star3.GetComponent<Image>().color = new Color(255, 255, 255, toColor + Step3);

//        //カウント０で終了
//        if (count3 <= 0)
//        {
//            count3 = 0;
//            Step3 = 0;
//            t_star3.GetComponent<Image>().color = new Color(0, 0, 0 + Step3);
//            Star4();
//        }
//    }
//    public void Star4()
//    {
//        count4 -= Time.deltaTime;
//        //現在のアルファ値を取得
//        float toColor = t_star4.GetComponent<Image>().color.a;
//        //アルファが 0　または 1 なったら増減値を反転
//        if (toColor < 0 || toColor > 1)
//        {
//            Step4 = Step4 * -1;
//        }
//        //アルファ値を反映
//        t_star4.GetComponent<Image>().color = new Color(255, 255, 255, toColor + Step4);

//        //カウント０で終了
//        if (count4 <= 0)
//        {
//            count4 = 0;
//            Step4 = 0;
//            t_star4.GetComponent<Image>().color = new Color(0, 0, 0 + Step4);
//            Star5();
//        }
//    }
//    public void Star5()
//    {
//        count5 -= Time.deltaTime;
//        //現在のアルファ値を取得
//        float toColor = t_star5.GetComponent<Image>().color.a;
//        //アルファが 0　または 1 なったら増減値を反転
//        if (toColor < 0 || toColor > 1)
//        {
//            Step5 = Step5 * -1;
//        }
//        //アルファ値を反映
//        t_star5.GetComponent<Image>().color = new Color(255, 255, 255, toColor + Step5);

//        //カウント０で終了
//        if (count5 <= 0)
//        {
//            count5 = 0;
//            Step5 = 0;
//            t_star5.GetComponent<Image>().color = new Color(0, 0, 0 + Step5);
//            Star6();
//        }
//    }
//    public void Star6()
//    {
//        count6 -= Time.deltaTime;
//        //現在のアルファ値を取得
//        float toColor = t_star6.GetComponent<Image>().color.a;
//        //アルファが 0　または 1 なったら増減値を反転
//        if (toColor < 0 || toColor > 1)
//        {
//            Step6 = Step6 * -1;
//        }
//        //アルファ値を反映
//        t_star6.GetComponent<Image>().color = new Color(255, 255, 255, toColor + Step6);

//        //カウント０で終了
//        if (count6 <= 0)
//        {
//            count6 = 0;
//            Step6 = 0;
//            t_star6.GetComponent<Image>().color = new Color(0, 0, 0 + Step6);

//            //シーン移動
//            SceneGoto();
//        }
//    }

//    //シーン移動してくれます。
//    public void SceneGoto()
//    {
//        //シーン移動処理
//        SceneManager.LoadScene(NextSceneName);
//    }
//}
