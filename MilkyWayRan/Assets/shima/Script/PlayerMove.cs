using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //ここでプレイヤー関連のやつ移動とかHPまとめてやります


    //自分の番号、Inspectorで変更してね
    public int PlayerNum;
    //相手の番号、Inspectorで変更してね
    public int EnemyNum1;
    public int EnemyNum2;
    public int EnemyNum3;
    //移動スピード
    public float PlayerSpeed = 5.0f;
    //HP
    public int PlayerHP = 10;

    //体当たりダメージ
    public int TackleDamage = 5;

    Attak attakscript;
    Hisatu hisatuscript;

    //アニメーター関連をコピってきたもの
    private Rigidbody _rigidBody;

    private Animator animator;

    public GameObject efect1;
    public GameObject efect2;

    //無敵（一時的にダメージを無くすためのもの）
    private bool isCollision = true;
    //無敵時間、Inspectorで変更できるよ
    public float invincible = 3;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    /// <summary>
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        //プレイヤーの移動
        Move(PlayerNum);
    }
    void Move(int Number)
    {
        Attak d1 = GetComponent<Attak>();
        Hisatu a1 = GetComponent<Hisatu>();

        //ボタン確認

        if (Input.GetButtonDown("Fire1_" + PlayerNum))
        {
            Debug.Log("Shot1_" + PlayerNum);
            d1.Kaiten();
            animator.SetBool("is_attack", true);
            Invoke("AnimatorBoolis_attack", 0.5f);
            _rigidBody.isKinematic = true;
            Invoke("RigidBodyfalse", 1.0f);
        }
        if (Input.GetButtonDown("Fire2_" + PlayerNum))
        {
            Debug.Log("Shot2_" + PlayerNum);
            d1.Syageki();
            animator.SetBool("is_attack", true);
            Invoke("AnimatorBoolis_attack", 0.5f);
            _rigidBody.isKinematic = true;
            Invoke("RigidBodyfalse", 1.0f);        
        }
        if (Input.GetButtonDown("Fire3_" + PlayerNum))
        {
            a1.hisatuskill();
            Debug.Log("Shot3_" + PlayerNum);
            animator.SetBool("is_attack", true);
            Invoke("AnimatorBoolis_attack", 0.5f);
        }
        //アナログスティックで動かせると思う
        float x = Input.GetAxis("Horizontal" + PlayerNum);//左右
        float y = Input.GetAxis("Vertical" + PlayerNum);//前後

        //transform.Rotate(0, x, 0);//回転
        //transform.position += y * transform.forward * PlayerSpeed * Time.deltaTime;//前後移動

        var direction = new Vector3(x, 0, y);

        if (x != 0 || y != 0)
        {
            //方向を向く
            transform.localRotation = Quaternion.LookRotation(direction);
            //方向に移動
            transform.position += PlayerSpeed * direction * Time.deltaTime;
            //_rigidBody.AddForce(direction * 1000);
            animator.SetBool("is_go", true);
        }
        else
        {
            animator.SetBool("is_go", false);
        }
    }
    public void HP(int Number, int amount)
    {
        Hisatu a1 = GetComponent<Hisatu>();
        //これのtrue,falseを切り替えて無敵時間の用意
        if (isCollision)
        {
            PlayerHP -= amount;
            isCollision = false;
            if (PlayerHP >= 0)
            {
                Debug.Log("プレイヤー" + Number + "が攻撃" + PlayerHP);
            }
            if (PlayerHP <= 0)
            {
                //Destroy(this.gameObject);
                //HP残量の確認をするためにSetActiveに変更
                this.gameObject.SetActive(false);
                Debug.Log("プレイヤー" + "死亡");
                //多分ここに死んだ時のアニメーション追加
            }
            //○○秒後trueにする
            Invoke("isCollisionfalse", invincible);
            //ここで受けるダメージをHisatu.csのSpecialGageに送る
            a1.SpecialGage(amount);
        }
    }
   
    void OnCollisionEnter(Collision col)
    {
        float x = Input.GetAxis("Horizontal" + PlayerNum);//左右
        float y = Input.GetAxis("Vertical" + PlayerNum);//前後

        var direction = new Vector3(x, 0, y);

        bool TriggerFlag = true;

        //相手がプレイヤーの場合、プレイヤーの番号指定（Inspectorで変更）
        //体当たりでダメージが出る感じ
        if (TriggerFlag)
        {
            TriggerFlag = false;
            if (col.gameObject.tag == "Player" + EnemyNum1)
            {
                //爆発の生成
                var t = Instantiate(efect1, this.transform.position, Quaternion.identity);
                /////
                Debug.Log(PlayerNum + "がダメージをうけた");
                animator.SetBool("is_damage", true);
                Invoke("AnimatorBoolis_damage", 0.5f);
                //////
                var hit = col.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    //ここがプレイヤーの入力方向と逆の方向に無理やり飛ばす処理
                    _rigidBody.AddForce(-direction * 100,ForceMode.Impulse);
                    health.HP(PlayerNum, TackleDamage);
                }
            }
        }
        if (TriggerFlag)
        {
            TriggerFlag = false;
            if (col.gameObject.tag == "Player" + EnemyNum2)
            {
                //爆発の生成
                var t = Instantiate(efect1, this.transform.position, Quaternion.identity);
                /////
                Debug.Log(PlayerNum + "がダメージをうけた");
                animator.SetBool("is_damage", true);
                Invoke("AnimatorBoolis_damage", 0.5f);
                //////
                var hit = col.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    //ここがプレイヤーの入力方向と逆の方向に無理やり飛ばす処理
                    _rigidBody.AddForce(-direction * 100, ForceMode.Impulse);
                    health.HP(PlayerNum, TackleDamage);
                }
            }
        }
        if (TriggerFlag)
        {
            TriggerFlag = false;
            if (col.gameObject.tag == "Player" + EnemyNum3)
            {
                //爆発の生成
                var t = Instantiate(efect1, this.transform.position, Quaternion.identity);
                /////
                Debug.Log(PlayerNum + "がダメージをうけた");
                animator.SetBool("is_damage", true);
                Invoke("AnimatorBoolis_damage", 0.5f);
                //////
                var hit = col.gameObject;
                var health = hit.GetComponent<PlayerMove>();
                if (health != null)
                {
                    //ここがプレイヤーの入力方向と逆の方向に無理やり飛ばす処理
                    _rigidBody.AddForce(-direction * 100, ForceMode.Impulse);
                    health.HP(PlayerNum, TackleDamage);
                }
            }
        }

        //相手がBulletの場合、弾の番号指定（Inspectorで変更）
        if (col.gameObject.tag == "Bullet" + EnemyNum1)
        {
            //小さい爆発の生成
            var t = Instantiate(efect2, col.transform.position, Quaternion.identity);
            Debug.Log(PlayerNum + "がダメージをうけた");
            animator.SetBool("is_damage", true);
            Invoke("AnimatorBoolis_damage", 0.5f);
        }
        if (col.gameObject.tag == "Bullet" + EnemyNum2)
        {
            //小さい爆発の生成
            var t = Instantiate(efect2, col.transform.position, Quaternion.identity);
            Debug.Log(PlayerNum + "がダメージをうけた");
            animator.SetBool("is_damage", true);
            Invoke("AnimatorBoolis_damage", 0.5f);
        }
        if (col.gameObject.tag == "Bullet" + EnemyNum3)
        {
            //小さい爆発の生成
            var t = Instantiate(efect2, col.transform.position, Quaternion.identity);
            Debug.Log(PlayerNum + "がダメージをうけた");
            animator.SetBool("is_damage", true);
            Invoke("AnimatorBoolis_damage", 0.5f);
        }

        //相手がStarの場合、Starの番号指定（Inspectorで変更）
        if (col.gameObject.tag == "Star" + EnemyNum1)
        {
            //小さい爆発の生成
            var t = Instantiate(efect2, col.transform.position, Quaternion.identity);
            Debug.Log(PlayerNum + "がダメージをうけた");
            animator.SetBool("is_damage", true);
            Invoke("AnimatorBoolis_damage", 0.5f);
        }
        if (col.gameObject.tag == "Star" + EnemyNum2)
        {
            //小さい爆発の生成
            var t = Instantiate(efect2, col.transform.position, Quaternion.identity);
            Debug.Log(PlayerNum + "がダメージをうけた");
            animator.SetBool("is_damage", true);
            Invoke("AnimatorBoolis_damage", 0.5f);
        }
        if (col.gameObject.tag == "Star" + EnemyNum3)
        {
            //小さい爆発の生成
            var t = Instantiate(efect2, col.transform.position, Quaternion.identity);
            Debug.Log(PlayerNum + "がダメージをうけた");
            animator.SetBool("is_damage", true);
            Invoke("AnimatorBoolis_damage", 0.5f);
        }
    }
    //↓のやつらはBoolをInvokeで呼び出すためだけに作成したものです
    void AnimatorBoolis_damage()
    {
        //is_damage
        //falseを呼び出すだけのため
        animator.SetBool("is_damage", false);
        
    }
    void AnimatorBoolis_attack()
    {
        //is_attack
        animator.SetBool("is_attack", false);
    }
    void RigidBodyfalse()
    {
        _rigidBody.isKinematic = false;
    }
    void isCollisionfalse()
    {
        isCollision = true;
    }

}
 
