using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class click : MonoBehaviour
{
    private int Cname, num;
    private string Pname;
    private gamecontroller selector;
    private void Start()
    {
        selector = FindObjectOfType<gamecontroller>();
    }
    public void onclick(Button btn)
    {
        local_sav.alter_turn();
        //rpc
        Cname = int.Parse(btn.name);
        Pname = btn.transform.parent.name;
        num = int.Parse(btn.GetComponentInChildren<Text>().text);
        selector.selectedNUM(num);
        matchmaker.checkSelection(Cname, Pname);
    }
}
