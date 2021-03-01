using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
    #endregion
    public GameObject spawnLocation;
    public Vector2 clickClackScene;
    public Vector2 findScene;
    public Vector2 findScene2;

    public bool wonLevel = false;
    public enum Scene{
        ClickClack,
        Find,
        Find2
    }
    private Scene activeScene;

    private void Start() {
        activeScene = Scene.ClickClack;
    }

    public void ActivateFindScene(float offset) {
        activeScene = Scene.Find;
        GetComponent<MoveCamera>().MoveToScene(findScene.x, findScene.y + offset);
    }
    public void ActivateClickClackScene() {
        activeScene = Scene.ClickClack;
        GetComponent<MoveCamera>().MoveToScene(clickClackScene.x, clickClackScene.y);
    }
    public Scene GetScene() {
        return activeScene;
    }
    public void ChangeScene() {
        if(activeScene == Scene.ClickClack) {
            ActivateFindScene(0);
        } else if(activeScene == Scene.Find) {
            ActivateFindScene(-200f);
            activeScene = Scene.Find2;
        } else if (activeScene == Scene.Find2) {
            ActivateClickClackScene();
        }
    }
}
