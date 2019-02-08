using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taihou : MonoBehaviour
{
    public float taihouspeed = 1.0f;//砲身を回す速度
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       float x = Input.GetAxis("Horizontal taihou");//左右
    　 //xが+なら右-なら左に砲身を回す
       //0.5なのは、コンローラーのせい
       if( x > 0.5 || x < -0.5)
       {
            transform.Rotate(0, x * taihouspeed, 0);
       }
        
    }
}
