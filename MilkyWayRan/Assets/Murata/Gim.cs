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
    //オブジェクト
    public GameObject[] EF = new GameObject[3];

    //与えるダメージ
    public int Gim_Damage = 5;

    //相手のプレイヤー番号を判別するための番号
    public int EnemyNum1 = 1;
    public int EnemyNum2 = 2;
    public int EnemyNum3 = 3;
    public int EnemyNum4 = 4;

    void Start()
    {
        //初期設定
        EF[0].SetActive(true);
        EF[1].SetActive(false);
        EF[2].SetActive(true);
    }


    void Update()
    {
        //位置に着いたら
        if (EF[2].transform.position.y <= 1)
        {
            // 非表示
            EF[0].SetActive(false);
            EF[2].SetActive(false);
            //表示
            EF[1].SetActive(true);
        }
    }
    //ダメージ処理
    void OnCollisionEnter(Collision other)
    {
        bool TriggerFlag = true;
        if (TriggerFlag)
        {
            TriggerFlag = false;
            if (other.gameObject.tag == "Player" + EnemyNum1)
            {
                var hit = other.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    Destroy(gameObject);
                    health.HP(5, Gim_Damage);
                }
            }
            if (other.gameObject.tag == "Player" + EnemyNum2)
            {
                var hit = other.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    Destroy(gameObject);
                    health.HP(5, Gim_Damage);
                }
            }
            if (other.gameObject.tag == "Player" + EnemyNum3)
            {
                var hit = other.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    Destroy(gameObject);
                    health.HP(5, Gim_Damage);
                }
            }
            if (other.gameObject.tag == "Player" + EnemyNum4)
            {
                var hit = other.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    Destroy(gameObject);
                    health.HP(5, Gim_Damage);
                }
            }
        }
    }
}
