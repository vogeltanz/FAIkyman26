using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DragonAI : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    GameObject player;

    [SerializeField]
    float detectionRange = 10f;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void CheckPlayerVisibility(bool isVisible)
    {
        if (isVisible == true)
        {
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, ~LayerMask.GetMask("Ignore Raycast"));
            if (hit.collider != null && hit.collider.gameObject == player)
            {
                animator.SetBool("PlayerIsVisible", true);
            }
            else
            {
                animator.SetBool("PlayerIsVisible", false);
            }
        }
        else
        {
            animator.SetBool("PlayerIsVisible", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
