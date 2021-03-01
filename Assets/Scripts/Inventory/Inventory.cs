using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory
{
    public event EventHandler OnItemListChanged;
    private List<ItemAnimal> itemList;
    private Action<ItemAnimal> useItemAction;

    public Inventory(Action<ItemAnimal> useItemAction) {
        this.useItemAction = useItemAction;
        itemList = new List<ItemAnimal>();
    }

    public void AddItem(ItemAnimal item) {
        if (item.IsStackable()) {
            bool itemAlreadyInInventory = false;
            foreach (ItemAnimal inventoryItem in itemList) {
                if (inventoryItem.animal == item.animal) {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory) {
                itemList.Add(item);
            }
        } else {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(ItemAnimal item) {
        if (item.IsStackable()) {
            ItemAnimal itemInInventory = null;
            foreach (ItemAnimal inventoryItem in itemList) {
                if (inventoryItem.animal == item.animal) {
                    inventoryItem.amount--;
                    itemInInventory = inventoryItem;
                    break;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0) {
                itemList.Remove(itemInInventory);
            }
        } else {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(ItemAnimal item) {
        useItemAction(item);
    }

    public List<ItemAnimal> GetItems() {
        return itemList;
    }
}
