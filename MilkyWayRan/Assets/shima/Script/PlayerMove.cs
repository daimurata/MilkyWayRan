﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //ここでプレイヤー関連のやつ移動とかHPまとめてやります


    //プレイヤーナンバー
    public int PlayerNum = 1;
    //敵ナンバー
    public int EnemyNum1 = 1;
    public int EnemyNum2 = 2;
    public int EnemyNum3 = 3;
    //移動スピード
    public float PlayerSpeed = 5.0f;
    //HP
    public int PlayerHP = 10;

    //体当たりダメージ
    public int TackleDamage = 5;

    //ふっとぶ距離的なもの
    public float pos = 1.0f;

    //適当に作成、後で変更
    //public GameObject tama;

    attak attakscript;

    //アニメーター関連をコピってきたもの
    private Rigidbody _rigidBody;

    private Animator animator;

    //攻撃に当たった際Boolを呼び出して一時的な無敵処理を追加するか否か,途中
    private bool isCollision = true;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    /// <summary>
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        //プレイヤーの移動
        Move(PlayerNum);
    }
    void Move(int Number)
    {
        attak d1 = GetComponent<attak>();

        //ボタン確認
        
        if (Input.GetButtonDown("Fire1_" + PlayerNum))
        {
            //アクションを入れていく
            Debug.Log("Shot1_" + PlayerNum);
            d1.kaiten();
            animator.SetBool("is_attack", true);
            _rigidBody.isKinematic = true;
            Invoke("RigidBodyfalse", 1.0f);
        }
        else
        {
            animator.SetBool("is_attack", false);
        }
        if (Input.GetButtonDown("Fire2_" + PlayerNum))
        {         
            Debug.Log("Shot2_" + PlayerNum);
            d1.syageki();
            animator.SetBool("is_attack", true);
            _rigidBody.isKinematic = true;
            Invoke("RigidBodyfalse", 1.0f);
        }
        else
        {
            animator.SetBool("is_attack", false);
        }
        if (Input.GetButton("Fire3_" + PlayerNum))
        {
            Debug.Log("Shot3_" + PlayerNum);
            animator.SetBool("is_attack", true);
        }
        else
        {
            animator.SetBool("is_attack", false);
        }
        //アナログスティックで動かせると思う
        float x = Input.GetAxis("Horizontal" + PlayerNum);//左右
        float y = Input.GetAxis("Vertical" + PlayerNum);//前後

        //transform.Rotate(0, x, 0);//回転
        //transform.position += y * transform.forward * PlayerSpeed * Time.deltaTime;//前後移動

        var direction = new Vector3(x, 0, y);

        if (x != 0 || y != 0)
        {
            //方向を向く
            transform.localRotation = Quaternion.LookRotation(direction);
            //方向に移動
            transform.position += PlayerSpeed * direction * Time.deltaTime;
            animator.SetBool("is_go", true);
        }
        else
        {
            animator.SetBool("is_go", false);
        }
    }
    public void HP(int Number,int amount)
    {
        PlayerHP -= amount;
        if (PlayerHP >= 0)
        {
            Debug.Log("プレイヤー"+Number+"が攻撃"+PlayerHP);
        }
        if (PlayerHP <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("プレイヤー" +"死亡");
            //多分ここに死んだ時のアニメーション追加
        }
    }
    void OnCollisionEnter(Collision col)
    {
        float x = Input.GetAxis("Horizontal" + PlayerNum);//左右
        float y = Input.GetAxis("Vertical" + PlayerNum);//前後

        var direction = new Vector3(x, 0, y);

        bool TriggerFlag = true;
        //相手がプレイヤーの場合、プレイヤーの番号指定（Inspectorで変更）
        //体当たりでダメージが出る感じ
        if (TriggerFlag)
        {
            TriggerFlag = false;
            if (col.gameObject.tag == "Player" + EnemyNum1)
            {
                /////
                Debug.Log(PlayerNum + "がダメージをうけた");
                animator.SetBool("is_damage", true);
                Invoke("AnimatorBoolfalse", 0.5f);
                //////
                var hit = col.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    //ここがプレイヤーの入力方向と逆の方向に無理やり飛ばす処理
                    transform.position -= direction * pos ;
                    health.HP(PlayerNum, TackleDamage);
                }
            }
        }
        if (TriggerFlag)
        {
            TriggerFlag = false;
            if (col.gameObject.tag == "Player" + EnemyNum2)
            {
                /////
                Debug.Log(PlayerNum + "がダメージをうけた");
                animator.SetBool("is_damage", true);
                Invoke("AnimatorBoolfalse", 0.5f);
                //////
                var hit = col.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    //Destroy(gameObject);
                    health.HP(PlayerNum, TackleDamage);
                }
            }
        }
        if (TriggerFlag)
        {
            TriggerFlag = false;
            if (col.gameObject.tag == "Player" + EnemyNum3)
            {
                /////
                Debug.Log(PlayerNum + "がダメージをうけた");
                animator.SetBool("is_damage", true);
                Invoke("AnimatorBoolfalse", 0.5f);
                //////
                var hit = col.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    //Destroy(gameObject);
                    health.HP(PlayerNum, TackleDamage);
                }
            }
        }


        //if (col.gameObject.tag == "Star" + EnemyNum1)
        //{
        //    Debug.Log(PlayerNum + "がダメージをうけた");
        //    animator.SetBool("is_damege", true);
        //    Invoke("AnimatorBoolfalse", 0.5f);
        //}
        //if (col.gameObject.tag == "Star" + EnemyNum2)
        //{
        //    Debug.Log(PlayerNum + "がダメージをうけた");
        //    animator.SetBool("is_damege", true);
        //    Invoke("AnimatorBoolfalse", 0.5f);
        //}
        //if (col.gameObject.tag == "Star" + EnemyNum3)
        //{
        //    Debug.Log(PlayerNum + "がダメージをうけた");
        //    animator.SetBool("is_damege", true);
        //    Invoke("AnimatorBoolfalse", 0.5f);
        //}

        //相手がBulletの場合、弾の番号指定（Inspectorで変更）
        if (col.gameObject.tag == "Bullet" + EnemyNum1)
        {
            Debug.Log(PlayerNum + "がダメージをうけた");
            animator.SetBool("is_damage", true);
            Invoke("AnimatorBoolfalse", 0.5f);
        }
        if (col.gameObject.tag == "Bullet" + EnemyNum2)
        {
            Debug.Log(PlayerNum + "がダメージをうけた");
            animator.SetBool("is_damage", true);
            Invoke("AnimatorBoolfalse", 0.5f);
        }
        if (col.gameObject.tag == "Bullet" + EnemyNum3)
        {
            Debug.Log(PlayerNum + "がダメージをうけた");
            animator.SetBool("is_damage", true);
            Invoke("AnimatorBoolfalse", 0.5f);
        }
    }
    void AnimatorBoolfalse()
    {
        //falseを呼び出すだけのため
        animator.SetBool("is_damage", false);
    }
    void RigidBodyfalse()
    {
        _rigidBody.isKinematic = false;
    }
}
 
