using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour
{
    [HideInInspector]
    public object[,] lables;
    private GameObject table;
    public string playerName;
    public int playerScore;
    public GameObject[] lableFrefs;
    private GameObject panel;
    private int playerIndexInTable;


    public void OpenTable()
    {
        playerName = PlayerPrefs.GetString("name");
        playerScore = PlayerPrefs.GetInt("points");

        table = gameObject;
        lables = new object[100, 2];

        FillArray(playerName, playerScore);

        panel = GameObject.FindGameObjectWithTag("Panel");

        for (int i = 0; i < lables.GetLength(0); i++)
        {
            if (i == 0)
            {
                Instantiate(lableFrefs[1], panel.transform);
            }
            else if (i == lables.GetLength(0) - 1)
            {
                Instantiate(lableFrefs[2], panel.transform);
            }
            else
            {
                Instantiate(lableFrefs[0], panel.transform);
            }

        }

        SortTable();
        GameObject[] places = GameObject.FindGameObjectsWithTag("tablePlace");
        GameObject[] names = GameObject.FindGameObjectsWithTag("tableName");
        GameObject[] scores = GameObject.FindGameObjectsWithTag("tableScore");
        for (int i = 0; i < lables.GetLength(0); i++)
        {
            places[i].GetComponent<Text>().text = System.Convert.ToString(i + 1);
            names[i].GetComponent<Text>().text = System.Convert.ToString(lables[i, 0]);
            scores[i].GetComponent<Text>().text = System.Convert.ToString(lables[i, 1]);
        }

        for (int i = 0; i < lables.GetLength(0); i++)
        {
            GameObject temp = panel.transform.GetChild(i).gameObject;
            if (temp.transform.Find("name").GetComponent<Text>().text == playerName)
            {
                playerIndexInTable = i;
                temp.GetComponent<Image>().color = new Vector4(0, 1, 1, 1);
            }
        }       

        panel.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 160 * playerIndexInTable, 0);
    }

    public void CloseTable()
    {
        panel.transform.GetChild(playerIndexInTable).gameObject.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
    }

    private void FillArray(string nameplayer, int scoreplayer)
    {
        lables[0, 0] = "dolyran";
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
        lables[10, 1] = 4;

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

        lables[17, 0] = "bean";
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

        lables[26, 0] = "NoName";
        lables[26, 1] = 782;

        lables[27, 0] = "player_23";
        lables[27, 1] = 132;

        lables[28, 0] = "player_553";
        lables[28, 1] = 234;

        lables[29, 0] = "tasher";
        lables[29, 1] = 765;

        lables[30, 0] = "player_352";
        lables[30, 1] = 254;

        lables[31, 0] = "send";
        lables[31, 1] = 845;

        lables[32, 0] = "ithan";
        lables[32, 1] = 123;

        lables[33, 0] = "isaac";
        lables[33, 1] = 189;

        lables[34, 0] = "bread";
        lables[34, 1] = 956;

        lables[35, 0] = "john";
        lables[35, 1] = 383;

        lables[36, 0] = "alice";
        lables[36, 1] = 987;

        lables[37, 0] = "aergaio";
        lables[37, 1] = 423;

        lables[38, 0] = "rgsdfg";
        lables[38, 1] = 498;

        lables[39, 0] = "player_241";
        lables[39, 1] = 176;

        lables[40, 0] = "gabe";
        lables[40, 1] = 746;

        lables[41, 0] = "adolf";
        lables[41, 1] = 736;

        lables[42, 0] = "nick";
        lables[42, 1] = 846;

        lables[43, 0] = "nyan";
        lables[43, 1] = 1865;

        lables[44, 0] = "adolf";
        lables[44, 1] = 654;

        lables[45, 0] = "pick";
        lables[45, 1] = 1954;

        lables[46, 0] = "lara";
        lables[46, 1] = 1398;

        lables[47, 0] = "oiawf";
        lables[47, 1] = 1534;

        lables[48, 0] = "josaph";
        lables[48, 1] = 1843;

        lables[49, 0] = "ethan";
        lables[49, 1] = 1054;

        lables[50, 0] = "gav";
        lables[50, 1] = 1924;

        lables[51, 0] = "lara";
        lables[51, 1] = 1004;

        lables[52, 0] = "NoName";
        lables[52, 1] = 1238;

        lables[53, 0] = "player_23";
        lables[53, 1] = 1203;

        lables[54, 0] = "player_553";
        lables[54, 1] = 1324;

        lables[55, 0] = "tasher";
        lables[55, 1] = 654;

        lables[56, 0] = "player_352";
        lables[56, 1] = 865;

        lables[57, 0] = "send";
        lables[57, 1] = 754;

        lables[58, 0] = "ithan";
        lables[58, 1] = 1907;

        lables[59, 0] = "isaac";
        lables[59, 1] = 1854;

        lables[60, 0] = "bread";
        lables[60, 1] = 478;

        lables[61, 0] = "john";
        lables[61, 1] = 673;

        lables[62, 0] = "alice";
        lables[62, 1] = 321;

        lables[63, 0] = "aergaio";
        lables[63, 1] = 1983;

        lables[64, 0] = "rgsdfg";
        lables[64, 1] = 123;

        lables[65, 0] = "player_241";
        lables[65, 1] = 654;

        lables[66, 0] = "gabe";
        lables[66, 1] = 598;

        lables[67, 0] = "adolf";
        lables[67, 1] = 786;

        lables[68, 0] = "nick";
        lables[68, 1] = 634;

        lables[69, 0] = "nyan";
        lables[69, 1] = 165;

        lables[70, 0] = "adolf";
        lables[70, 1] = 757;

        lables[71, 0] = "pick";
        lables[71, 1] = 432;

        lables[72, 0] = "lara";
        lables[72, 1] = 1202;

        lables[73, 0] = "oiawf";
        lables[73, 1] = 654;

        lables[74, 0] = "josaph";
        lables[74, 1] = Random.Range(10, 200);

        lables[75, 0] = "ethan";
        lables[75, 1] = Random.Range(596, 1002);

        lables[76, 0] = "gav";
        lables[76, 1] = Random.Range(432, 645);

        lables[77, 0] = "lara";
        lables[77, 1] = Random.Range(5, 87);

        lables[78, 0] = "NoName";
        lables[78, 1] = Random.Range(1233, 1546);

        lables[79, 0] = "player_23";
        lables[79, 1] = Random.Range(54, 143);

        lables[80, 0] = "player_553";
        lables[80, 1] = Random.Range(1324, 1654);

        lables[81, 0] = "tasher";
        lables[81, 1] = Random.Range(783, 1332);

        lables[82, 0] = "player_352";
        lables[82, 1] = Random.Range(69, 169);

        lables[83, 0] = "send";
        lables[83, 1] = Random.Range(666, 777);

        lables[84, 0] = "ithan";
        lables[84, 1] = Random.Range(1532, 2000);

        lables[85, 0] = "isaac";
        lables[85, 1] = Random.Range(56, 443);

        lables[86, 0] = "bread";
        lables[86, 1] = Random.Range(425, 987);

        lables[87, 0] = "john";
        lables[87, 1] = Random.Range(543, 876);

        lables[88, 0] = "alice";
        lables[88, 1] = Random.Range(122, 321);

        lables[89, 0] = "aergaio";
        lables[89, 1] = Random.Range(1332, 1698);

        lables[90, 0] = "rgsdfg";
        lables[90, 1] = Random.Range(432, 1643);

        lables[91, 0] = "player_241";
        lables[91, 1] = Random.Range(43, 243);

        lables[92, 0] = "gabe";
        lables[92, 1] = Random.Range(54, 865);

        lables[93, 0] = "adolf";
        lables[93, 1] = Random.Range(532, 1673);

        lables[94, 0] = "nick";
        lables[94, 1] = Random.Range(1, 10);

        lables[95, 0] = "nyan";
        lables[95, 1] = Random.Range(755, 1678);

        lables[96, 0] = "adolf";
        lables[96, 1] = Random.Range(1, 425);

        lables[97, 0] = "pick";
        lables[97, 1] = Random.Range(1, 124);

        lables[98, 0] = "lara";
        lables[98, 1] = Random.Range(1, 32);

        lables[99, 0] = nameplayer;
        lables[99, 1] = scoreplayer;
    }

    private void SortTable()
    {
        object[,] tmp = new object[1,2];
        for (int i = 0; i < lables.GetLength(0); i++)
        {
            for (int a = 0; a < lables.GetLength(0); a++)
            {
                if (System.Convert.ToInt32(lables[a,1]) < System.Convert.ToInt32(lables[i, 1]))
                {
                    tmp[0, 0] = lables[i, 0];
                    tmp[0, 1] = lables[i, 1];

                    lables[i, 0] = lables[a, 0];
                    lables[i, 1] = lables[a, 1];

                    lables[a, 0] = tmp[0, 0];
                    lables[a, 1] = tmp[0, 1];
                }
            }
        }
    }
}
