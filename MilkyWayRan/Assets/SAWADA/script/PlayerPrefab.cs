using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefab : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
             obj = (GameObject)Resources.Load("player");
            Instantiate(obj, new Vector3(-13.7f, 1.0f, -4.6f), Quaternion.identity);
        }

    }
}
