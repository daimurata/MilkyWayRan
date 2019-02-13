using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    public float bulletspeed = 1.0f;//弾の速度
    public float Destroybullet = 5.0f;//弾の消える時間
  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.forward * bulletspeed * Time.deltaTime;
        Destroy(gameObject, Destroybullet);//数秒後弾を消す
    }
     public void bulletshot()
    {   
    }
}
