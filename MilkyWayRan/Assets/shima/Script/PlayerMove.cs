using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //プレイヤーナンバー
    public int PlayerNum = 1;
    //移動スピード
    public float PlayerSpeed = 5.0f;


    //プレイヤーのHPを別々で保存する？迷い中
    public int PlayerHP1 = 10;
    public int PlayerHP = 10;


    //弾の与えるダメージ
    public int BulletDamage = 2;
    //
    public int StarDamage = 5;

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
        if (Input.GetButton("Fire1_" + PlayerNum))
        {
            //アクションを入れていく
            Debug.Log("Shot1_" + PlayerNum);
            //回転攻撃のコルーチンの呼び出し
            //StartCoroutine(Atack());
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
    public void HP(int amount)
    {
        PlayerHP -= amount;
        if(PlayerHP >= 0)
        {
            Debug.Log(PlayerHP);
        }
        if(PlayerHP == 0)
        {
            Destroy(this.gameObject);
            Debug.Log("死亡");
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Star")
        {
            var hit = other.gameObject;
            var health = hit.GetComponent<PlayerMove>();
            if (health != null)
            {
                health.HP(StarDamage);
                Destroy(this.gameObject);
            }
        }
        if (other.gameObject.tag == "Bullet")
        {
            var hit = other.gameObject;
            var health = hit.GetComponent<PlayerMove>();
            if (health != null)
            {
                health.HP(BulletDamage);
                Destroy(this.gameObject);
            }
        }
    }
}
   
    //IEnumerator Atack()//スピンのやつ
    //{
    //    //ループを抜け出すための適当な変数
    //    int a = 0;
    //    while (true)
    //    {
    //        //適当に10づつ足してる
    //        tama.transform.Rotate(0, 10, 0);
    //        //時間も適当で0.1秒づつ呼び出される
    //        yield return new WaitForSeconds(0.1f);
    //        a++;
    //        if(a > 10)
    //        break;
    //    }
 
