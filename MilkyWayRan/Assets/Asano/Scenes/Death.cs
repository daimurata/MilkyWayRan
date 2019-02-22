using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public Image death; //画像
    public float PP=0.2f;

    // Start is called before the first frame update
    void Start()
    {
        death = GetComponent<Image>();
        death.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //減る
        if (Input.GetKeyDown(KeyCode.D))
        {
            death.fillAmount -= 1.0f / PP * 0.02f;
        }
        //増える
        if (Input.GetKeyDown(KeyCode.S))
        {
            death.fillAmount += 1.0f / PP * 0.02f;
        }
    }
}
