﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Gage : MonoBehaviour
{
    //m
    public Image Gage_0;
    public Image Gage_1;
    public Image Gage_2;
    public Image Gage_3;
    public Image Gage_4;
    public Image Gage_5;
    public int Bool = 5;
    void Start()
    {
        Bool = 5;
    }
    void Update()
    {
        if(Bool == 5)
        {
            Gage_5.gameObject.SetActive(true);
            Gage_4.gameObject.SetActive(true);
            Gage_3.gameObject.SetActive(true);
            Gage_2.gameObject.SetActive(true);
            Gage_1.gameObject.SetActive(true);
        }
        if (Bool == 4)
        {
            Gage_5.gameObject.SetActive(false);
            Gage_4.gameObject.SetActive(true);
            Gage_3.gameObject.SetActive(true);
            Gage_2.gameObject.SetActive(true);
            Gage_1.gameObject.SetActive(true);
        }

        if (Bool == 3)
        {
            Gage_5.gameObject.SetActive(false);
            Gage_4.gameObject.SetActive(false);
            Gage_3.gameObject.SetActive(true);
            Gage_2.gameObject.SetActive(true);
            Gage_1.gameObject.SetActive(true);
        }
        if (Bool == 2)
        {
            Gage_5.gameObject.SetActive(false);
            Gage_4.gameObject.SetActive(false);
            Gage_3.gameObject.SetActive(false);
            Gage_2.gameObject.SetActive(true);
            Gage_1.gameObject.SetActive(true);
        }
        if (Bool == 1)
        {
            Gage_5.gameObject.SetActive(false);
            Gage_4.gameObject.SetActive(false);
            Gage_3.gameObject.SetActive(false);
            Gage_2.gameObject.SetActive(false);
            Gage_1.gameObject.SetActive(true);
        }
        if (Bool == 0)
        {
            Gage_5.gameObject.SetActive(false);
            Gage_4.gameObject.SetActive(false);
            Gage_3.gameObject.SetActive(false);
            Gage_2.gameObject.SetActive(false);
            Gage_1.gameObject.SetActive(false);
        }

        //増える
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Bool += 1;
            if (Bool >= 5)
            {
                Bool = 5;
            }
        }
        
        //減る
        if (Input.GetKeyDown(KeyCode.X))
        {
            Bool -= 1;
            if (Bool <= 0)
            {
                Bool = 0;
            }
        }
    }
}