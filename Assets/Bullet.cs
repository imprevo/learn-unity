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
        Destroy(gameObject, 5.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy)
        {
            enemy.TakeDamage();
        }

        Destroy(gameObject);
    }
}
