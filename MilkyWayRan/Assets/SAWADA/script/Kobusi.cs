﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kobusi : MonoBehaviour
{

    void OnBecameInvisible()
    {
    
        //画面外に出たらオブジェクトを消す
        Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
