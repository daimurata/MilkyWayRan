using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 衛星移動
/// </summary>

public class Eisei : MonoBehaviour
{
    //1回だけ処理するために必要
    static bool one =false;
    //衛星のオブジェクト
    private GameObject Eiseis;
    public GameObject Eiseiobj;
    //衛星が出てくる時間
    float eiseiattakInterval;
    // トータルタイム
    public float totalTime;

    public float X=-13, Y=0, Z=-5;
    // Start is called before the first frame update
    void Start()
    {

     　//衛星が出てくる時間をランダムにする
        eiseiattakInterval = Random.Range(0, 60);
        //one変数をtrueにする
       // one = true;
    }

    // Update is called once per frame
    void Update()
    {　
        //oneがtrueなら
        if (one)
        {
            //ここで衛星が出てくる時間を確認する
            Debug.Log(eiseiattakInterval);
            //タイム処理
            totalTime += Time.deltaTime;
            //衛星が出てくる時間をトータルタイムが上回ったら
            if (totalTime > eiseiattakInterval)
            {
                //衛星を出現させる
                Eiseis = Instantiate(Eiseiobj, new Vector3(X, Y, Z), Quaternion.identity) as GameObject;
              　//oneをfalseにして、1回だけ処理させるようにする
                one = false;
            }
        }
       
    }
    //衛星外部いじれる
    public static void Go_Eisei()
    {
        //one変数をtrueにする
        one = true;
    }
}
