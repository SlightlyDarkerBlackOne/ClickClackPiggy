using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutImpact : MonoBehaviour
{
    public float soundCooldown = 0.2f;
    private float cd = 0;
    private int hitCounter = 1;

    private void Update() {
        cd -= Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        AudioSource hitSound = AudioManager.Instance.woodHit;
        if(hitCounter <= 7) {
            hitSound.volume /= hitCounter;
        }
        hitCounter++;
        Debug.Log("Hitcount: " + hitCounter);
        if(cd <= 0) {
            AudioManager.Instance.PlaySound(hitSound);
            cd = soundCooldown;
        }

    }
}
