using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour
{
    [HideInInspector]
    public object[,] lables;
    private GameObject table;

    private void Start()
    {        
        table = gameObject;
        lables = new object[99, 2];

        FillArray();

        GameObject[] places = GameObject.FindGameObjectsWithTag("tablePlace");
        GameObject[] names = GameObject.FindGameObjectsWithTag("tableName");
        GameObject[] scores = GameObject.FindGameObjectsWithTag("tableScore");        
        for (int i = 0; i < lables.GetLength(0); i++)
        {
            places[i].GetComponent<Text>().text = System.Convert.ToString(i + 1);
            names[i].GetComponent<Text>().text = System.Convert.ToString(lables[i, 0]);
            scores[i].GetComponent<Text>().text = System.Convert.ToString(lables[i, 1]);
        }        
    }

    private void FillArray()
    {
        lables[0, 0] = "NoName";
        lables[0, 1] = 999;

        lables[1, 0] = "player_23";
        lables[1, 1] = 789;

        lables[2, 0] = "player_553";
        lables[2, 1] = 56;

        lables[3, 0] = "tasher";
        lables[3, 1] = 2345;

        lables[4, 0] = "player_352";
        lables[4, 1] = 670;

        lables[5, 0] = "send";
        lables[5, 1] = 435;

        lables[6, 0] = "ithan";
        lables[6, 1] = 353;

        lables[7, 0] = "isaac";
        lables[7, 1] = 943;

        lables[8, 0] = "bread";
        lables[8, 1] = 102;

        lables[9, 0] = "john";
        lables[9, 1] = 352;

        lables[10, 0] = "alice";
        lables[10, 1] = 0;

        lables[11, 0] = "aergaio";
        lables[11, 1] = 3;

        lables[12, 0] = "rgsdfg";
        lables[12, 1] = 2;

        lables[13, 0] = "player_241";
        lables[13, 1] = 12;

        lables[14, 0] = "gabe";
        lables[14, 1] = 53;

        lables[15, 0] = "adolf";
        lables[15, 1] = 427;

        lables[16, 0] = "nick";
        lables[16, 1] = 903;

        lables[17, 0] = "nyan";
        lables[17, 1] = 2034;

        lables[18, 0] = "adolf";
        lables[18, 1] = 23;

        lables[19, 0] = "pick";
        lables[19, 1] = 575;

        lables[20, 0] = "lara";
        lables[20, 1] = 756;

        lables[21, 0] = "oiawf";
        lables[21, 1] = 4;

        lables[22, 0] = "josaph";
        lables[22, 1] = 490;

        lables[23, 0] = "ethan";
        lables[23, 1] = 350;

        lables[24, 0] = "gav";
        lables[24, 1] = 524;

        lables[25, 0] = "lara";
        lables[25, 1] = 756;
    }
}
