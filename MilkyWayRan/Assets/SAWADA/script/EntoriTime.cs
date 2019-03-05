using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EntoriTime : MonoBehaviour
{
    GameObject Prefab;
    PlayerPrefab script;
    //時間を表示させるテキスト
    public Text timerText;
    // トータルタイム
    public float totalTime;
    //秒数
    int seconds;


    // Start is called before the first frame update
    void Start()
    {
        Prefab = GameObject.Find("PlayerPrefabfab");
        script = Prefab.GetComponent<PlayerPrefab>();
      
    }

    // Update is called once per frame
    void Update()
    {
        //時間の計測処理
        totalTime -= Time.deltaTime;
        seconds = (int)totalTime;
        if (totalTime <= 0)
        {

            return;
        }

        //textに時間を表示させる
        timerText.text = seconds.ToString();
    }
}
