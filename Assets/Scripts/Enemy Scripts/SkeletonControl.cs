using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SkeletonControl : MonoBehaviour
{

    NavMeshAgent agent;
    Animator anim;
    public GameObject player;

    private float distanceToPlayer;
    public float distanceToEngage = 20;
    public float distanceToAttack = 2;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = distanceEqn(transform.position, player.transform.position);

        //player is too far away, do idle animations
        if (distanceToPlayer > distanceToEngage)
        {
            anim.SetBool("Pursue", false);
            anim.SetBool("Strike", false);
            agent.SetDestination(transform.position);
        }

        //walks to the player, engages them
        if (distanceToPlayer <= distanceToEngage && distanceToPlayer > distanceToAttack)
        {
            anim.SetBool("Pursue", true);
            anim.SetBool("Strike", false);
            agent.SetDestination(player.transform.position);
        }

        //stops moving, attacks the player
        if (distanceToPlayer <= distanceToAttack)
        {
            anim.SetBool("Pursue", false);
            anim.SetBool("Strike", true);
            agent.SetDestination(transform.position);
        }



        

        

        //default state is idle

        //switch state when player within 20ft and pursue

        //switch state to attack when reaching destination

        //after skeleton takes damage, check for 0 hp and perform death animation

    }

    private float distanceEqn(Vector3 v1, Vector3 v2)
    {
        return Mathf.Sqrt(Mathf.Pow(v2.x - v1.x, 2) + Mathf.Pow(v2.y - v1.y, 2) + Mathf.Pow(v2.z - v1.z, 2));
    }
}
