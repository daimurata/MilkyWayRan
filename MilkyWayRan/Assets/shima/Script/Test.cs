using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int PlayerNum1 = 1;
    int PlayerNum2 = 2;
    int PlayerNum3 = 3;
    int PlayerNum4 = 4;

    public PlayerMove playerMove1;
    public PlayerMove playerMove2;
    public PlayerMove playerMove3;
    public PlayerMove playerMove4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var PName1 = playerMove1;
        var PHp1 = PName1.GetComponent<PlayerMove>().PlayerHP;
        var PName2 = playerMove2;
        var PHp2 = PName2.GetComponent<PlayerMove>().PlayerHP;
        var PName3 = playerMove3;
        var PHp3 = PName3.GetComponent<PlayerMove>().PlayerHP;
        var PName4 = playerMove4;
        var PHp4 = PName4.GetComponent<PlayerMove>().PlayerHP;

        Debug.Log(PName1 + "" + PHp1);
        Debug.Log(PName2 + "" + PHp2);
        Debug.Log(PName3 + "" + PHp3);
        Debug.Log(PName4 + "" + PHp4);

        

        Mathf.Max(PHp1, PHp2, PHp3, PHp4);
        Debug.Log(Mathf.Max(PHp1, PHp2, PHp3, PHp4));
    }
}
