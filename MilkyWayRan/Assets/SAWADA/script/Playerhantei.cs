using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhantei : MonoBehaviour
{
    //力を加える量
    public float thrust;
    //Rigidbody
    public Rigidbody rd;
    //当たり判定(対象物にぶつかった時)
    void OnTriggerEnter(Collider coll)
    {
        //Player1タグにぶつかった時
        if (coll.gameObject.tag == "Player1")
        {
            //衝突した時に回転しないようにする
            rd.constraints = RigidbodyConstraints.FreezeRotation;
            //isKinematicをfalseにする
            rd.isKinematic = false;
            //自身を横方向に動かす
            rd.AddForce(transform.right * thrust);
           
        }

    }
    //当たり判定(対象物に離れた時)
    void OnTriggerExit(Collider coll)
    {
        //isKinematicがfalseならば
        if (rd.isKinematic == false)
        {
            //1秒後に自身を止める
            Invoke("Stop", 1.0f);
        }
    }
    //止める処理
    void Stop()
    {
        //isKinematicをtrueにする
        rd.isKinematic = true;

    }
   
}
