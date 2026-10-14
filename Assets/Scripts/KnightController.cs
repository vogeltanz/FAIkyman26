using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class KnightController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidBody2D;
    InputAction moveAction;
    InputAction jumpAction;

    [SerializeField]
    [Range(0.1f, 10f)]
    float speed = 2f;

    [SerializeField]
    float jumpSpeed = 5f;

    bool isOnGround = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        jumpAction.performed += JumpAction_performed;
    }

    private void JumpAction_performed(InputAction.CallbackContext obj)
    {
        if (isOnGround == true)
        {
            rigidBody2D.linearVelocityY = jumpSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOnGround = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isOnGround == false)
        {
            isOnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnGround = false;
    }

    private void OnDestroy()
    {
        jumpAction.performed -= JumpAction_performed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        float vx = moveInput.x;

        if (vx != 0)
        {
            animator.SetBool("IsWalking", true);

            transform.Translate(vx * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
