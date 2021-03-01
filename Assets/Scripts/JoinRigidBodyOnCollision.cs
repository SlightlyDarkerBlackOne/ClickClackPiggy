using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinRigidBodyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        JoinOnCollision(collision);
    }

    private void JoinOnCollision(Collision2D coll) {
        if(coll.transform.tag == "Player") {
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
            joint.anchor = coll.transform.position;
            joint.connectedBody = coll.transform.GetComponent<Rigidbody2D>();
            joint.enableCollision = false;
        }
    }
}
