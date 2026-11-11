using UnityEngine;

public class DragonWalkSMB : StateMachineBehaviour
{
    public Transform PlayerPosition { get; set; }

    public float Speed { get; set; }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerPosition != null)
        {
            var dragonTransform = animator.gameObject.transform;
            var direction = PlayerPosition.position - dragonTransform.position;
            dragonTransform.Translate(direction.normalized * Speed * Time.deltaTime);
            if (direction.x > 0)
            {
                dragonTransform.localScale = new Vector3(1, 1, 1);
            }
            else if (direction.x < 0)
            {
                dragonTransform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
