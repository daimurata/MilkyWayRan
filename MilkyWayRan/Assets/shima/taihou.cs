using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taihou : MonoBehaviour
{
    
    public float taihouspeed = 1.0f;//砲身を回す速度

    public int PlayerNum;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal taihou" + PlayerNum);//左右
        float y = Input.GetAxis("Vertical taihou" + PlayerNum);//前後
        var direction = new Vector3(x, 0, y);
        if (x != 0 || y != 0)
        {
            //方向を向く
            transform.localRotation = Quaternion.LookRotation(direction);
        }
        //transform.Rotate(0, x * taihouspeed, 0);
        //Debug.Log("Horizontal taihou" + PlayerNum);      

    }
}
