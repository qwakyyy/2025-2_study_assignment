using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    void Start()
    {
        GameObject circle = GameObject.Find("Circle");
        Rigidbody circleRigidBody = circle.GetComponent<Rigidbody>();
    }
}
