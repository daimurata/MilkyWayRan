using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefab : MonoBehaviour
{ 
    public int PlayerNum = 1;
    public float PlayerposX = 1.0f;
    public float PlayerposY = 1.0f;
    public float PlayerposZ = 1.0f;

    bool One;

    //public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        One = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (One)
        {
            if (Input.GetButtonDown("PlayerLoad" + PlayerNum))
            {
                GameObject obj = (GameObject)Resources.Load("SD Player P" + PlayerNum);
                Instantiate(obj, new Vector3(PlayerposX, PlayerposY, PlayerposZ), Quaternion.identity);
                One = false;
            }
        }
        else if (One == false)
        {
            if (Input.GetButtonDown("PlayerLoad" + PlayerNum))
            {
                Destroy(GameObject.Find("SD Player P" + PlayerNum+"(Clone)"));
                Debug.Log("SD Player P" + PlayerNum+"(Clone)をですとろい");
                One = true;
            }   
        }
    }
}
