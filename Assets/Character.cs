using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5.0f;
    [SerializeField]
    private GameObject bulletPrefab;

    private CharacterController controller;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 moveDirection = GetMoveDirection();
        Move(moveDirection);

        if (Input.GetButtonDown("Jump"))
        {
            Fire();
        }
    }


    void Move(Vector3 moveDirection)
    {
        controller.Move(moveDirection * Time.deltaTime * playerSpeed);

        if (moveDirection != Vector3.zero)
        {
            gameObject.transform.forward = moveDirection;
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, GetBulletPosition(), transform.rotation);
    }

    Vector3 GetMoveDirection() => new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    Vector3 GetBulletPosition() => transform.position + transform.forward.normalized;
}
