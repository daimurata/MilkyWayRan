using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public string NextSceneName;//シーン名

    //public GameObject Panel;
    //public Fade script;
    void Start()
    {
        //Panel = GameObject.Find("Panel");
        //script = Panel.GetComponent<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //シーン移動処理
            SceneManager.LoadScene(NextSceneName);
        }
    }
}
