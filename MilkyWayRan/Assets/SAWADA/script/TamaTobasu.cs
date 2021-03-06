﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaTobasu : MonoBehaviour
{ //スタート地点
    private Vector3 charaPos;
    public Vector3 CharaPos { set { charaPos = value; } }
    //ゴール地点
    private Vector3 targetPos;
    public Vector3 TargetPos { set { targetPos = value; } }
    //中継地点
    private Vector3 greenPos;
    public Vector3 GreenPos { set { greenPos = value; } }
    //進む割合を管理する変数
    float time;

    //弾の消える時間（追加しましたby中島）
    public float Destroybullet = 5.0f;

    //弾の与えるダメージ
    public int BulletDamage = 2;
    //自分の弾の番号
    public int PlayerNum = 1;
    //相手のプレイヤー番号を判別するための番号
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
     
        ////弾の進む割合をTime.deltaTimeで決める
        //time += Time.deltaTime;

        ////二次ベジェ曲線
        ////スタート地点から中継地点までのベクトル上を通る点の現在の位置
        //var a = Vector3.Lerp(charaPos, greenPos, time);
        ////中継地点からターゲットまでのベクトル上を通る点の現在の位置
        //var b = Vector3.Lerp(greenPos, targetPos, time);
        ////上の二つの点を結んだベクトル上を通る点の現在の位置（弾の位置）
        //this.transform.position = Vector3.Lerp(a, b, time);

        Destroy(gameObject, Destroybullet);//数秒後弾を消す
    }
    void OnCollisionEnter(Collision Bullet_other)
    {
        bool TriggerFlag = true;
        if (TriggerFlag)
        {
            TriggerFlag = false;
            if (Bullet_other.gameObject.tag == "Player" + EnemyNum1)
            {
                var hit = Bullet_other.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    Destroy(gameObject);
                    health.HP(PlayerNum, BulletDamage);
                }
            }
            if (Bullet_other.gameObject.tag == "Player" + EnemyNum2)
            {
                var hit = Bullet_other.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    Destroy(gameObject);
                    health.HP(PlayerNum, BulletDamage);
                }
            }
            if (Bullet_other.gameObject.tag == "Player" + EnemyNum3)
            {
                var hit = Bullet_other.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    Destroy(gameObject);
                    health.HP(PlayerNum, BulletDamage);
                }
            }
        }
    }
}