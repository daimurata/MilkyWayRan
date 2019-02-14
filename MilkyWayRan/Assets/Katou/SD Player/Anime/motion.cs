﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motion : MonoBehaviour
{

    private Animator animator;

    // Start is called before the first frame update
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        //移動
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward * 0.1f;
            animator.SetBool("is_go", true);
            attack();
        }
        else
        {
            animator.SetBool("is_go", false);
        }
        if (Input.GetKey("right"))//右旋回
        {
            transform.Rotate(0, 10, 0);
        }
        if (Input.GetKey("left"))//左旋回
        {
            transform.Rotate(0, -10, 0);
        }
        attack();
    }
    public void attack()
    {
        if (Input.GetKey(KeyCode.A))//攻撃
        {
            animator.SetBool("is_attack", true);
        }
        else
        {
            animator.SetBool("is_attack", false);
        }
    }

    //オブジェクトと接触した瞬間に呼び出される
    void OnTriggerEnter(Collider other)
    {

        //相手がBulletの場合
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("hit Player");
            animator.SetBool("is_damage", true);
        }
        else
        {
            animator.SetBool("is_damage", false);
        }
    }

}