using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovementSimple : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Keyboard.current.wKey.isPressed) moveZ += 1f;
        if (Keyboard.current.sKey.isPressed) moveZ -= 1f;
        if (Keyboard.current.aKey.isPressed) moveX -= 1f;
        if (Keyboard.current.dKey.isPressed) moveX += 1f;

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        if (move.magnitude > 0.01f)
        {
            rb.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(move, Vector3.up) * Quaternion.Euler(0, -90f, 0);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}
