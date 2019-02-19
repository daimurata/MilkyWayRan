using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    public string Main;//シーン名
    //ボタンをクリックしたら
    public void OnClick()
    {
        //シーン遷移
        SceneManager.LoadScene(Main);
    }
    // Start is called before the first frame update
  
}
