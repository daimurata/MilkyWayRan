using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //シーン遷移するために設定したボタン▲
        if (Input.GetButton("SceneButton"))
        {
            SceneManager.LoadScene("SampleScene");
            Debug.Log("メインシーンに移動");
        }
    }
}
