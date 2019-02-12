using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text s_timerText;//表示テキスト
    public float minute=3.0f;//スタートカウント
    public float mainminute = 10.0f;//ゲームカウント
    public bool Sta_Mai=false;//切り替えスタート＆メイン
    int Seconds;//変換
    public float interval = 1.0f;//インターバル
    public string NextSceneName;//シーン名
    void Start()
    {
        //テキスト参照
        s_timerText = GetComponentInChildren<Text>(); 
    }

    void Update()
    {
        //スタートカウントダウン
        if (Sta_Mai == false)
        {
            //スタートカウントダウン開始
            minute -= Time.deltaTime;
            //int型に直すよ
            Seconds = (int)minute;
            //テキストに反映するよ
            s_timerText.text = Seconds.ToString();

            //minuteが０になるまでやる
            if (minute <= 0)
            {
                //minuteを０で止めるよ！
                minute = 0f;
                //メインに行ける
                Sta_Mai = true;
            }
        }
        //1になったら表示
        if (minute <=1 )
        {
            //スタートを表示
            s_timerText.text = "START!";
            interval -= Time.deltaTime;
        }

        //メインカウントダウン
        if (Sta_Mai == true&&interval<=0)
        {
            interval = 0.0f;
            //メインのカウントダウン準備
            if (mainminute == 10.0f)
            {
                //textの更新
                s_timerText.text = mainminute.ToString("00");
            }
            //カウントダウン開始
            mainminute -= Time.deltaTime;
            //int型に直すよ
            Seconds = (int)mainminute;
            //テキストに反映するよ
            s_timerText.text = Seconds.ToString();
            
            //mainminuteが０までやる
            if (mainminute <= 0)
            {
                //mainminuteを０にする
                mainminute = 0;
                //シーン移動
                SceneGoto();
            }
        }
    }
    //シーン移動してくれます。
    public void SceneGoto()
    {
        //シーン移動処理
        SceneManager.LoadScene(NextSceneName);
    }
}
