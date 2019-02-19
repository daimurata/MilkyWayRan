using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//プレイヤー参加ロビー
public class Play_Entry : MonoBehaviour
{
    //ロビー時間
    public float Lobby_Tim = 60;
    //インターバル時間
    public float Count_Dow=10;
    //延長の場合
    public bool Count_Bl;
    //プレイヤーは4人
    public GameObject[] Player;
    //プレイヤーの参加
    public bool[] OK_pl;
    //プレイヤーの生成位置座標
    public Vector3[] Pl_pos;
    //プレイヤー消す時使う
    public GameObject[] PL;
    //シーンの名前
    public string NextSceneName;

    void Start()
    {
        //初期設定
        Setting();
    }

    
    void Update()
    {
        //ロビー制限時間
        Timer_Lobby();
        //プレイヤー参加操作
        Player_Set();
    }
    //ロビー制限時間
    public void Timer_Lobby()
    {
        if (Count_Bl == false)
        {
            //ロビー時間60秒
            Lobby_Tim -= Time.deltaTime;
        }

        //ロビーの時間が0以下の時
        if (Lobby_Tim <= 0)
        {
            Count_Bl = true;
            //ロビーの時間を60秒に
            Lobby_Tim = 60;
            //延長を起動
            
        }
        //延長時間
        if (Count_Bl == true)
        {
            //ロビー時間延長60秒
            Lobby_Tim -= Time.deltaTime;
        }
    }
    //初期設定
    public void Setting()
    {
        //プレイヤー1　非参加
        OK_pl[0] = false;
        //プレイヤー2　非参加
        OK_pl[1] = false;
        //プレイヤー3　非参加
        OK_pl[2] = false;
        //プレイヤー4　非参加
        OK_pl[3] = false;
    }
    //プレイヤー参加操作
    public void Player_Set()
    {
        //プレイヤー1
        Pl_1();
        //プレイヤー2
        Pl_2();
        //プレイヤー3
        Pl_3();
        //プレイヤー4
        Pl_4();
    }
    //プレイヤー1
    public void Pl_1()
    {
        //プレイヤーが非参加
        if (OK_pl[0] == false)
        {
            //Aキーを押したら
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("参加");
                //プレイヤー1参加
                OK_pl[0] = true;
                //プレイヤー1生成
                PL[0] = Instantiate(Player[0], new Vector3(Pl_pos[0].x, Pl_pos[0].y, Pl_pos[0].z), transform.rotation);
            }
        }
        //プレイヤーが参加なら
        else
        {
            //Aキーを押したら
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("非参加");
                //プレイヤー1参加
                OK_pl[0] = false;
                //プレイヤー1消す
                Destroy(PL[0]);
            }
        }
    }
    //プレイヤー2
    public void Pl_2()
    {
        //プレイヤー2が非参加
        if (OK_pl[1] == false)
        {
            //Sキーを押したら
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("参加");
                //プレイヤー2参加
                OK_pl[1] = true;
                //プレイヤー2生成
                PL[1] = Instantiate(Player[1], new Vector3(Pl_pos[1].x, Pl_pos[1].y, Pl_pos[1].z), transform.rotation);
            }
        }
        //プレイヤー2が参加なら
        else
        {
            //Sキーを押したら
            if (Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("非参加2");
                //プレイヤー2参加
                OK_pl[1] = false;
                //プレイヤー2消す
                Destroy(PL[1]);
            }
        }
    }
    //プレイヤー3
    public void Pl_3()
    {
        //プレイヤー3が非参加
        if (OK_pl[2] == false)
        {
            //Dキーを押したら
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("参加3");
                //プレイヤー3参加
                OK_pl[2] = true;
                //プレイヤー3生成
                PL[2] = Instantiate(Player[2], new Vector3(Pl_pos[2].x, Pl_pos[2].y, Pl_pos[2].z), transform.rotation);
            }
        }
        //プレイヤー3が参加なら
        else
        {
            //Dキーを押したら
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log("非参加3");
                //プレイヤー3参加
                OK_pl[2] = false;
                //プレイヤー3消す
                Destroy(PL[2]);
            }
        }
    }
    //プレイヤー4
    public void Pl_4()
    {
        //プレイヤー4が非参加
        if (OK_pl[3] == false)
        {
            //Fキーを押したら
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("参加4");
                //プレイヤー4参加
                OK_pl[3] = true;
                //プレイヤー4生成
                PL[3] = Instantiate(Player[3], new Vector3(Pl_pos[3].x, Pl_pos[3].y, Pl_pos[3].z), transform.rotation);
            }
        }
        //プレイヤー4が参加なら
        else
        {
            //Fキーを押したら
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("非参加4");
                //プレイヤー4参加
                OK_pl[3] = false;
                //プレイヤー4消す
                Destroy(PL[3]);
            }
        }
    }
    //シーン移動
    public void Scene_GO()
    {
        //シーンの名前に移動
        SceneManager.LoadScene(NextSceneName);
    }
}
