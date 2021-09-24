using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    Towers selfTower;
    Cells selfCell;
    public Image TowerLogo;
    public Text TowerName, TowerPrice;
    public Color BaseColor, CurrColor;

    public void SetStartData(Towers Towers, Cells cell)
    {
        selfTower = Towers;
        TowerLogo.sprite = Towers.Spr;
        TowerName.text = Towers.Name;
        TowerPrice.text = Towers.Price.ToString();
        selfCell = cell;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = CurrColor;
    }   

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = BaseColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Money.Instance.currMoney >= selfTower.Price)
        {
            selfCell.BuildTower(selfTower);
            Money.Instance.currMoney -= selfTower.Price;
        }
    }
}
