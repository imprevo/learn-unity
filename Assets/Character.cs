using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5.0f;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletPosition;
    [SerializeField]
    private float fireRate = 0.5f;
    private float nextFireTime = 0f;

    private CharacterController controller;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 moveDirection = GetMoveDirection();
        Move(moveDirection);

        Vector3 rotateDirection = GetRotateDirection();
        Rotate(rotateDirection);

        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Move(Vector3 direction)
    {
        controller.Move(direction * Time.deltaTime * playerSpeed);
    }

    void Rotate(Vector3 direction)
    {
        transform.rotation = Quaternion.Euler(direction);
    }

    void Fire()
    {
        Instantiate(bulletPrefab, bulletPosition.position, bulletPosition.rotation);
    }

    Vector3 GetMoveDirection() => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    Vector3 GetRotateDirection()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
        float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);

        return new Vector3(0f, -angle - 90, 0f);
    }

    float AngleBetweenPoints(Vector2 a, Vector2 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
