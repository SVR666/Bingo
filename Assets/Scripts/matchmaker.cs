using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class matchmaker : MonoBehaviour
{
    public GameObject Go_Bingo;
    public Text[] bingo;
    private static int bingo_count;   
    private static int[] row, col, rowF, colF;

    private void Start()
    {
        row = new int[5] { 0, 0, 0, 0, 0 };
        col = new int[5] { 0, 0, 0, 0, 0 };
        rowF = new int[5] { 0, 0, 0, 0, 0 };
        colF = new int[5] { 0, 0, 0, 0, 0 };
        bingo_count = 0;
    }

    public static void checkSelection(int cn, string pn)
    {
        int colval = makeITcol(cn);
        //set row 
        if (pn == "row1")
        {
            row[0]++;
        }
        else if (pn == "row2")
        {
            row[1]++;
        }
        else if (pn == "row3")
        {
            row[2]++;
        }
        else if (pn == "row4")
        {
            row[3]++;
        }
        else if (pn == "row5")
        {
            row[4]++;
        }

        //set col
        if (colval == 1)
        {
            col[0]++;
        }
        else if (colval == 2)
        {
            col[1]++;
        }
        else if (colval == 3)
        {
            col[2]++;
        }
        else if (colval == 4)
        {
            col[3]++;
        }
        else if (colval == 5)
        {
            col[4]++;
        }
    }

    static int makeITcol(int va)
    {
        int f = (va % 5);
        if (f == 0)
        {
            f = 5;
        }
        return f;
    }

    void bin_go()
    {
        if (bingo_count < 5)
        {
            bingo[bingo_count].color = Color.green;
            bingo_count++;
        }
    }

    private void Update()
    {
        //row check
        if (row[0] == 5 && rowF[0] == 0)
        {
            rowF[0] = 1;
            bin_go();
        }
        else if (row[1] == 5 && rowF[1] == 0)
        {
            rowF[1] = 1;
            bin_go();
        }
        else if (row[2] == 5 && rowF[2] == 0)
        {
            rowF[2] = 1;
            bin_go();
        }
        else if (row[3] == 5 && rowF[3] == 0)
        {
            rowF[3] = 1;
            bin_go();
        }
        else if (row[4] == 5 && rowF[4] == 0)
        {
            rowF[4] = 1;
            bin_go();
        }

        //col check
        if (col[0] == 5 && colF[0] == 0)
        {
            colF[0] = 1;
            bin_go();
        }
        else if (col[1] == 5 && colF[1] == 0)
        {
            colF[1] = 1;
            bin_go();
        }
        else if (col[2] == 5 && colF[2] == 0)
        {
            colF[2] = 1;
            bin_go();
        }
        else if (col[3] == 5 && colF[3] == 0)
        {
            colF[3] = 1;
            bin_go();
        }
        else if (col[4] == 5 && colF[4] == 0)
        {
            colF[4] = 1;
            bin_go();
        }

        //go bingo
        if (bingo_count == 5)
        {
            Go_Bingo.GetComponent<Button>().interactable = true;
            Go_Bingo.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
    }
}
