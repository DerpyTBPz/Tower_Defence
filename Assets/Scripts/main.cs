using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct Towers
{
    public string Name;
    public int Price, type;
    public float range, Cooldown, CurrCooldown;
    public Sprite Spr;

    public Towers(int type, float range, float cd, string path, int Price, string Name)
    {
        this.Price = Price;
        this.Name = Name;
        this.range = range;
        Cooldown = cd;
        this.type = type;
        Spr = Resources.Load<Sprite>(path);
        CurrCooldown = 0;
    }
}

public struct TowerProjectiles
{
    public float speed;
    public int damage;
    public Sprite Spr;
    public TowerProjectiles(float speed, int dmg, string path)
    {
        this.speed = speed;
        damage = dmg;
        Spr = Resources.Load<Sprite>(path);
    }
}

public enum TowerType
{
    FIRST_TOWER,
    SECOND_TOWER
}

public struct Enemys
{
    public float Health, Speed;
    public Sprite Spr;
    public Enemys(float health, float speed, string sprPath)
    {
        Health = health;
        Speed = speed;
        Spr = Resources.Load<Sprite>(sprPath);
    }
}

public class main : MonoBehaviour
{
    public List<Towers> AllTowers = new List<Towers>();
    public List<TowerProjectiles> AllProjectiles = new List<TowerProjectiles>();
    public List<Enemys> AllEnemys = new List<Enemys>();
    
    private void Awake()
    { 
        AllTowers.Add(new Towers(0, 2.3f, .3f, "TowerSpr/greenTower", 30, "Machine Gun Tower"));
        AllTowers.Add(new Towers(1, 5, 1.5f, "TowerSpr/orangeTower", 100, "Sniper Tower"));
        
        AllProjectiles.Add(new TowerProjectiles(7, 10, "ProjectilesSpr/greenTowerProj"));
        AllProjectiles.Add(new TowerProjectiles(10, 30, "ProjectilesSpr/orangeTowerProj"));

        AllEnemys.Add(new Enemys(30, 3, "EnemySpr/heavyEnemy"));
        AllEnemys.Add(new Enemys(60, 1, "EnemySpr/simpleEnemy"));        
    }
}
