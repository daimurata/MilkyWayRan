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

    public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
    public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

    public Image fadeImage;                //透明度を変更するパネルのイメージ

    public string NextSceneName;//シーン移動
    void Start()
    {
        //fadeImage = GetComponent<Image>();
        //参照
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
        //消えないようにする
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        //trueなら
        if (isFadeIn)
        {
            //フェードイン
            StartFadeIn();
        }

        //trueなら
        if (isFadeOut)
        {
            //フェードアウト
            StartFadeOut();
        }
    }

    /// <summary>
    /// フェードイン
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
        }
    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    void StartFadeOut()
    {
        fadeImage.enabled = true;  // パネルの表示をオンにする
        alfa += fadeSpeed;         // 不透明度を徐々にあげる
        SetAlpha();               // 変更した透明度をパネルに反映する
        //アルファーが1以上
        if (alfa >= 1)
        {
            // 完全に不透明になったら処理を抜ける
            //フェードアウト終了
            isFadeOut = false;
            //シーン遷移
            SceneManager.LoadScene(NextSceneName);
            //フェードインする
            isFadeIn = true;
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
    /// <summary>
    /// フェードを行うキー
    /// </summary>
    public void FadeOption()
    {
        //ボタンでスペース
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //フェードの処理
            isFadeOut = true;
        }
    }
}
