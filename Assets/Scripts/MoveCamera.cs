using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public void MoveToScene(float x, float y) {
        transform.position = new Vector3(x, y, transform.position.z);
    }
}
