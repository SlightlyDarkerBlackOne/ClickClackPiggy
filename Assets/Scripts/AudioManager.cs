using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource woodHit1;
    public AudioSource woodHit2;
    public AudioSource soundtrack;
    public AudioSource soundtrack2;

    public AudioSource oink;
    public AudioSource oink1;
    public AudioSource oink2;

    public AudioSource gameWin;

    public AudioSource bush;
    public AudioSource woodHit;
    public AudioSource stoneHit;

    public float startOinkCooldown = 0.2f;
    private float oinkCooldown = 0;

    #region Singleton
    public static AudioManager Instance { get; private set; }

    // Use this for initialization
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
        PlaySoundTrack();
    }
    private void Update() {
        oinkCooldown -= Time.deltaTime;
    }
    public void PlaySound(AudioSource source) {
        source.Play();
    }
    public void PlayWoodHit() {
        woodHit1.Play();
        PlayOink();
        //int random = Random.Range(1, 3);
        //if (random == 1) {
        //    woodHit1.Play();
        //} else {
        //    woodHit2.Play();
        //}
    }
    public void PlaySoundTrack() {
        int random = Random.Range(1, 3);
        switch (random) {
            case 1: soundtrack.Play();
                break;
            case 2: soundtrack2.Play();
                break;
        }
    }
    public void PlayOink() {
        if(oinkCooldown <= 0) {
            int random = Random.Range(1, 4);
            switch (random) {
                case 1:
                    oink.Play();
                    oinkCooldown = startOinkCooldown;
                    break;
                case 2:
                    oink1.Play();
                    oinkCooldown = startOinkCooldown;
                    break;
                case 3:
                    oink2.Play();
                    oinkCooldown = startOinkCooldown;
                    break;
            }
        }
    }
    public void PlayWinSound() {
        gameWin.Play();
    }
}
