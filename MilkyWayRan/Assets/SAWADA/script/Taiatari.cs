using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taiatari : MonoBehaviour
{
    //加えられる力
    public float thrust;
    //移動スピード
    public float speed;
    //自身のRigidbody
    public Rigidbody rd;
    //相手のRidibody
    public Rigidbody rigid;
    void OnCollisionEnter(Collision coll)
    {
        //Playerタグにぶつかった時
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("a");
            //飛ばす方向を求める
            var impulse = (rigid.position - transform.position).normalized * this.thrust;
            //相手が衝突した時に回転しないようにする
            rigid.constraints = RigidbodyConstraints.FreezeRotation |
                                RigidbodyConstraints.FreezePositionY;
            //相手を吹き飛ばす
            rigid.AddForce(impulse);
           //自身が衝突した時に回転しないようにする
         　rd.constraints = RigidbodyConstraints.FreezeRotation|
                            RigidbodyConstraints.FreezePositionY;
           //自身を逆方向に飛ばす　
           rd.AddForce(impulse*-1);

        


        }
    }
    //対象物と離れたら
    void OnCollisionExit(Collision coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            //10秒後に自身と相手を止める
            Invoke("Stop", 50.0f);
        }
    }
    //止める処理
    void Stop()
    {
        //自身を止める
        rd.velocity = Vector3.zero;
        //相手を止める
        rigid.velocity = Vector3.zero;

    }
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        //左移動
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        //右移動
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        //上移動
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        //下移動
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }

    }
    // Update is called once per frame
 
}
