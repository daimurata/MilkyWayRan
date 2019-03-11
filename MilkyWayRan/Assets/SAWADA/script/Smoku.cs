using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoku : MonoBehaviour
{
    //表示するエフェクト
    public GameObject Smokues;
    //1回だけ処理されるようにする
    bool one;
    // Start is called before the first frame update
    void Start()
    {
        //oneをtrueにする
        one = true;
    }

    // Update is called once per frame
    void Update()
    {
        //oneがtrueなら
        if (one)
        {
            //エフェクトを発生させる
            var obj = GameObject.Instantiate(Smokues) as GameObject;
            obj.transform.position = this.transform.position;
            //エフェクトを子オブジェクトにする
            obj.transform.parent = transform;
            //oneをfalseにする
            one = false;
        }
    }
}
