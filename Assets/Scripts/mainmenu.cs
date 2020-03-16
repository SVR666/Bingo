using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class mainmenu : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI username, winloss;
    public static string uname;

    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void Start() 
    {
        uname = local_sav.uid_sav;
        username.GetComponent<TextMeshProUGUI>().text = uname;
        winloss.GetComponent<TextMeshProUGUI>().text += local_sav.win_sav+"/"+ local_sav.loss_sav;
        if (local_sav.turn_sav == 1)
        {
            local_sav.turn_reset();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master server -- mm");
    }

    public void singleplayer()
    {
        SceneManager.LoadScene("lobby");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void Updatewinloss()
    {
        
    }

    public void logout()
    {
        string save_path = Application.persistentDataPath + "/login_cred.bin";
        if (File.Exists(save_path))
        {
            File.Delete(save_path);
            SceneManager.LoadScene("login");
        }
    }

    private void Update()
    {
        if (!(PhotonNetwork.IsConnected))
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}
