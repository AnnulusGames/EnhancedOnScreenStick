using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] InputAction inputAction;
    [SerializeField] float movementSpeed = 5f;

    void Start()
    {
        inputAction.Enable();
    }

    void Update()
    {
        transform.position += movementSpeed * Time.deltaTime * (Vector3)inputAction.ReadValue<Vector2>();
    }
}
