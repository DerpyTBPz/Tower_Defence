using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    main mainScr;

    Enemys selfEnemy;

    public float timeToSpawn = 10;
    public int spawnCount = 0;
    public GameObject enemyPref, wayPointParent;

    void Start()
    {
        mainScr = FindObjectOfType<main>();
    }

    IEnumerator SpawnEnemy(int enemyCount)
    {
        spawnCount++;
        for (int i = 0; i < enemyCount; i++)
        {
            int tmpEnemyCount = Random.Range(0, mainScr.AllEnemys.Count);
            GameObject tmpEnemy = Instantiate(enemyPref);
            tmpEnemy.transform.SetParent(gameObject.transform, false);
            tmpEnemy.GetComponent<Enemy>().selfEnemy = mainScr.AllEnemys[tmpEnemyCount];            
            tmpEnemy.GetComponent<SpriteRenderer>().sprite = mainScr.AllEnemys[tmpEnemyCount].Spr;
            tmpEnemy.GetComponent<Enemy>().wayPointsParent = wayPointParent;
            tmpEnemy.GetComponent<Enemy>().isHeli = mainScr.AllEnemys[tmpEnemyCount].isHeli;
            yield return new WaitForSeconds(0.4f);
        }
    }    

    void Update()
    {
        if (Money.Instance.canSpawn == true)
        {
            if (timeToSpawn <= 0)
            {
                StartCoroutine(SpawnEnemy(spawnCount + 1));
                timeToSpawn = 10;
            }
            timeToSpawn -= Time.deltaTime;
            GameObject.Find("SpawnCountTxt").GetComponent<Text>().text = Mathf.Round(timeToSpawn).ToString();
        }
    }
}
