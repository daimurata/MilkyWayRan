using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefab : MonoBehaviour
{
  //生成するオブジェクト
    public GameObject obj;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    private GameObject objs;
    private GameObject objs1;
    private GameObject objs2;
    private GameObject objs3;
    //キーを押す回数
    int keykount = 0;
    int keykount1 = 0;
    int keykount2 = 0;
    int keykount3 = 0;
    // Start is called before the first frame update
    void Start()
    {
        //オブジェクト設定
        objs = obj;
        objs1 = obj1;
        objs2 = obj2;
        objs3 = obj3;
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
        //Sキーが押された時
        if (Input.GetKeyDown(KeyCode.S))
        {
            //カウントを1個進める
            keykount1 += 1;
            //カウントが1なら
            if (keykount1 == 1)
                objs1 = Instantiate(obj1, new Vector3(-14.7f, 1.0f, -4.6f), Quaternion.identity) as GameObject;//オブジェクト複製
            //カウントが2なら
            if (keykount1 == 2)
                Destroy(objs1);  //オブジェクトを消す
            //カウントが2以上なら
            if (keykount1 >= 2)
                keykount1 = 0;//カウントを0にする


        }
        //Dキーが押された時
        if (Input.GetKeyDown(KeyCode.D))
        {
            //カウントを1個進める
            keykount2 += 1;
            //カウントが1なら
            if (keykount2 == 1)
                objs2 = Instantiate(obj2, new Vector3(-15.7f, 1.0f, -4.6f), Quaternion.identity) as GameObject;//オブジェクト複製
            //カウントが2なら
            if (keykount2 == 2)
                Destroy(objs2);  //オブジェクトを消す
            //カウントが2以上なら
            if (keykount2 >= 2)
                keykount2 = 0;//カウントを0にする


        }
        //Fキーが押された時
        if (Input.GetKeyDown(KeyCode.F))
        {
            //カウントを1個進める
            keykount3 += 1;
            //カウントが1なら
            if (keykount3 == 1)
                objs3 = Instantiate(obj3, new Vector3(-16.7f, 1.0f, -4.6f), Quaternion.identity) as GameObject;//オブジェクト複製
            //カウントが2なら
            if (keykount3 == 2)
                Destroy(objs3);  //オブジェクトを消す
            //カウントが2以上なら
            if (keykount3 >= 2)
                keykount3 = 0;//カウントを0にする


        }
    }
      

    }

