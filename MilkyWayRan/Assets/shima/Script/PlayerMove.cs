using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //ここでプレイヤー関連のやつ移動とかHPまとめてやります


    //プレイヤーナンバー
    public int PlayerNum = 1;
    //移動スピード
    public float PlayerSpeed = 5.0f;

    public int PlayerHP = 10;
   
    //適当に作成、後で変更
    //public GameObject tama;

    attak attakscript;

    bool One;

    // Use this for initialization
    void Start()
    {

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
        }
        if (Input.GetButtonDown("Fire2_" + PlayerNum))
        {
            
             Debug.Log("Shot2_" + PlayerNum);
             d1.syageki();               
        }
        if (Input.GetButton("Fire3_" + PlayerNum))
        {
            Debug.Log("Shot3_" + PlayerNum);
                   
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
        }
    }
    public void HP(int Number,int amount)
    {
        PlayerHP -= amount;
        if (PlayerHP >= 0)
        {
            Debug.Log("プレイヤー"+Number+"が攻撃"+PlayerHP);
        }
        if (PlayerHP < 0)
        {
            Destroy(this.gameObject);
            Debug.Log("プレイヤー" +"死亡");
        }
    }
   
}
 
