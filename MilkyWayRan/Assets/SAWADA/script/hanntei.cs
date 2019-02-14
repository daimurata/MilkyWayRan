﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hanntei : MonoBehaviour
{

    public float thrust;
 
    public Rigidbody rd;
    //当たり判定
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            rd.isKinematic = false;
            rd.AddForce(transform.right * thrust);
            Debug.Log("ぶつかった");
        }

    }
    void OnTriggerExit(Collider coll)
    {
        if (rd.isKinematic == false)
        {
            Invoke("Stop", 1.0f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Stop()
    {
        rd.isKinematic = true;
    }
}
