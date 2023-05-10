using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;
    public float rotSpd = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float forwd = 5f;
        float translate = forwd * speed * Time.deltaTime;
        float rotate = forwd * rotSpd * Time.deltaTime;

        // Update position
        if (Input.GetKey("s")) { // s
            transform.Translate(0f, 0f, translate);
        }
        if (Input.GetKey("w")) { // w
            transform.Translate(0f, 0f, -translate);
        }
        if (Input.GetKey("a")) { // a
            transform.Translate(translate, 0f, 0f);
        }
        if (Input.GetKey("d")) { // d
            transform.Translate(-translate, 0f, 0f);
        }

        // Update direction camera faces
        if (Input.GetKey("q")) {    // v-- spins camera
            transform.Rotate(0f, -rotate, 0f);
            //               ^-- rotates camera
        }
        if (Input.GetKey("e")) {
            transform.Rotate(0f, rotate, 0f);
        }
    }
}
