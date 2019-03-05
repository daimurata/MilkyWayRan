using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test_imag : MonoBehaviour
{
    float fadeSpeed = 0.01f;        //透明度が変わるスピードを管理
    float red=0, green=0, blue=0, alfa=0;   //パネルの色、不透明度を管理

    public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
    public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

    public Image fadeImage;                //透明度を変更するパネルのイメージ

    public string NextSceneName;
    void Start()
    {
        //fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
        DontDestroyOnLoad(this);
        fadeImage.enabled = false;
    }

    void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn();
        }

        if (isFadeOut)
        {
            StartFadeOut();
        }
    }

    void StartFadeIn()
    {
        red -= fadeSpeed;
        green -= fadeSpeed;
        blue -= fadeSpeed;
        alfa -= fadeSpeed;               
        SetAlpha();
        if (alfa <= 0)
        {                   
            isFadeIn = false;
            fadeImage.enabled = false;    
        }
    }

    void StartFadeOut()
    {
        // Debug.Log("初め"+alfa);
        fadeImage.enabled = true;
        red += fadeSpeed;
        green += fadeSpeed;
        blue += fadeSpeed;
        alfa += fadeSpeed;         
        SetAlpha();               
        if (alfa >= 1)
        {
           // Debug.Log("移動前"+alfa);
            isFadeOut = false;
            SceneManager.LoadScene(NextSceneName);
 
            isFadeIn = true;
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
    public void ButtonClick()
    {
        isFadeOut = true;
       // Debug.Log("押した");
    }
}

/*
public Image Image;
public float[] color=new float[4];
public float speed = 10;
private float[] MAX_MIN = new float[2];
void Start()
{
    MAX_MIN[0] = 1;
    MAX_MIN[1] = 0;
    Image.GetComponent<Image>().color = new Color(color[0], color[1], color[2], color[3]);
}


void Update()
{
    if (Input.GetKey(KeyCode.Q))
    {
        Color_Up();
        Image.GetComponent<Image>().color = new Color(color[0], color[1], color[2], color[3]);
        Color_MAX();
    }
    if (Input.GetKey(KeyCode.W))
    {
        Color_Down();
        Image.GetComponent<Image>().color = new Color(color[0],color[1] , color[2], color[3]);
        Color_MIN();
    }

}
public void Color_Up()
{
    color[0] += Time.deltaTime * speed;
    color[1] += Time.deltaTime * speed;
    color[2] += Time.deltaTime * speed;
    color[3] += Time.deltaTime * speed;
}
public void Color_Down()
{
    color[0] -= Time.deltaTime * speed;
    color[1] -= Time.deltaTime * speed;
    color[2] -= Time.deltaTime * speed;
    color[3] -= Time.deltaTime * speed;
}
public void Color_MAX()
{
    if (color[0] >= MAX_MIN[1] || color[1] >= MAX_MIN[1] || color[2] >= MAX_MIN[1])
    {
        color[0] = MAX_MIN[1];
        color[1] = MAX_MIN[1];
        color[2] = MAX_MIN[1];

    }
    if (color[3] >= MAX_MIN[0])
    {
        color[3] = MAX_MIN[0];
    }
}
public void Color_MIN()
{
    if (color[0] <= MAX_MIN[0] || color[1] <= MAX_MIN[0] || color[2] <= MAX_MIN[0])
    {
        color[0] = MAX_MIN[0];
        color[1] = MAX_MIN[0];
        color[2] = MAX_MIN[0];
    }
    if (color[3] <= MAX_MIN[1])
    {
        color[3] = MAX_MIN[1];
    }
}*/
