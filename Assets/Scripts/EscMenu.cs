using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public void NoBtn()
    {
        Destroy(GameObject.Find("EscMenuPref"));
        Destroy(GameObject.Find("EscMenuPref(Clone)"));
        Money.Instance.EscMenuOn = false;
    }

    public void YesBtn()
    {
        Destroy(GameObject.Find("EscMenuPref"));
        Destroy(GameObject.Find("EscMenuPref(Clone)"));
        Money.Instance.EscMenuOn = false;
        Money.Instance.ToLoseMenu();
    }
}
