using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 浅野ファイルFade移植
/// </summary>
public class Button : MonoBehaviour
{
    public string NextSceneName;
     
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
            SceneManager.LoadScene(NextSceneName);
            Debug.Log(NextSceneName);
        }
    }
}
