using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObuject : MonoBehaviour
{
    //エフェクト
    public GameObject Destroyefect;
    //エフェクトが消える時間
    public float delettime;
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
        //Aキーが押された時
        if (Input.GetKeyDown(KeyCode.A)){
            //プレイヤーを消す
            Destroy(this.gameObject);
         
           //1回だけ処理させるようにする
            if (one)
            {
                //エフェクトを発生させる
                var obj = GameObject.Instantiate(Destroyefect) as GameObject;
                //エフェクトをプレイヤーと同じ所に発生させる
                obj.transform.position = this.transform.position;
                //エフェクトを消す
                Destroy(obj, delettime);
                //oneをfalseにする
                one = false;
            }
        }
    }
  
}
