using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 隕石にアタッチ
/// </summary>
public class Gim : MonoBehaviour
{
    //ステージの名前
    public string Name_Gim= "Stage";
    public GameObject[] EF = new GameObject[3];

    void Start()
    {
        EF[0].SetActive(true);
        EF[1].SetActive(false);
        EF[2].SetActive(true);
    }


    void Update()
    {
        if (EF[2].transform.position.y <= 1)
        {
            EF[0].SetActive(false);
            // 非表示
            EF[2].SetActive(false);
            EF[1].SetActive(true);
        }
    }
}
