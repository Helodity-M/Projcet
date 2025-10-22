using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    [SerializeField] Vector2 moveInput;
    InputAction moveAction;
    Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.performed += MoveAction_performed;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        moveAction.performed -= MoveAction_performed;
    }

    private void MoveAction_performed(InputAction.CallbackContext obj)
    {
        moveInput = obj.ReadValue<Vector2>();
    }
    void OnMove(InputValue inputValue)
    {
        Debug.Log("wow guys this is really good code");
        moveInput = inputValue.Get<Vector2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.linearVelocity += moveInput * moveSpeed * Time.deltaTime;
    }

}
