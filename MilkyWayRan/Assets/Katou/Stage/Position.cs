using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    //速度変数
    public float speed = 1.0f;

    private Rigidbody _rigidBody;

    // ターゲットオブジェクトの Transform を格納する変数
    public Transform target;

    // ターゲットオブジェクトの座標からオフセットする値
    public float offset;

    float time = 0.0f;

    private bool isCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {   
        time = time + Time.deltaTime;
        if (time >= 0.0f)
        {
            if (isCalled == false)
            {
                isCalled = true;
                Pos1();
            }       
        }

        if (time >= 60.0f)
        {
            if (isCalled == false)
            {
                isCalled = true;
                Pos2();
            }
            Debug.Log("Time Out");
        }
    }

    void Pos1()
    {
        if(gameObject.tag == "Right")
        {
            // オブジェクトの座標を変数 pos に格納
            Vector3 pos = transform.position;
            // 変数 posのX座標に代入
            pos.x = target.position.x + offset;
            // 変数 pos の値をオブジェクト座標に格納
            transform.position = pos;
        }

        if (gameObject.tag == "Left")
        {
            // オブジェクトの座標を変数 pos に格納
            Vector3 pos = transform.position;
            // 変数 posのX座標に代入
            pos.x = target.position.x + offset;
            // 変数 pos の値をオブジェクト座標に格納
            transform.position = pos;
        }
    }

    void Pos2()
    {
       
    }

}
