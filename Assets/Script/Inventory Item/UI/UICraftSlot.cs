using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICraftSlot : UIItemSlot
{
    protected override void Start()
    {
        base.Start();
    }
    public void SetupCraftSlot(ItemDataEquipment _data)
    {
        if (_data == null) return;
        item.data = _data;
        itemImage.sprite = _data.icon;
        itemText.text = _data.itemName;

        if (itemText.text.Length > 10)
        {
            itemText.fontSize = itemText.fontSize * .7f;
        }else
        {
            itemText.fontSize = 24;
        }
        
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
       ui.craftWindow.SetupCraftWindow(item.data as ItemDataEquipment);
    }

}
