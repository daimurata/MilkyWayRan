using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hisatu : MonoBehaviour
{
   //拳のオブジェクト
    public GameObject Kobusi;
    //発射位置
    public Transform muzzle;
    //拳のスピード
    public float speed = 100;
    //必殺技の数値
    public int Special = 0;

    //Death death;
    public Death death;

    //必殺技音
    AudioSource audioSource;
    public AudioClip Hissatu_SE1;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ////zキーが押された時
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //   //拳の生成
        //    GameObject Kobusies = Instantiate(Kobusi) as GameObject;
        //    //拳の向きをオブジェクトの向きに合わせます。
        //    Kobusies.transform.rotation = this.gameObject.transform.rotation;
        //    //拳の発射
        //    Vector3 force;
        //    force = this.gameObject.transform.forward * speed;
        //    //拳のRigidbodyの取得
        //    Kobusies.GetComponent<Rigidbody>().AddForce(force);
        //    //拳がプレイヤーの進行方向に向かうようにする
        //    Kobusies.transform.position = transform.position;
        //    //発射位置から拳を発射
        //    Kobusies.transform.position = muzzle.position;
        //}
    }
    public void hisatuskill()
    {
        //他のスクリプトから呼び出す為に作成
        //試す際はUpdateでいいですけれど、動作確認が終わったらこっち hisatuskill に移動させてください

        //Specialが○○になったら必殺技を使える
        if(Special >= 10)
        {
            //audioSource.PlayOneShot(Hissatu_SE1);
            //0にする
            Special = 0;
            //拳の生成
            GameObject Kobusies = Instantiate(Kobusi) as GameObject;
            //拳の向きをオブジェクトの向きに合わせます。
            Kobusies.transform.rotation = this.gameObject.transform.rotation;
            //拳の発射
            Vector3 force;
            force = this.gameObject.transform.forward * speed;
            //拳のRigidbodyの取得
            Kobusies.GetComponent<Rigidbody>().AddForce(force);
            //拳がプレイヤーの進行方向に向かうようにする
            Kobusies.transform.position = transform.position;
            //発射位置から拳を発射
            Kobusies.transform.position = muzzle.position;

            Death a1 = death.GetComponent<Death>();
            a1.Gage0();
        }   
    }
    public void SpecialGage(int damage)
    {
        Special = Special + damage;
        //
        Death a1 = death.GetComponent<Death>();
        a1.Gage(damage);
    }
}
