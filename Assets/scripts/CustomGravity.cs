using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    public float gravityScale = 1.0f;
    public float normalGravityScale = 1.0f;
    public float fallingGravityScale = 1.0f;
    public static float globalGravity = -9.81f;

    Rigidbody rb;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        gravityScale = normalGravityScale;
    }
    void FixedUpdate()
    {
        ApplyGravity();
    }

    public void ApplyGravity()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }
}
