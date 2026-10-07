using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class KnightController : MonoBehaviour
{
    Animator animator;
    InputAction moveAction;

    [SerializeField]
    [Range(0.1f, 10f)]
    float speed = 2f;

    void Awake()
    {
        animator = GetComponent<Animator>();
        moveAction = InputSystem.actions.FindAction("Move");
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
