using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu mainMenu;
    void Awake()
    {
        mainMenu = this;
    }

    public void FullScreenBtn()
    {
        if (!Screen.fullScreen)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }

    public void StartBtn()
    {       
        Money.Instance.playBtn();
    }

    public void AboutBtn()
    {
        Money.Instance.ToAboutMenu();
    }

    public void LiderBoardBtn()
    {
        Money.Instance.ToLeaderBoard();
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void AM_exit()
    {
        Application.Quit();
    }

    public void ToMainMenu()
    {
        Destroy(GameObject.Find("AboutMenuPref"));
        Destroy(GameObject.Find("AboutMenuPref(Clone)"));
        Money.Instance.ToMenu();
    }
}
