using UnityEngine;

public class local_sav : MonoBehaviour
{
    public static int win_sav, loss_sav, turn_sav = 0;
    public static string uid_sav;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public static void init_local(string uid, string win, string loss)
    {
        uid_sav = uid;
        win_sav = int.Parse(win);
        loss_sav = int.Parse(loss);
    }

    public static void setturn()
    {
        turn_sav = 1;
    }

    public static void alter_turn()
    {
        if (turn_sav == 1)
        {
            turn_sav = 0;
        }
        else if (turn_sav == 0)
        {
            turn_sav = 1;
        }
    }

    public static void turn_reset()
    {
        turn_sav = 0;
    }

    public static void Update_win()
    {
        win_sav = win_sav + 1;
    }

    public static void Update_loss()
    {
        loss_sav = loss_sav + 1;
    }
}
