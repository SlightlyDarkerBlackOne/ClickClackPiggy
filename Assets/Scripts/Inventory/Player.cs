using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Inventory inventory;
    [SerializeField]
    InventoryUI inventoryUI;

    #region Singleton
    public static Player Instance { get; private set; }

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    #endregion

    private void Start() {
        inventory = new Inventory(UseItem);
        inventoryUI.SetInventory(inventory);
        inventoryUI.SetPlayer(this);
    }
    private void UseItem(ItemAnimal item) {
        inventory.RemoveItem(new ItemAnimal { animal = item.animal,amount = 1 });
    }
    public Inventory GetInventory() {
        return inventory;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            AudioManager.Instance.PlayWoodHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Win") {
            if (!GameManager.Instance.wonLevel) {
                AudioManager.Instance.PlayWinSound();
                GameManager.Instance.wonLevel = true;
            }
            
            //Show NextLevelScreen
            //Fade the scene
        }
    }
}
