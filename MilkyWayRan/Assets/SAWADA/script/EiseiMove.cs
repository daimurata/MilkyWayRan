using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EiseiMove : MonoBehaviour
{   //回転するスピード
    public float timeOut;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //自身のいるtransformを取得
        Transform myTransform = this.transform;
        //自身をワールド座標に沿って右に移動させる
        myTransform.Translate(0.03f, 0, 0, Space.World);
        //回転処理
        StartCoroutine(FuncCoroutine());
    }
 
    void OnBecameInvisible()
    {
          //画面外に出たらオブジェクトを消す
            Destroy(this.gameObject);
    }
    IEnumerator FuncCoroutine()
    {
      
        while (true)
        {
            //回転処理
            transform.Rotate(0.01f, 0, 0);
            yield return new WaitForSeconds(timeOut);
            
        }
    }
}
