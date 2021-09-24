using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class DataBase : MonoBehaviour
{   
    string[,] scoreboard;  
    public int id, score;
    public string nick;
    public int k = 0;    

    public void ReadFromDB()
    {
        int k = 0;
        string conn = "URI=file:" + Application.dataPath + "/StreamingAssets/db.bytes"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT player_id, Nickname , Score " + "FROM LeaderBoard ORDER BY Score DESC";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            k++;
            id = reader.GetInt32(0);
            nick = reader.GetString(1);
            score = reader.GetInt32(2);
            GameObject.Find("ScrNumber").GetComponent<Text>().text += "\n" + k.ToString();
            GameObject.Find("ScrName").GetComponent<Text>().text += "\n" + nick.ToString();
            GameObject.Find("ScrScore").GetComponent<Text>().text += "\n" + score.ToString();
            Debug.Log("player_id=" + k + " Nickname=" + nick + " Score=" + score);            
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public void BackToMenu()
    {
        Destroy(GameObject.Find("ScoreBoardPref"));
        Destroy(GameObject.Find("ScoreBoardPref(Clone)"));
        Money.Instance.ToMenu();
    }    
}