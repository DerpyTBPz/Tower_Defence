using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public static Money Instance;
    public Text MoneyTxt, ScoreTxt;
    public int currMoney, currHealth = 3, currScore = 0, endScore = 0;
    public bool canSpawn = false, EscMenuOn = false;
    public GameObject LosePanelPref, mainMenuPref, aboutMenuPref, leaderBoardPref, EscMenuPref;

    void Awake()
    {
        Instance = this;
    }
 
    void Update()
    {
        MoneyTxt.text = "Money: " + currMoney.ToString();
        ScoreTxt.text = "Score: " + currScore.ToString();
        GameObject.Find("currHealth").GetComponent<Text>().text = currHealth.ToString();
        if (Input.GetKeyDown(KeyCode.Escape) && canSpawn == true && EscMenuOn == false)
        {
            EscMenuOn = true;
            GameObject EscMenuObj = Instantiate(EscMenuPref);
            EscMenuObj.transform.SetParent(GameObject.Find("MenuCanvas").transform, false);           
        }        
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

    public void playBtn()
    {
        foreach (Tower ts in FindObjectsOfType<Tower>())
            Destroy(ts.gameObject);
        foreach (Enemy es in FindObjectsOfType<Enemy>())
            Destroy(es.gameObject);
        currMoney = 60;
        FindObjectOfType<Spawner>().timeToSpawn = 10;
        Destroy(GameObject.Find("MenuPanelPref"));
        Destroy(GameObject.Find("MenuPanelPref(Clone)"));
        FindObjectOfType<Spawner>().spawnCount = 0;
        currScore = 0;
        endScore = 0;
        currHealth = 3;
        canSpawn = true;
    }      

    public void Health()
    {
        if (currHealth == 0)
        {
            ToLoseMenu();
        }
    }

    public void ToLoseMenu()
    {
        canSpawn = false;
        GameObject LoseMenuObj = Instantiate(LosePanelPref);
        LoseMenuObj.transform.SetParent(GameObject.Find("MenuCanvas").transform, false);
        endScore = currScore;
        GameObject.Find("LoseScoreTxt").GetComponent<Text>().text = "Кількість очок:\n" + endScore.ToString();
    }

    public void ToMenu()
    {
        GameObject mainMenuObj = Instantiate(mainMenuPref);
        mainMenuObj.transform.SetParent(GameObject.Find("MenuCanvas").transform, false);       
    }

    public void ToAboutMenu()
    {
        Destroy(GameObject.Find("MenuPanelPref"));
        Destroy(GameObject.Find("MenuPanelPref(Clone)"));
        GameObject aboutMenuObj = Instantiate(aboutMenuPref);
        aboutMenuObj.transform.SetParent(GameObject.Find("MenuCanvas").transform, false);
    }

    public void ToLeaderBoard()
    {
        Destroy(GameObject.Find("MenuPanelPref"));
        Destroy(GameObject.Find("MenuPanelPref(Clone)"));      
        GameObject leaderBoardObj = Instantiate(leaderBoardPref);
        leaderBoardObj.transform.SetParent(GameObject.Find("MenuCanvas").transform, false);
        GetComponent<DataBase>().ReadFromDB();
    }
}
