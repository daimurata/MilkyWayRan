using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefab : MonoBehaviour
{
  //生成するオブジェクト
    public GameObject obj;
    private GameObject objs;
    //キーを押す回数
    int keykount = 0;
    // Start is called before the first frame update
    void Start()
    {
        //オブジェクト設定
        objs = obj;
    }

    // Update is called once per frame
    void Update()
    {
        //Aキーが押された時
        if (Input.GetKeyDown(KeyCode.A))
        {
           //カウントを1個進める
            keykount += 1;
            //カウントが1なら
            if (keykount == 1)
              objs= Instantiate(obj, new Vector3(-13.7f, 1.0f, -4.6f), Quaternion.identity)as GameObject;//オブジェクト複製
            //カウントが2なら
            if (keykount == 2)
                Destroy(objs);  //オブジェクトを消す
            //カウントが2以上なら
            if (keykount >= 2)
                keykount = 0;//カウントを0にする
            

                    }
            }
      

    }

