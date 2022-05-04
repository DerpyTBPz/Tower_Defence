using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    List<GameObject> wayPoints = new List<GameObject>();
    public Enemys selfEnemy;
    public GameObject wayPointsParent;
    int wayIndex = 0;
    float hp;
    public bool isHeli;

    private void Start()
    {
        getWayPoints();
        hp = selfEnemy.Health;        
    }

    void Update()
    {
        Move();       
    }

    void getWayPoints()
    {
        for(int i = 0; i<wayPointsParent.transform.childCount; i++)
        {
            wayPoints.Add(wayPointsParent.transform.GetChild(i).gameObject);
        }
    }

    private void Move()
    {
        Vector3 dir = wayPoints[wayIndex].transform.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * selfEnemy.Speed);

        if(Vector3.Distance(transform.position, wayPoints[wayIndex].transform.position) < 0.3f)
        {
            if (wayIndex < wayPoints.Count - 1)
            {
                wayIndex++;
            }
            else
            {
                Destroy(gameObject);
                Money.Instance.currHealth--;
                Money.Instance.Health();
            }
        }
    }

    public void TakeDamage (int damage)
    {
        hp -= damage;
        CheckIsLife();
    }
    
    void CheckIsLife()
    {
        if (hp <= 0)
        {
            Money.Instance.currMoney += 10;
            Money.Instance.currScore += 100;
            Destroy(gameObject);           
        }
    }
}