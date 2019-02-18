using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnTitle : MonoBehaviour
{
    public string Titru;//シーン名
   //シーン遷移
    public void OnClick()
    {
        SceneManager.LoadScene(Titru);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ReTitleSeni", 10.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ReTitleSeni()
    {
        SceneManager.LoadScene(Titru);
    }
}
