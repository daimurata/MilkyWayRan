using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rezaruto : MonoBehaviour
{
    //表示・非表示にするオブジェクト
    public GameObject bottons;
    //遷移する時間
    public float SeniTime;
    // Start is called before the first frame update
    void Start()
    {
        //  ボタンのSetActiveをfalseにする
        bottons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //時間になったらtrueにする
        Invoke("Hyouzi", SeniTime);
    }
    //ボタンを表示する
    void Hyouzi()
    {
        bottons.SetActive(true);
    }
}
