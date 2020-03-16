using UnityEngine;
using UnityEngine.UI;

public class mul_mang : MonoBehaviour
{
    public GameObject disabler, myturn_ind, oppturn_ind;

    private void Update()
    {
        if(local_sav.turn_sav == 1)
        {
            disabler.SetActive(false);
            myturn_ind.GetComponent<Image>().color = Color.green;
            oppturn_ind.GetComponent<Image>().color = Color.red;
        }
        else
        {
            disabler.SetActive(true);
            myturn_ind.GetComponent<Image>().color = Color.red;
            oppturn_ind.GetComponent<Image>().color = Color.green;
        }
    }
}
