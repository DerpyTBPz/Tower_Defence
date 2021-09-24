using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public InputField NameTxt;
    string inpTxt;
    int k;

    public void DTExitBtn()
    {
        Application.Quit();
        Debug.Log("exit");
    }


    public void MMExitBtn()
    {
        Destroy(GameObject.Find("LosePanelPref"));
        Destroy(GameObject.Find("LosePanelPref(Clone)"));
        Money.Instance.ToMenu();
        Debug.Log("in Main Menu");
    }
    public void ReadDB()
    {
        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/db.bytes"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT player_id, Nickname , Score " + "FROM LeaderBoard";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            k++;
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public void SaveBtn()
    {
        ReadDB();
        k++;
        inpTxt = NameTxt.text;
        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/db.bytes";
        IDbConnection dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO LeaderBoard (player_id, Nickname, Score) VALUES ("+k+ ", '"+inpTxt+"', "+Money.Instance.endScore+")";
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        Destroy(GameObject.Find("LosePanelPref"));
        Destroy(GameObject.Find("LosePanelPref(Clone)"));
        Money.Instance.ToLeaderBoard();       
    }
}

