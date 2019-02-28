using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//プレイヤー参加ロビー
public class Play_Entry : MonoBehaviour
{
    /// <summary>
    /// ロビー時間設定
    /// </summary>
    //ロビー時間
    public float Lobby_Tim = 60;
    //インターバル時間
    public float Count_Dow=10;
    //延長の場合
    public bool Count_Bl;

    /// <summary>
    /// プレイヤー設定
    /// </summary>
    //プレイヤーは4人
    public GameObject[] Player=new GameObject[4];
    //プレイヤーの参加
    public bool[] OK_pl =new bool[4];
    //プレイヤーの生成位置座標
    public Vector3[] Pl_pos=new Vector3[4];
    //プレイヤー消す時使う
    private GameObject[] PL=new GameObject[4];
    //ゲーム中にプレイヤーを生成しない
    public bool[] Game_PL;
    //ゲームに参加UI
    public GameObject[] Join_PL = new GameObject[4];

    /// <summary>
    /// ゲーム開始設定
    /// </summary>
    //カウントダウン1.2，3,スタート
    public Sprite[] Nanbaers=new Sprite[4];
    //表示UI
    public GameObject Count_UI;

    /// <summary>
    /// ゲーム中設定
    /// </summary>
    //星の親オブジェクト
    public GameObject Staer_S;
    //星画像
    public Image[] Ster_Img=new Image[6];
    //時間
    private float[] Count_Tim = new float[6];
    //点滅速度
    private float[] Step_Tim = new float[6];
    //星のアルファ値
    private float[] ToColor = new float[6];

    //シーンの名前
    public string NextSceneName;

    /// <summary>
    /// ゲージの表示設定
    /// </summary>
    //プレイヤーゲージ
    public GameObject[] Gage=new GameObject[4];

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

    /// <summary>
    /// ロビー時間処理設定
    /// </summary>
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
        //非表示カウントダウン
        Count_UI.SetActive(false);
    }

    /// <summary>
    /// Startに置いておくもの情報
    /// </summary>
    //初期設定
    public void Setting()
    {
        /// <summary>
        /// プレイヤー情報初期
        /// </summary>
        //プレイヤー1　非参加
        OK_pl[0] = false;
        //プレイヤー2　非参加
        OK_pl[1] = false;
        //プレイヤー3　非参加
        OK_pl[2] = false;
        //プレイヤー4　非参加
        OK_pl[3] = false;

        //ゲーム時間を非表示
        Staer_S.SetActive(false);

        /// <summary>
        /// ゲームタイム情報初期
        /// </summary>
        //1星
        Count_Tim[0] = 12;
        //2星
        Count_Tim[1] = 12;
        //3星
        Count_Tim[2] = 12;
        //4星
        Count_Tim[3] = 12;
        //5星
        Count_Tim[4] = 12;
        //6星
        Count_Tim[5] = 12;

        /// <summary>
        /// 星点滅処理初期
        /// </summary>
        //1星点滅
        Step_Tim[0]= 0.033f;
        //2星点滅
        Step_Tim[1] = 0.033f;
        //3星点滅
        Step_Tim[2] = 0.033f;
        //4星点滅
        Step_Tim[3] = 0.033f;
        //5星点滅
        Step_Tim[4] = 0.033f;
        //6星点滅
        Step_Tim[5] = 0.033f;

        ///<summary>
        ///参加UI処理初期
        /// </summary>
        //1プレイヤー非表示
        Join_PL[0].SetActive(false);
        //2プレイヤー非表示
        Join_PL[1].SetActive(false);
        //3プレイヤー非表示
        Join_PL[2].SetActive(false);
        //4プレイヤー非表示
        Join_PL[3].SetActive(false);

        /// <summary>
        /// ゲージ処理初期
        /// </summary>
        //1プレイヤーのゲージ非表示
        Gage[0].SetActive(false);
        //2プレイヤーのゲージ非表示
        Gage[1].SetActive(false);
        //3プレイヤーのゲージ非表示
        Gage[2].SetActive(false);
        //4プレイヤーのゲージ非表示
        Gage[3].SetActive(false);
    }

    /// <summary>
    /// プレイヤー処理情報
    /// </summary>
    //プレイヤー参加操作情報
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
                //ゲームに参加UI表示
                Join_PL[0].SetActive(true);
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
                //ゲームに参加UI非表示
                Join_PL[0].SetActive(false);
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
                //ゲームに参加UI表示
                Join_PL[1].SetActive(true);
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
                //ゲームに参加UI非表示
                Join_PL[1].SetActive(false);
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
                //ゲームに参加UI表示
                Join_PL[2].SetActive(true);
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
                //ゲームに参加UI非表示
                Join_PL[2].SetActive(false);
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
                //ゲームに参加UI表示
                Join_PL[3].SetActive(true);
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
                //ゲームに参加UI非表示
                Join_PL[3].SetActive(false);
            }
        }
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

    /// <summary>
    /// ロビー時間とゲーム時間処理情報
    /// </summary>
    //ゲーム開始と運営
    public void Start_Game()
    {
        //開始までのカウントダウン
        Count_Dow -= Time.deltaTime;
        //スタート3秒前
        if (Count_Dow <= 4)
        {
            //表示カウントダウン
            Count_UI.SetActive(true);
            //3を表示
            Count_UI.gameObject.GetComponent<Image>().sprite = Nanbaers[3];
        }
        //スタート2秒前
        if (Count_Dow <= 3)
        {
            //2を表示
            Count_UI.gameObject.GetComponent<Image>().sprite = Nanbaers[2];
        }
        //スタート1秒前
        if (Count_Dow <=2)
        {
            //1を表示
            Count_UI.gameObject.GetComponent<Image>().sprite = Nanbaers[1];
        }
        //スタート0秒
        if (Count_Dow <= 1)
        {
            //スターを表示
            Count_UI.gameObject.GetComponent<Image>().sprite = Nanbaers[0];
        }
        //カウントダウンが0になったら
        if (Count_Dow <= 0)
        {
            //非表示カウントダウン
            Count_UI.SetActive(false);
            //カウントダウンをやめる
            Count_Dow = -1;
            //ロビーの時間を止める
            Count_Bl = true;

            //プレイヤー生成をしない
            Game_PL[0] = true;
            Game_PL[1] = true;
            Game_PL[2] = true;
            Game_PL[3] = true;

            //参加UI非表示
            Join_PL[0].SetActive(false);
            Join_PL[1].SetActive(false);
            Join_PL[2].SetActive(false);
            Join_PL[3].SetActive(false);

            //ゲームタイムを表示
            Staer_S.SetActive(true);

            //スタートゲームタイマー
            Star1();
            //プレイヤーゲージ表示
            Plays_Gage();
        }
    }

    /// <summary>
    /// ゲーム時間の処理情報設定
    /// </summary>
    //1個目の星点滅処理（ゲームタイマー開始）
    public void Star1()
    {
        //1星
        Count_Tim[0] -= Time.deltaTime;
        //現在のアルファ値を取得
        ToColor[0] = Ster_Img[0].GetComponent<Image>().color.a;
        //アルファが0または１になったら
        if (ToColor[0] < 0 || ToColor[0] > 1)
        {
            //増減値を反転
            Step_Tim[0] = Step_Tim[0] * -1;
        }
        //アルファ値を反転
        Ster_Img[0].GetComponent<Image>().color = new Color(255, 255, 255, ToColor[0] + Step_Tim[0]);

        //1星のカウント0で終了
        if (Count_Tim[0]<=0)
        {
            //カウントを0にする
            Count_Tim[0] = 0;
            //点滅を終了する
            Step_Tim[0] = 0;
            //星の点滅をなくす
            Ster_Img[0].GetComponent<Image>().color = new Color(0, 0, 0 + Step_Tim[0]);
            //2星へ
            Star2();
        }
    }
    //2個目の星点滅処理
    public void Star2()
    {
        //2星
        Count_Tim[1] -= Time.deltaTime;
        //現在のアルファ値を取得
        ToColor[1] = Ster_Img[1].GetComponent<Image>().color.a;
        //アルファが0または１になったら
        if (ToColor[1] < 0 || ToColor[1] > 1)
        {
            //増減値を反転
            Step_Tim[1] = Step_Tim[1] * -1;
        }
        //アルファ値を反転
        Ster_Img[1].GetComponent<Image>().color = new Color(255, 255, 255, ToColor[1] + Step_Tim[1]);

        //2星のカウント0で終了
        if (Count_Tim[1] <= 0)
        {
            //カウントを0にする
            Count_Tim[1] = 0;
            //点滅を終了する
            Step_Tim[1] = 0;
            //星の点滅をなくす
            Ster_Img[1].GetComponent<Image>().color = new Color(0, 0, 0 + Step_Tim[1]);
            //3星へ
            Star3();
        }
    }
    //3個目の星点滅処理
    public void Star3()
    {
        //3星
        Count_Tim[2] -= Time.deltaTime;
        //現在のアルファ値を取得
        ToColor[2] = Ster_Img[2].GetComponent<Image>().color.a;
        //アルファが0または１になったら
        if (ToColor[2] < 0 || ToColor[2] > 1)
        {
            //増減値を反転
            Step_Tim[2] = Step_Tim[2] * -1;
        }
        //アルファ値を反転
        Ster_Img[2].GetComponent<Image>().color = new Color(255, 255, 255, ToColor[2] + Step_Tim[2]);

        //3星のカウント0で終了
        if (Count_Tim[2] <= 0)
        {
            //カウントを0にする
            Count_Tim[2] = 0;
            //点滅を終了する
            Step_Tim[2] = 0;
            //星の点滅をなくす
            Ster_Img[2].GetComponent<Image>().color = new Color(0, 0, 0 + Step_Tim[2]);
            //4星へ
            Star4();
        }
    }
    //4個目の星点滅処理
    public void Star4()
    {
        //4星
        Count_Tim[3] -= Time.deltaTime;
        //現在のアルファ値を取得
        ToColor[3] = Ster_Img[3].GetComponent<Image>().color.a;
        //アルファが0または１になったら
        if (ToColor[3] < 0 || ToColor[3] > 1)
        {
            //増減値を反転
            Step_Tim[3] = Step_Tim[3] * -1;
        }
        //アルファ値を反転
        Ster_Img[3].GetComponent<Image>().color = new Color(255, 255, 255, ToColor[3] + Step_Tim[3]);

        //4星のカウント0で終了
        if (Count_Tim[3] <= 0)
        {
            //カウントを0にする
            Count_Tim[3] = 0;
            //点滅を終了する
            Step_Tim[3] = 0;
            //星の点滅をなくす
            Ster_Img[3].GetComponent<Image>().color = new Color(0, 0, 0 + Step_Tim[3]);
            //5星へ
            Star5();
        }
    }
    //5個目の星点滅処理
    public void Star5()
    {
        //5星
        Count_Tim[4] -= Time.deltaTime;
        //現在のアルファ値を取得
        ToColor[4] = Ster_Img[4].GetComponent<Image>().color.a;
        //アルファが0または１になったら
        if (ToColor[4] < 0 || ToColor[4] > 1)
        {
            //増減値を反転
            Step_Tim[4] = Step_Tim[4] * -1;
        }
        //アルファ値を反転
        Ster_Img[4].GetComponent<Image>().color = new Color(255, 255, 255, ToColor[4] + Step_Tim[4]);

        //5星のカウント0で終了
        if (Count_Tim[4] <= 0)
        {
            //カウントを0にする
            Count_Tim[4] = 0;
            //点滅を終了する
            Step_Tim[4] = 0;
            //星の点滅をなくす
            Ster_Img[4].GetComponent<Image>().color = new Color(0, 0, 0 + Step_Tim[4]);
            //6星へ
            Star6();
        }
    }
    //6個目の星点滅処理（ゲームタイマー終了）
    public void Star6()
    {
        //5星
        Count_Tim[5] -= Time.deltaTime;
        //現在のアルファ値を取得
        ToColor[5] = Ster_Img[5].GetComponent<Image>().color.a;
        //アルファが0または１になったら
        if (ToColor[5] < 0 || ToColor[5] > 1)
        {
            //増減値を反転
            Step_Tim[5] = Step_Tim[5] * -1;
        }
        //アルファ値を反転
        Ster_Img[5].GetComponent<Image>().color = new Color(255, 255, 255, ToColor[5] + Step_Tim[5]);

        //6星のカウント0で終了
        if (Count_Tim[5] <= 0)
        {
            //カウントを0にする
            Count_Tim[5] = 0;
            //点滅を終了する
            Step_Tim[5] = 0;
            //星の点滅をなくす
            Ster_Img[5].GetComponent<Image>().color = new Color(0, 0, 0 + Step_Tim[5]);

            //シーン移動
            Scene_GO();
        }
    }

    //シーン移動
    public void Scene_GO()
    {
        //名前宣言したシーンへ
        SceneManager.LoadScene(NextSceneName);
    }

    /// <summary>
    /// プレイヤーのゲージ情報設定
    /// </summary>
    //プレイヤーゲージ情報
    public void Plays_Gage()
    {
        //1プレイヤーゲージ
        Play1_Gage();
        //2プレイヤーゲージ
        Play2_Gage();
        //3プレイヤーゲージ
        Play3_Gage();
        //4プレイヤーゲージ
        Play4_Gage();
    }
    //1プレイヤーゲージ
    public void Play1_Gage()
    {
        //1プレイヤーがゲームに参加なら
        if (OK_pl[0]==true)
        {
            //1プレイヤーのゲージを表示
            Gage[0].SetActive(true);
        }
    }
    //2プレイヤーゲージ
    public void Play2_Gage()
    {
        //2プレイヤーがゲームに参加なら
        if (OK_pl[1] == true)
        {
            //2プレイヤーのゲージを表示
            Gage[1].SetActive(true);
        }
    }
    //3プレイヤーゲージ
    public void Play3_Gage()
    {
        //3プレイヤーがゲームに参加なら
        if (OK_pl[2] == true)
        {
            //3プレイヤーのゲージを表示
            Gage[2].SetActive(true);
        }
    }
    //4プレイヤーゲージ
    public void Play4_Gage()
    {
        //4プレイヤーがゲームに参加なら
        if (OK_pl[3] == true)
        {
            //4プレイヤーのゲージを表示
            Gage[3].SetActive(true);
        }
    }

}
