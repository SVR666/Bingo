using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class numgen : MonoBehaviour
{
    private int[] numlist;
    private int tempGO, length = 25;
    public GameObject[] element;
    void Start()
    {
        numlist = new int[25]; 
        int n = 1;
        for (int i = 0; i < length; i++)
        {
            numlist[i] = n;
            n++;
        }

        Shuffle();

        for (int i = 0; i < length; i++)
        {
            element[i].GetComponentInChildren<Text>().text = numlist[i].ToString();
        }        
    }

    public void Shuffle()
    {
        for (int i = 0; i < length; i++)
        {
            int rnd = Random.Range(0, length);
            tempGO = numlist[rnd];
            numlist[rnd] = numlist[i];
            numlist[i] = tempGO;
        }
    }

    [PunRPC]
    public void check(int checker)
    {
        local_sav.alter_turn();
        for (int i = 0; i < length; i++)
        {
            if (int.Parse(element[i].GetComponentInChildren<Text>().text) == checker)
            {
                buttonpress(i);
                int Cname = int.Parse(element[i].GetComponent<Button>().name);
                string Pname = element[i].GetComponent<Button>().transform.parent.name;
                matchmaker.checkSelection(Cname, Pname);
                break;
            }
        }
    }

    void buttonpress(int i)
    {
        Button press = element[i].GetComponent<Button>();
        press.interactable = false;
        ColorBlock color_set = press.colors;
        color_set.disabledColor = Color.cyan;
        press.colors = color_set;
    }

}
