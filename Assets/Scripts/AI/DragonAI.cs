using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DragonAI : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    GameObject player;

    [SerializeField]
    float detectionRange = 10f;

    [SerializeField]
    float speed = 2f;

    bool playerWasVisible = false;
    float timeSincePlayerLastSeen = 0f;

    [SerializeField]
    float timeToForgetPlayer = 3f;

    void Awake()
    {
        animator = GetComponent<Animator>();

        var dragonWalkSMB = animator.GetBehaviour<DragonWalkSMB>();
        dragonWalkSMB.PlayerPosition = player.transform;
        dragonWalkSMB.Speed = speed;
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
                playerWasVisible = true;
                timeSincePlayerLastSeen = 0;
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
        if (playerWasVisible)
        {
            animator.SetBool("PlayerWasVisible", true);
            timeSincePlayerLastSeen += Time.deltaTime;
            if (timeSincePlayerLastSeen >= timeToForgetPlayer)
            {
                playerWasVisible = false;
                timeSincePlayerLastSeen = 0;
                animator.SetBool("PlayerWasVisible", false);
            }
        }

        float playerDistance = Vector2.Distance(transform.position, player.transform.position);
        animator.SetFloat("PlayerDistance", playerDistance);
    }
}
