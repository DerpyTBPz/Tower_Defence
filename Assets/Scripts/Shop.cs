using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject ItemPref;
    public Transform ItemGrid;
    main  mainScr;
    public Cells selfCell;

    void Start()
    {
        mainScr = FindObjectOfType<main>();

        foreach (Towers tower in mainScr.AllTowers)
        {
            GameObject tmpItem = Instantiate(ItemPref);
            tmpItem.transform.SetParent(ItemGrid, false);
            tmpItem.GetComponent<ShopItem>().SetStartData(tower, selfCell);
        }        
    }

    public void CloseShop()
    {
        Destroy(gameObject);     
    }
}

