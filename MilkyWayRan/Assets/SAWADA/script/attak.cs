using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attak : MonoBehaviour
{
    //回転するスピード
    public float timeOut;
    //ターゲット
    public GameObject target;
    //弾のプレハブ
    public GameObject tama;
    //星の回転時に攻撃判定をいれるもの
    public GameObject tama2;
   
    //中継地点1
    public GameObject greenPoint;
    //中継地点2
    public GameObject greenPoint1;
    //中継地点を割り振るための変数
    int count = 0;

    //弾数
    public int BulletCount = 5;
    //弾数の上限
    public int BulletCountLimit = 5;
    //弾の回復時間変数
    public float BulletTime = 3f;

    public int PlayerNum;

    //★オブジェクトを入れる
    public GameObject Star;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BulletTime -= Time.deltaTime;
        //時間毎(BulletTime)で弾数を1追加
        if (BulletTime <= 0)
        {
            BulletTime = 3;
            BulletCount = BulletCount + 1;
        }
        if(BulletCount > BulletCountLimit)
        {
            BulletCount = BulletCountLimit;
        }

        //BulletTime == Time.deltaTime;
        //xキーが押された時
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    //回転処理
        //    StartCoroutine(FuncCoroutine());
        //}
        //zキーが押された時
        //if (Input.GetKeyDown(KeyCode.Z))
        //{


        //        //自分の位置を保存
        //        var pos = this.gameObject.transform.position;
        //        //弾のプレハブを作成
        //        var t = Instantiate(tama) as GameObject;
        //        //弾の初期位置を敵の位置にする
        //        t.transform.position = pos;
        //        //弾につけているスクリプト、TamaTobasuコンポネントを保存する
        //        var cash = t.GetComponent<TamaTobasu>();
        //        //スタート地点を弾のスクリプトに渡す
        //        cash.CharaPos = this.transform.position;
        //        //弾を一つ打ち出すたびに中継地点を変える
        //        count++;
        //        //中継地点を弾のスクリプトに渡す
        //        if (count % 2 == 1) cash.GreenPos = greenPoint.transform.position;
        //        else cash.GreenPos = greenPoint1.transform.position;
        //        //敵の位置を弾のスクリプトに渡す
        //        cash.TargetPos = target.transform.position;


        //}
    }

    public void kaiten()
    {
        //回転処理
        StartCoroutine(FuncCoroutine());
        //SetActiveのON、OFFの切り替えで攻撃判定を一時的に出すようにしてあります
        tama2.gameObject.SetActive(true);
        Invoke("SetActivefalse",1.0f);
    }

    public void syageki()
    {
        if (BulletCount > 0)
        {
            //自分の位置を保存
            var pos = this.gameObject.transform.position;
            //弾のプレハブを作成
            //var t = Instantiate(tama) as GameObject;
            //複製したオブジェクトの位置　←ここ書き加えました
            var t = Instantiate(tama, this.transform.position, Quaternion.identity);
            //弾の初期位置を敵の位置にする
            t.transform.position = pos;
            //弾につけているスクリプト、TamaTobasuコンポネントを保存する
            var cash = t.GetComponent<TamaTobasu>();
            //スタート地点を弾のスクリプトに渡す
            cash.CharaPos = this.transform.position;
            //弾を一つ打ち出すたびに中継地点を変える
            //count++;
            //中継地点を弾のスクリプトに渡す←countをBulletCountに変更
            if (BulletCount % 2 == 1) cash.GreenPos = greenPoint.transform.position;
            else cash.GreenPos = greenPoint1.transform.position;
            //敵の位置を弾のスクリプトに渡す
            cash.TargetPos = target.transform.position;
            //弾数を減らす←追加
            BulletCount = BulletCount - 1;
        }
    }

    IEnumerator FuncCoroutine()
    {
        //ループしないようにする
        int a = 0;
        while (true)
        {
            //回転処理
            Star.transform.Rotate(0, 10, 0);
            yield return new WaitForSeconds(timeOut);
            //ループしないようにする処理
            a++;
            if (a > 35)
                break;
        }
    }
    void SetActivefalse()
    {
        tama2.gameObject.SetActive(false);
    }
}
