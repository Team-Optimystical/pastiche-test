using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater2D : MonoBehaviour {

    private Transform t;
    private float randRot;

    private void Start()
    {
        randRot = Random.Range(-15f, 15f);
    }

    void FixedUpdate() {
        t = this.GetComponent<Transform>();
        t.Rotate(0f, randRot, 0f);
    }
}
