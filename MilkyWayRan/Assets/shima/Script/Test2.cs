using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : MonoBehaviour
{
    //名前
    public PlayerMove Name;
    //HP残量
    public int Age;

    public Info(PlayerMove Name,int Age)
    {
        this.Name = Name;
        this.Age = Age;
    }
    // Start is called before the first frame update
}
public class Main
{
    public PlayerMove playerMove1;
    public PlayerMove playerMove2;
    public PlayerMove playerMove3;
    public PlayerMove playerMove4;
   
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

        Info[] src = new Info[]
        {
            new Info(PName1,PHp1),
            new Info(PName2,PHp2),
            new Info(PName3,PHp3),
            new Info(PName4,PHp4)
        };
        
        var list = new List<Info>();
        //listに要素を追加
        list.AddRange(src);
        //listをソート
        list.Sort();
        foreach (Info i in list)
        {
            Debug.Log(i.Name, i.Age);
        }
    }
    static int Compare(Info a,Info b)
    {
        return a.Age - b.Age;
    }
}
