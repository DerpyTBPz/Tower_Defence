using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject Projectile;
    Towers selfTower;
    public TowerType selfType;
    main mainScr;

    private void Start()
    {
        mainScr = FindObjectOfType<main>();
        selfTower = mainScr.AllTowers[(int)selfType];
        GetComponent<SpriteRenderer>().sprite = selfTower.Spr;
        InvokeRepeating("SearchTarget", 0, .1f);
    }

    private void Update()
    {

        if (selfTower.CurrCooldown > 0)
        {
            selfTower.CurrCooldown -= Time.deltaTime;
        }
    }

    bool CanShoot()
    {
        if(selfTower.CurrCooldown <= 0)
        {
            return true;
        }
        return false;
    }

    void SearchTarget()
    {
        if (CanShoot())
        {
            Transform nearestEnemy = null;
            float nearestEnemyDistance = Mathf.Infinity;

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                float currDistance = Vector2.Distance(transform.position, enemy.transform.position);
                if (currDistance < nearestEnemyDistance && currDistance <= selfTower.range)
                {
                    nearestEnemy = enemy.transform;
                    nearestEnemyDistance = currDistance;
                }
            }
            if (nearestEnemy != null)
            {
                if ((nearestEnemy.GetComponent<Enemy>().isHeli == true) && (selfTower.isAntiAir == true))
                {
                    Shoot(nearestEnemy);
                }
                if ((nearestEnemy.GetComponent<Enemy>().isHeli == false) && (selfTower.isAntiAir == false))
                {
                    Shoot(nearestEnemy);
                } 
            }
        }
    }

    void Shoot(Transform enemy)
    {
        selfTower.CurrCooldown = selfTower.Cooldown;

        GameObject proj = Instantiate(Projectile);
        proj.GetComponent<TowerProjectile>().selfProjectile = mainScr.AllProjectiles[(int)selfType];
        proj.transform.position = transform.position;
        proj.GetComponent<TowerProjectile>().SetTarget(enemy);       
    }
}