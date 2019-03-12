using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kobusi : MonoBehaviour
{
    //拳の与えるダメージ
    public int kobusiDamage = 10;
    //自分の弾の番号
    public int PlayerNum = 1;
    //相手のプレイヤー番号を判別するための番号
    public int EnemyNum1 = 1;
    public int EnemyNum2 = 2;
    public int EnemyNum3 = 3;

    void OnBecameInvisible()
    {
        //画面外に出たらオブジェクトを消す
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision Kobusi_other)
    {
        bool TriggerFlag = true;
        if (TriggerFlag)
        {
            TriggerFlag = false;
            if (Kobusi_other.gameObject.tag == "Player" + EnemyNum1)
            {
                var hit = Kobusi_other.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    Destroy(gameObject);
                    health.HP(PlayerNum, kobusiDamage);
                }
            }
            if (Kobusi_other.gameObject.tag == "Player" + EnemyNum2)
            {
                var hit = Kobusi_other.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    Destroy(gameObject);
                    health.HP(PlayerNum, kobusiDamage);
                }
            }
            if (Kobusi_other.gameObject.tag == "Player" + EnemyNum3)
            {
                var hit = Kobusi_other.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    Destroy(gameObject);
                    health.HP(PlayerNum, kobusiDamage);
                }
            }
        }
    }
}
