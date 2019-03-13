using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージ移動
/// </summary>
public class Position : MonoBehaviour
{
    //移動[0]がMAX[0]がMIN
    public float[] pos = new float[2];
    //動かすオブジェクト
    public GameObject[] moveObj = new GameObject[2];
    //動くための許可
    public static bool[] OK_GO = new bool[2];
    //目的場所
    public float[] MAX = new float[2];
    //目的場所2
    public float[] MIN = new float[2];
    //スピード
    public float Speed = 0.5f;
    //移動させる名前
    public string[] Name = new string[2];

    void Start()
    {
        //初期値
        pos[0] = 1;
        pos[1] = -1;
        MAX[0] = -44;
        MAX[1] = 143;
        MIN[0] = -143;
        MIN[1] = 44;
    }

    void Update()
    {
        //参照
        Vector3 POS_1 = GameObject.Find(Name[0]).transform.position;
        Vector3 POS_2 = GameObject.Find(Name[1]).transform.position;

        //←→に行くとき
        if (OK_GO[0])
        {
            //他のログが表示の判別がつかないのでDebug.Log消します
            //今の座標にスピードをかける
            moveObj[0].transform.position += new Vector3(pos[0] * Speed, 0, 0);
            //Debug.Log("やじ←" + moveObj[0] + "移動");
            moveObj[1].transform.position += new Vector3(pos[1] * Speed, 0, 0);
            //Debug.Log("やじ→" + moveObj[1] + "移動");
            //目的場所を超えたら
            if (POS_1.x >= MAX[0] && POS_2.x <= MIN[1])
            {
                //同じにする
                POS_1.x = MAX[0];
                POS_2.x = MIN[1];
                //移動終了
                OK_GO[0] = false;
            }
        }
        //→←に行くとき
        if (OK_GO[1])
        {
            //今の座標にスピードをかける
            moveObj[0].transform.position += new Vector3(pos[1] * Speed, 0, 0);
            Debug.Log("やじ→" + moveObj[0] + "移動→←");
            moveObj[1].transform.position += new Vector3(pos[0] * Speed, 0, 0);
            Debug.Log("やじ←" + moveObj[1] + "移動→←");
            //目的場所を超えたら
            if (POS_1.x <= MIN[0] && POS_2.x >= MAX[1])
            {
                //同じにする
                POS_1.x = MIN[0];
                POS_2.x = MAX[1];
                //移動終了
                OK_GO[1] = false;
            }
        }
    }
    //ステージ移動
    public static void Mov_Stage()
    {
        //trueなら←→
        OK_GO[0]=true;
    } 
}



