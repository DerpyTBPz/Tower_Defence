using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cells : MonoBehaviour
{
    public bool isGround, hasTower = false, isRock;
    public Color baseColor, currColor;
    public GameObject ShopPref, TowerPref;

    private void OnMouseEnter()
    {
        if (!isGround && FindObjectsOfType<Shop>().Length == 0 && !isRock)
        {
            GetComponent<Image>().color = currColor;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<Image>().color = baseColor;
    }

    private void OnMouseDown()
    {
        if (!isGround && FindObjectsOfType<Shop>().Length == 0 && !isRock && Money.Instance.canSpawn == true)
        {
            if (!hasTower)
            {
                GameObject shopObj = Instantiate(ShopPref);
                shopObj.transform.SetParent(GameObject.Find("GameCanvas").transform, false);
                shopObj.GetComponent<Shop>().selfCell = this;
            }
        }
    } 

    public void BuildTower(Towers tower)
    {
        GameObject tmpTower = Instantiate(TowerPref);
        tmpTower.transform.SetParent(transform, true);
        tmpTower.transform.position = transform.position;
        tmpTower.GetComponent<Tower>().selfType = (TowerType)tower.type;
        hasTower = true;
        FindObjectOfType<Shop>().CloseShop();
    }     
}