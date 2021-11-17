﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
    Transform target;
    public TowerProjectiles selfProjectile;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = selfProjectile.Spr;
    }

    void Update()
    {
        Move();
    }

    public void SetTarget(Transform enemy)
    {
        target = enemy;
    }   

    private void Move()
    {       
        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) < .1f)
            {
                target.GetComponent<Enemy>().TakeDamage(selfProjectile.damage);
                Destroy(gameObject);
            }
            else
            {
                Vector2 dir = target.position - transform.position;
                transform.Translate(dir.normalized * Time.deltaTime * selfProjectile.speed);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}