using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmagEfect : MonoBehaviour
{

    //1回だけ処理するために必要
    bool one;
    //エフェクトを表示する場所
    public GameObject Star;
    //表示するエフェクト
    public GameObject efect;
    //エフェクトが消える時間
    public float delettime;
    // Start is called before the first frame update
    void Start()
    {
        //oneをtrueにする
        one = true;
    }

    // Update is called once per frame
    void Update()
    {
        //oneがTrueなｒ
        if (one)
        {
            //エフェクトを表示する
            var obj = GameObject.Instantiate(efect) as GameObject;
            obj.transform.position = Star.transform.position;
            //エフェクトを消す
            Destroy(obj, delettime);
            //oneをfalseにする
            one = false;
        }
    }
}
