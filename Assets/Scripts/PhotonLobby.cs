using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    public TextMeshProUGUI roomid_input, details;
    public GameObject RandomButton, CustomButton, letsgo_btn;
    private string roomid;

    void Awake()
    {
        lobby = this;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Start()
    {
        details.GetComponent<TextMeshProUGUI>().text = "Please wait or try again";
        if (PhotonNetwork.IsConnectedAndReady)
        {
            RandomButton.GetComponent<Button>().interactable = true;
            RandomButton.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            CustomButton.GetComponent<Button>().interactable = true;
            CustomButton.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master server -- pl");
        activate();
    }

    public void letsgo()
    {
        roomid = roomid_input.GetComponent<TextMeshProUGUI>().text.ToLower();
        RoomOptions roomdetail = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };        
        PhotonNetwork.JoinOrCreateRoom(roomid, roomdetail, TypedLobby.Default);
    }

    public void GotoRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();   
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.PlayerList.Length == 1)
        {
            details.GetComponent<TextMeshProUGUI>().text = "waiting for opponent";
        }
        else if (PhotonNetwork.PlayerList.Length == 2)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();
    }

    void CreateRoom()
    {
        details.GetComponent<TextMeshProUGUI>().text = "Trying to create new room";
        int randomRoomName = Random.Range(0, 9);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        PhotonNetwork.CreateRoom("BingoX" + randomRoomName, roomOps);
    }

    public override void OnCreatedRoom()
    {
        local_sav.setturn();
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        details.GetComponent<TextMeshProUGUI>().text = "Join failed";
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        details.GetComponent<TextMeshProUGUI>().text = "room creation failed";
    }

    public void cancelcreation()
    {
        details.GetComponent<TextMeshProUGUI>().text = "Please wait or try again";
        local_sav.turn_reset();
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }   
    }

    void activate()
    {
        RandomButton.GetComponent<Button>().interactable = true;
        RandomButton.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        CustomButton.GetComponent<Button>().interactable = true;
        CustomButton.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
    }

    void Update()
    {
        if (PhotonNetwork.IsConnectedAndReady == false)
        {
            RandomButton.GetComponent<Button>().interactable = false;
            RandomButton.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            CustomButton.GetComponent<Button>().interactable = false;
            CustomButton.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        }

        if (PhotonNetwork.IsConnected == false)
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        if (PhotonNetwork.PlayerList.Length == 2)
        {
            SceneManager.LoadScene("Game");
        }

        if (roomid_input.GetComponent<TextMeshProUGUI>().text.Length > 3)
        {
            letsgo_btn.GetComponent<Button>().interactable = true;
            letsgo_btn.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        }
        else
        {
            letsgo_btn.GetComponent<Button>().interactable = false;
            letsgo_btn.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        }
    }
}