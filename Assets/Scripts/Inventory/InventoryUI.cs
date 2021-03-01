using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    private Transform slotsContainer;
    [SerializeField] private Transform slot;
    [SerializeField] private GameObject mousePF;
    [SerializeField] private GameObject birdPF;
    [SerializeField] private GameObject hedgehogPF;
    [SerializeField] private GameObject ladybugPF;
    [SerializeField] private GameObject frogPF;
    [SerializeField] private GameObject lizardPF;

    private Player player;

    private Canvas canvas;
    public enum Category
    {
        Light,
        Heavy,
        Pig
    }

    private Category category;
    private Transform categoryButtons;

    void Start() {
        //Find the object you're looking for
        GameObject tempObject = GameObject.Find("Canvas");
        if (tempObject != null) {
            //If we found the object , get the Canvas component from it.
            canvas = tempObject.GetComponent<Canvas>();
            if (canvas == null) {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
        }
        //category = Category.Pig;
        //categoryButtons = transform.Find("Categories");
        //categoryButtons.Find("All").transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);
    }

    private void Awake() {
        slotsContainer = transform.Find("Slots");
    }
    public void SetPlayer(Player player) {
        this.player = player;
    }
    public void SetInventory(Inventory inventory) {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        RefreshInventoryItems();
    }


    private void Inventory_OnItemListChanged(object sender, System.EventArgs e) {
        RefreshInventoryItems();
    }
    private void RefreshInventoryItems() {
        foreach (Transform child in slotsContainer) {
            if (child == slot) continue;
            Destroy(child.gameObject);
        }
        ShowItemSlots(ItemAnimal.Type.Bird);
    }
    //private void RefreshInventoryItemsByCategory() {
    //    foreach (Transform child in slotsContainer) {
    //        if (child == slot) continue;
    //        Destroy(child.gameObject);
    //    }
    //    if (category == Category.All) {
    //        ShowItemSlots(ItemAnimal.Type.None);
    //    } else if (category == Category.Food) {
    //        ShowItemSlots(ItemAnimal.Type.Food);
    //    } else if (category == Category.Clothes) {
    //        ShowItemSlots(ItemAnimal.Type.Clothes);
    //    } else if (category == Category.Furniture) {
    //        ShowItemSlots(ItemAnimal.Type.Furniture);
    //    }
    //}

    //Instancira slotove ovisno o kreiranim ScriptableObject tipovima itema
    //Provjerava Lijevi klik za funkcionalnosti itema
    private void ShowItemSlots(ItemAnimal.Type itemType) {
        foreach (ItemAnimal item in inventory.GetItems()) {
                GameObject slotGO = Instantiate(slot, slotsContainer).gameObject;
                slotGO.SetActive(true);

                slotGO.GetComponent<Button_UI>().ClickFunc = () => {
                    //AudioManager.Instance.PlaySound(AudioManager.Instance.uiSound2);

                    if (item.animal is Mouse) {
                        var animal = Instantiate(mousePF, slotGO.transform.position, Quaternion.identity);
                        animal.transform.position = GameManager.Instance.spawnLocation.transform.position;
                    } else if (item.animal is Bird) {
                        var animal = Instantiate(birdPF, slotGO.transform.position, Quaternion.identity);
                        animal.transform.position = GameManager.Instance.spawnLocation.transform.position;
                    } else if (item.animal is Hedgehog) {
                        var animal = Instantiate(hedgehogPF, slotGO.transform.position, Quaternion.identity);
                        animal.transform.position = GameManager.Instance.spawnLocation.transform.position;
                    } else if (item.animal is Ladybug) {
                        var animal = Instantiate(ladybugPF, slotGO.transform.position, Quaternion.identity);
                        animal.transform.position = GameManager.Instance.spawnLocation.transform.position;
                    } else if (item.animal is Lizard) {
                        var animal = Instantiate(lizardPF, slotGO.transform.position, Quaternion.identity);
                        animal.transform.position = GameManager.Instance.spawnLocation.transform.position;
                    } else if (item.animal is Frog) {
                        var animal = Instantiate(frogPF, slotGO.transform.position, Quaternion.identity);
                        animal.transform.position = GameManager.Instance.spawnLocation.transform.position;
                    }

                };

                Image image = slotGO.transform.Find("image").GetComponent<Image>();
                image.sprite = item.GetSprite();

                TextMeshProUGUI text = slotGO.transform.Find("text").GetComponent<TextMeshProUGUI>();
                if (item.amount > 1) {
                    text.SetText(item.amount.ToString());
                } else {
                    text.SetText("");
                }
        }
    }

    //public void ActiveCategoryAll() {
    //    category = Category.All;
    //    ScaleButtons();
    //    RefreshInventoryItemsByCategory();
    //}
    //public void ActiveCategoryFood() {
    //    category = Category.Food;
    //    ScaleButtons();
    //    RefreshInventoryItemsByCategory();
    //}
    //public void ActiveCategoryClothes() {
    //    category = Category.Clothes;
    //    ScaleButtons();
    //    RefreshInventoryItemsByCategory();
    //}
    //public void ActiveCategoryFurniture() {
    //    category = Category.Furniture;
    //    ScaleButtons();
    //    RefreshInventoryItemsByCategory();
    //}
    //Povecava veličinu aktivnog gumba kategorije
    private void ScaleButtons() {
        foreach (Transform button in categoryButtons) {
            if(category.ToString() == button.name) {
                button.transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);
            } else {
                button.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
        //AudioManager.Instance.PlaySound(AudioManager.Instance.uiSound5);
    }
    //public List<Item> FilterByFood() {
    //    List<Item> filteredList = new List<Item>();
    //    foreach (Item item in inventory.GetItems()) {
    //        if(item.itemScriptableObject is Food) {
    //            filteredList.Add(item);
    //        }
    //    }
    //    return filteredList;
    //}
    //public List<Item> FilterByClothes() {
    //    List<Item> filteredList = new List<Item>();
    //    foreach (Item item in inventory.GetItems()) {
    //        if (item.itemScriptableObject is Clothes) {
    //            filteredList.Add(item);
    //        }
    //    }
    //    return filteredList;
    //}
    //public List<Item> FilterByFurniture() {
    //    List<Item> filteredList = new List<Item>();
    //    foreach (Item item in inventory.GetItems()) {
    //        if (item.itemScriptableObject is Furniture) {
    //            filteredList.Add(item);
    //        }
    //    }
    //    return filteredList;
    //}
}
