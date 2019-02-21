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
    //ゲーム中にプレイヤーを生成しない
    public bool[] Game_PL;

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
        //プレイヤー参加情報
        Standby_Fore();
    }
    //ロビー制限時間
    public void Timer_Lobby()
    {
        //初期設定
        if (Count_Bl == false)
        {
            //ロビー時間60秒
            Lobby_Tim -= Time.deltaTime;
        }
        //ロビー時間の延長
        Looby_Timer();
    }
    //ロビー時間の延長
    public void Looby_Timer()
    {
        //ロビーの時間が0以下の時
        if (Lobby_Tim <= 0)
        {
            //ロビーの時間を60秒に
            Lobby_Tim = 60;
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
            if (Input.GetKeyDown(KeyCode.A)&& Game_PL[0] == false)
            {
                //ゲームスタートするまでの時間
                Count_Dow = 10;
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
            if (Input.GetKeyDown(KeyCode.A)&& Game_PL[0] == false)
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
            if (Input.GetKeyDown(KeyCode.S)&& Game_PL[1] == false)
            {
                //ゲームスタートするまでの時間
                Count_Dow = 10;
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
            if (Input.GetKeyDown(KeyCode.S)&& Game_PL[1] == false)
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
            if (Input.GetKeyDown(KeyCode.D)&&Game_PL[0] == false)
            {
                //ゲームスタートするまでの時間
                Count_Dow = 10;
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
            if (Input.GetKeyDown(KeyCode.D)&& Game_PL[2] == false)
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
            if (Input.GetKeyDown(KeyCode.F)&&Game_PL[3] == false)
            {
                //ゲームスタートするまでの時間
                Count_Dow = 10;
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
            if (Input.GetKeyDown(KeyCode.F)&&Game_PL[3] == false)
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
    //プレイヤー参加情報
    public void Standby_Fore()
    {
        //4人参加
        if (OK_pl[0]==true&&OK_pl[1]==true&&OK_pl[2]==true&&OK_pl[3]==true)
        {
            Debug.Log("全員が参加します");
            //ゲーム開始までのインターバル
            Start_Game();
        }else
        //1,2,3参加
        if (OK_pl[0] == true && OK_pl[1] == true && OK_pl[2] == true)
        {
            Debug.Log("1Pと2Pと3Pが戦います");
            //ゲーム開始までのインターバル
            Start_Game();
        }else
        //1,2,4参加
        if (OK_pl[0] == true && OK_pl[1] == true && OK_pl[3] == true)
        {
            Debug.Log("1Pと2Pと4Pが戦います");
            //ゲーム開始までのインターバル
            Start_Game();
        }else
        //1,3,4参加
        if(OK_pl[0] == true && OK_pl[2] == true && OK_pl[3] == true)
        {
            Debug.Log("1Pと3Pと4Pが戦います");
            //ゲーム開始までのインターバル
            Start_Game();
        }else
        //2,3,4参加
        if (OK_pl[1] == true && OK_pl[2] == true && OK_pl[3] == true)
        {
            Debug.Log("2Pと3Pと4Pが戦います");
            //ゲーム開始までのインターバル
            Start_Game();
        }else
        //1,2参加
        if (OK_pl[0] == true && OK_pl[1] == true)
        {
            Debug.Log("1Pと2Pが戦います");
            //ゲーム開始までのインターバル
            Start_Game();
        }else
        //1,3参加
        if (OK_pl[0] == true && OK_pl[2] == true)
        {
            Debug.Log("1Pと3Pが戦います");
            //ゲーム開始までのインターバル
            Start_Game();
        }else
        //1,4参加
        if (OK_pl[0] == true && OK_pl[3] == true)
        {
            Debug.Log("1Pと4Pが戦います");
            //ゲーム開始までのインターバル
            Start_Game();
        }else
        //2,3参加
        if (OK_pl[1] == true && OK_pl[2] == true)
        {
            Debug.Log("2Pと3Pが戦います");
            //ゲーム開始までのインターバル
            Start_Game();
        }else
        //2,4参加
        if (OK_pl[1] == true && OK_pl[3] == true)
        {
            Debug.Log("2Pと4Pが戦います");
            //ゲーム開始までのインターバル
            Start_Game();
        }else
        //3,4参加
        if (OK_pl[2] == true && OK_pl[3] == true)
        {
            Debug.Log("3Pと4Pが戦います");
            //ゲーム開始までのインターバル
            Start_Game();
        }else
        //1参加
        if (OK_pl[0] == true)
        {
            Debug.Log("1Pが1人です");
            //ロビー時間の延長
            Looby_Timer();
        }else
        //2参加
        if (OK_pl[1] == true)
        {
            Debug.Log("2Pが1人です");
            //ロビー時間の延長
            Looby_Timer();
        }else
        //3参加
        if (OK_pl[2] == true)
        {
            Debug.Log("3Pが1人です");
            //ロビー時間の延長
            Looby_Timer();
        }else
        //4参加
        if (OK_pl[3] == true)
        {
            Debug.Log("4Pが1人です");
            //ロビー時間の延長
            Looby_Timer();
        }else
        //全員非参加
        if (OK_pl[0]==false&&OK_pl[1]==false&&OK_pl[2]==false&&OK_pl[3]==false)
        {
            Debug.Log("誰も参加しません");
            //ロビー時間の延長
            Looby_Timer();
        }
    }
    //ゲーム開始までのインターバル
    public void Start_Game()
    {
        //開始までのカウントダウン
        Count_Dow -= Time.deltaTime;
        //カウントダウンが0になったら
        if (Count_Dow<=0)
        {
            //カウントダウンをやめる
            Count_Dow = 0;
            //ロビーの時間を止める
            Count_Bl = true;
            //プレイヤー生成をしない
            Game_PL[0] = true;
            Game_PL[1] = true;
            Game_PL[2] = true;
            Game_PL[3] = true;
            Debug.Log("ゲームスタート1，2，3");
        }
    }
}
