using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : StateMachineBehaviour
{

    private float timePassed;
    public GameObject hitboxOriginal;
    private EnemyHealth enemyHealthScript;
    private GameObject skeleton;
    public GameObject hitbox;
    public bool reset1 = true;
    public bool reset2 = false;
    public Vector3 offset;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyHealthScript = animator.gameObject.GetComponent<EnemyHealth>();
        skeleton = enemyHealthScript.gameObject;
        offset = skeleton.transform.forward + new Vector3(0f, 1f, 0.2f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timePassed += Time.deltaTime;

        if (reset1 && !hitbox && (timePassed % stateInfo.length) >= 0.55f && (timePassed % stateInfo.length) <= 0.65f)
        {
            //implement catch here. if hurtbox generating at the wrong time (instantiation and timePassed don't line up), perform reset
            hitbox = Instantiate(hitboxOriginal, skeleton.transform);
            hitbox.transform.position = skeleton.transform.position + offset;
            reset1 = false;
            reset2 = true;
            //Debug.Log("hitbox created");
            //Debug.Log(timePassed % stateInfo.length);
        }

        else if (reset2 && hitbox && (timePassed % stateInfo.length) >= 0.7f && (timePassed % stateInfo.length) <= 0.8)
        {
            Destroy(hitbox);
            reset2 = false;
            //Debug.Log("hitbox deleted");
            //Debug.Log(timePassed % stateInfo.length);
        }

        else if (hitbox)
        {
            //update hitbox position
            hitbox.transform.position = skeleton.transform.position + offset;
        }

        if (!reset1 && !reset2 && (timePassed % stateInfo.length) > 1.1f)
        {
            reset1 = true;
        }
    }

    public void LateUpdate()
    {

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
