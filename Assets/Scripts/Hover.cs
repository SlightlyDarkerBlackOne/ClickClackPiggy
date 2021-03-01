using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    private Animator anim;
    private Vector3 localScale;
    private bool alreadyClicked;

    private AnimalSC animalSC;
    [SerializeField]
    private GameObject particleBurst;

    public bool isAnimal;
    public bool isPig;
    public bool isBush;
    public bool isStump;

    private void Awake() {
        if (!isAnimal && GetComponent<Animator>() != null) {
            anim = GetComponent<Animator>();
        } else if(isAnimal){
            animalSC = GetComponent<Animal>().animal;
        }
        localScale = transform.localScale;
    }

    // Start is called before the first frame update
    void OnMouseOver() {
        if(!alreadyClicked && !isPig)
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f) + localScale;
        
    }
    void OnMouseExit() {
        if(!alreadyClicked)
            transform.localScale = localScale;
    }
    private void OnMouseUp() {
        //transform.position -= new Vector3(3, 0, 0);
        if (!isAnimal && !isPig) {
            anim?.SetTrigger("move");
            if (anim == null) {
                Destroy(gameObject);
            }
            Debug.Log("Burst!");
            GameObject burst = Instantiate(particleBurst, transform.position, transform.rotation);
            Destroy(burst, 2f);
            if (isBush) {
                AudioManager.Instance.PlaySound(AudioManager.Instance.bush);
            }else if (isStump) {
                AudioManager.Instance.PlaySound(AudioManager.Instance.woodHit);
            }

        } else if (isPig) {
            AudioManager.Instance.PlayOink();
        } else {
            Player.Instance.GetInventory()
                   .AddItem(new ItemAnimal { animal = animalSC, amount = 1 });
            Destroy(gameObject);
        }
        
        alreadyClicked = true;
    }
}
