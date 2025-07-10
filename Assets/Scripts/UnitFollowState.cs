using UnityEngine;
using UnityEngine.AI;

public class UnitFollowState : StateMachineBehaviour
{

    AttackController attackController;
    NavMeshAgent agent;
    public float attackingDistance = 1f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attackController = animator.transform.GetComponent<AttackController>();
        agent = animator.transform.GetComponent<NavMeshAgent>();
        attackController.SetFollowMaterial(); // Set the follow material when entering the state
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Should Unit Transition to Idle State?

        if (attackController.targetToAttack == null)
        {
            animator.SetBool("isFollowing", false);
        }
        else
        {
            //If there is no direct command to move, the unit should follow the target
            if (animator.transform.GetComponent<UnitMovement>().isCommandedToMove==false)
            {
                //Should Unit Transition to Following State?

                agent.SetDestination(attackController.targetToAttack.position);
                animator.transform.LookAt(attackController.targetToAttack);

                //Should Unit Transition to Attack State?

                float distanceToTarget = Vector3.Distance(animator.transform.position, attackController.targetToAttack.position);
                if (distanceToTarget < attackingDistance)
                {
                    agent.SetDestination(animator.transform.position); // Stop moving when exiting the state
                    animator.SetBool("isAttacking", true);
                }
            }
        }


    }

}
