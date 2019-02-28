using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAttack : MonoBehaviour
{
    
    //星の消える時間
    public int DestroyStar = 1;
    //星の与えるダメージ
    public int StarDamage = 5;

    public int Num = 1;
    //敵番号
    public int EnemyNum1 = 1;
    public int EnemyNum2 = 2;
    public int EnemyNum3 = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, DestroyStar);//数秒後弾を消す
    }
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
                    health.HP(Num, StarDamage);
                }
            }
            if (other.gameObject.tag == "Player" + EnemyNum2)
            {
                var hit = other.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    Destroy(gameObject);
                    health.HP(Num, StarDamage);
                }
            }
            if (other.gameObject.tag == "Player" + EnemyNum3)
            {
                var hit = other.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    Destroy(gameObject);
                    health.HP(Num, StarDamage);
                }
            }

        }
    }
}
