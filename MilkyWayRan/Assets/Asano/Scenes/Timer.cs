using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private Text timerText;
    public Text startText;
    public float minute;
    private float oldminute;

    bool g_start;
    
    // Start is called before the first frame update
    void Start()
    {
        minute = 3;
        oldminute = 0f;
        timerText = GetComponentInChildren<Text>();
        startText = GetComponentInChildren<Text>();

        g_start = true;
    }

    // Update is called once per frame
    void Update()
    {
        minute -= Time.deltaTime;
        if (minute <= 0)
        {
            minute = 0;
            //------------------------
            if (minute <= 0) 
            {
                minute = 0;
                //シーン移動
                //SceneManager.LoadScene("RESULT");
            }
            else
            {
                return;
            }
        }
        //TEXTの更新
        timerText.text = minute.ToString("00");
    }
}
