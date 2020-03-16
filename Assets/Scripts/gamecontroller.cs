using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class gamecontroller : MonoBehaviourPunCallbacks
{
    public GameObject gameover_screen, play_screen;
    public Text myuid, oppuid;
    public TextMeshProUGUI winORloss;
    private string uid1;
    private static int am_kicked;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Start()
    {
        uid1 = local_sav.uid_sav;
        myuid.GetComponent<Text>().text = uid1;    
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("SetOppUid", RpcTarget.Others, uid1);
        am_kicked = 0;
    }
   
    [PunRPC]
    public void SetOppUid(string uid2)
    {
        oppuid.GetComponent<Text>().text = uid2;       
    }

    public void selectedNUM(int val)
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("check", RpcTarget.Others, val);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        victory(); 
    }

    public void victory()
    {
        am_kicked = 1;
        play_screen.SetActive(false);
        gameover_screen.SetActive(true);
        update_winloss("win", local_sav.uid_sav);
        winORloss.GetComponent<TextMeshProUGUI>().text = "Victory";
        local_sav.Update_win();
        PhotonNetwork.LeaveRoom();
    }

    [PunRPC]
    private void defeated()
    {
        am_kicked = 1;
        play_screen.SetActive(false);
        gameover_screen.SetActive(true);
        update_winloss("loss", local_sav.uid_sav);
        winORloss.GetComponent<TextMeshProUGUI>().text = "Defeated";
        local_sav.Update_loss();
        PhotonNetwork.LeaveRoom(); 
    }

    void update_winloss(string win_loss, string uid)
    {
        WWWForm form = new WWWForm();
        form.AddField("win_loss", win_loss);
        form.AddField("uid", uid);
        UnityWebRequest link = UnityWebRequest.Post("https://bingox.herokuapp.com/winloss.php", form);
        link.SendWebRequest();
    }

    public void declare_victory()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("defeated", RpcTarget.Others);
        victory();
    }

    void Update()
    {
        if (PhotonNetwork.InRoom == false && am_kicked == 0)
        {
            am_kicked = 1;
            defeated();
        }
    }
}

