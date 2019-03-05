using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taitol : MonoBehaviour
{
    //インスタンスされるオブジェクト
    private GameObject obj;
    //輪郭を付けるオブジェクト
    public GameObject Startmozi;
    //輪郭
    public GameObject Rinkaku;
    //何秒でフェードアウトするかを指定する
    public float fadeTime;
    //時間を計測するための処理
    bool isCountdownStart;
    //フェードアウトするまでの時間
    private float currentRemainTime;
    SpriteRenderer spRenderer;
    //1回だけ処理されるようにする
    bool one;
    // Start is called before the first frame update
    void Start()
    {
        //フェードアウトするまでの時間を決定する
        currentRemainTime = fadeTime;
        //oneをtrueにする
        one = true;
     
    }

    // Update is called once per frame
    void Update()
    {
       //Zキーが押された時
        if (Input.GetKey(KeyCode.Z))
        {
            //oneがtrueなら
            if (one)
            {
                //輪郭を生成する
                 obj = GameObject.Instantiate(Rinkaku) as GameObject;
                //輪郭に設定されているSpriteRendererを取得
                spRenderer = obj.GetComponent<SpriteRenderer>();
                //輪郭の場所を輪郭を付けたい文字と合わせる
                obj.transform.position = Startmozi.transform.position;
                //oneをfalseにする
                one = false;
            }
            //カウントをスタートする
            isCountdownStart = true;
            //輪郭を大きくする
            StartCoroutine(ChangePaneltoBigSize());
         

        }
        //フェードアウトの処理
        if (isCountdownStart&& currentRemainTime>0.0f)
        {
            // フェードアウトするまでの時間を更新
            currentRemainTime -= Time.deltaTime;
            // フェードアウト
            float alpha = currentRemainTime / fadeTime;
            var color = spRenderer.color;
            color.a = alpha;
            spRenderer.color = color;
        }
        //カウントが0になったら
        if (currentRemainTime <= 0f)
        {
            // 残り時間が無くなったら自分自身を消滅
            Destroy(obj.gameObject);
            //カウントをやめる
            isCountdownStart = false;
            return;
        }
        //輪郭を大きくする
        IEnumerator ChangePaneltoBigSize()
        {
            var saize = 0f;
            var speed = 0.05f;

            while (saize <= 1.0f)
            {
                obj.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), new Vector3(1.1f, 1.1f, 1.1f), saize);
                saize += speed;
                yield return null;
            }

        }
    }
  
}
