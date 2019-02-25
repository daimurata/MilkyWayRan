using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAttack : MonoBehaviour
{
    //星の与えるダメージ
    public int StarDamage = 5;
    //番号
    public int Num = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" + Num)
        {
            //何もしない
        }
        else
        {
            var hit = other.gameObject;
            var health = hit.GetComponent<PlayerMove>();
            if (health != null)
            {
                health.HP(Num,StarDamage);
                //Destroy(gameObject);
            }
        }
    }
}
