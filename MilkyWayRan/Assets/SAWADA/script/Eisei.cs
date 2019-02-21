using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eisei : MonoBehaviour
{
    //1回だけ処理するために必要
    bool one;
    //衛星のオブジェクト
    private GameObject Eiseis;
    public GameObject Eiseiobj;
    //衛星が出てくる時間
    float eiseiattakInterval;
    // トータルタイム
    public float totalTime;
  
    // Start is called before the first frame update
    void Start()
    {

     　//衛星が出てくる時間をランダムにする
        eiseiattakInterval = Random.Range(0, 60);
        //one変数をtrueにする
        one = true;
    }

    // Update is called once per frame
    void Update()
    {　//ここで衛星が出てくる時間を確認する
        Debug.Log(eiseiattakInterval);
        //タイム処理
        totalTime += Time.deltaTime;
        //oneがtrueなら
        if (one)
        {
            //衛星が出てくる時間をトータルタイムが上回ったら
            if (totalTime > eiseiattakInterval)
            {
                //衛星を出現させる
                Eiseis = Instantiate(Eiseiobj, new Vector3(-13, 0, -5), Quaternion.identity) as GameObject;
              　//oneをfalseにして、1回だけ処理させるようにする
                one = false;
            }
        }
       
    }
}
