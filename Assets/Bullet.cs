using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Fire();
    }

    void Fire()
    {
        rb.AddRelativeForce(Vector3.forward * bulletSpeed);
        // rb.AddForce(transform.forward * bulletSpeed);
        Destroy(gameObject, 5.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
