using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    public GameObject Obj;
    public int CreateObj = 10;
  
    void Start()
    {
        CreateObject();
    }

   
    void Update()
    {
        
    }
    public void CreateObject()
    {
        for(int X = 0; X < CreateObj; X++)
        {
            for(int Z = 0; Z < CreateObj; Z++)
            {
                Instantiate(Obj, new Vector3(+X, 0, -Z), transform.rotation);
            }
        }
    }
}
