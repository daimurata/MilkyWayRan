using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    //加えられる力
    public float thrust;
    private Rigidbody _rigidBody;
    //相手のRidibody
    public Rigidbody rigid;
    private Animator animator;

    // Start is called before the first frame update
    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
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
            Attack();
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
        Attack();
    }
    public void Attack()
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
    void OnCollisionEnter(Collision col)
    {
        //Playerタグにぶつかった時
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("a");
            //飛ばす方向を求める
            var impulse = (rigid.position - transform.position).normalized * this.thrust;
            //相手が衝突した時に回転しないようにする
            //rigid.constraints = RigidbodyConstraints.FreezeRotation |
            //                    RigidbodyConstraints.FreezePositionY;
            //相手を吹き飛ばす
            rigid.AddForce(impulse);
            ////自身が衝突した時に回転しないようにする
            //_rigidBody.constraints = RigidbodyConstraints.FreezeRotation |
            //                  RigidbodyConstraints.FreezePositionY;
            //自身を逆方向に飛ばす　
            _rigidBody.AddForce(impulse * -1);


        }


        //相手がBulletの場合
        if (col.gameObject.tag == ("Bullet"))
        {
            Debug.Log("hit Player");
            animator.SetBool("is_damage", true);
        }
        else
        {
            animator.SetBool("is_damage", false);
        }
    }
    void OnCollisionExit(Collision coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("B");
            //10秒後に自身と相手を止める
            Invoke("Stop", 50.0f);
        }
    }
    void Stop()
    {
        //自身を止める
        _rigidBody.velocity = Vector3.zero;
        //相手を止める
        rigid.velocity = Vector3.zero;

    }
}
