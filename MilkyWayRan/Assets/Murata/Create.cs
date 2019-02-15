using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public GameObject[] Obj;//仮のステージオブジェクト
    public int CreateObj = 10;//範囲
    public float time = 0;//ギミック生成時間
    public int Gim = 1;//ギミックの数
    private GameObject test;
    private bool test_b = false;
    void Start()
    {
        //仮のステージ
        CreateObject();
        
    }

   
    void Update()
    {
        //ギミック
        Gimmick();
        //移動
        Gim_GO();
    }
    //仮のステージ
    public void CreateObject()
    {
        //X方向にCreateObjの数だけ出す
        for(int X = 0; X < CreateObj; X++)
        {
            //Z方向にCreateObjの数だけ出す
            for (int Z = 0; Z < CreateObj; Z++)
            {
                //生成
                Instantiate(Obj[0], new Vector3(+X, 0, -Z), transform.rotation);
                Debug.Log("生成数："+CreateObj+"個");
            }
        }
    }
    //ギミック
    public void Gimmick()
    {
        time += Time.deltaTime;
        if (time >= 2)
        {
            for (int i = 0; i < Gim; i++)
            {
                int number_X = Random.Range(10, -10);
                int number_Z = Random.Range(10, -10);
                test =Instantiate(Obj[1], new Vector3(number_X, 10, number_Z), transform.rotation);
                test_b = true;
            }
            time = 0;
            
        }
    }
    //移動
    public void Gim_GO()
    {
        if (test_b == true)
        {
            //位置座標の固定
            Vector3 pos = test.gameObject.transform.position;
            //速さ
            float number = Random.Range(1, 0.01f);
            //移動
            test.gameObject.transform.position = new Vector3(pos.x, pos.y - number, pos.z);
        }  
    }
}
