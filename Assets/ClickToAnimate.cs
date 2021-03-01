using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToAnimate : MonoBehaviour
{
    private Animator anim;
    public GameObject coconut;
    public Transform coconutFallPoint;

    private bool coconutToFall = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnMouseUp() {
        anim.SetTrigger("Shake");
        if (Random.Range(0, 100 + 1) > 40) {
            AudioManager.Instance.woodHit.volume = 0.63f;
            StartCoroutine(SummonCoconuts());
        }
    }

    private IEnumerator SummonCoconuts() {
        yield return new WaitForSeconds(0.83f);
        int random = Random.Range(-3, 4);
        Vector3 offset = new Vector3(random, 0, 0);
        Transform coconutPoint = coconutFallPoint;
        coconutPoint.position += offset;
        Instantiate(coconut, coconutPoint);
    }
}
