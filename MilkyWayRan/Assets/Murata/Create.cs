using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//上から隕石ギミック

public class Create : MonoBehaviour
{
    public GameObject[] Obj;//仮のステージオブジェクト
    public int CreateObj = 10;//範囲
    public float time = 0;//ギミック生成時間
    public int Gim = 1;//ギミックの数
    private GameObject Gim_mov;//ギミックの移動
    private bool Gim_mov_Go = false;//動かす許可

    //ギミックOK
    static bool Gim_OK = false;
    void Start()
    {
        //仮のステージ
       // CreateObject();
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
        //許可
        if (Gim_OK)
        {
            //タイム計算
            time += Time.deltaTime;
            //2秒以上ならランダムにしたら面白そう
            if (time >= 2)
            {
                //数だけ回す
                for (int i = 0; i < Gim; i++)
                {
                    //X座標のランダム
                    int number_X = Random.Range(10, -10);
                    //Z座標のランダム
                    int number_Z = Random.Range(10, -10);
                    //複数生成
                    Gim_mov = Instantiate(Obj[1], new Vector3(number_X, 10, number_Z), transform.rotation);
                    //動かしてよし
                    Gim_mov_Go = true;
                }
                //時間は0へ
                time = 0;
            }
        }
    }
    //移動
    public void Gim_GO()
    {
        //動かし許可が下りたら
        if (Gim_mov_Go == true)
        {
            //位置座標の固定
            Vector3 pos = Gim_mov.gameObject.transform.position;
            //速さ
            float number = Random.Range(1, 0.01f);
            //移動
            Gim_mov.gameObject.transform.position = new Vector3(pos.x, pos.y - number, pos.z);
        }  
    }

    //許可書
    public static void Gim_GOGO()
    {
        //許可
        Gim_OK = true;
    }
}
