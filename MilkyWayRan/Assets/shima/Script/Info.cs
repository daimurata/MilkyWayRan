using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Info : MonoBehaviour
{
    //Playerを1~4までいれる
    public PlayerMove playerMove1;
    public PlayerMove playerMove2;
    public PlayerMove playerMove3;
    public PlayerMove playerMove4;

    void Update()
    {
        PlayerMove PName1 = playerMove1;
        int PHp1 = PName1.GetComponent<PlayerMove>().PlayerHP;
        PlayerMove PName2 = playerMove2;
        int PHp2 = PName2.GetComponent<PlayerMove>().PlayerHP;
        PlayerMove PName3 = playerMove3;
        int PHp3 = PName3.GetComponent<PlayerMove>().PlayerHP;
        PlayerMove PName4 = playerMove4;
        int PHp4 = PName4.GetComponent<PlayerMove>().PlayerHP;

        var src = new[]
        {
            new {Name = PName1,HP = PHp1 },
            new {Name = PName2,HP = PHp2 },
            new {Name = PName3,HP = PHp3 },
            new {Name = PName4,HP = PHp4 },        
        };
        //HPが降順
        var orderByDescendingList = src.OrderByDescending(x => x.HP).ToList();
        //一番HPの多いPlayerの名前とHPを表示
        Debug.Log(orderByDescendingList[0].Name + "" + orderByDescendingList[0].HP);
    }
}
