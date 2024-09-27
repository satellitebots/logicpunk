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
    public float distanceToAttack = 1f;
    public float rotationOffset = 0f;
    private Vector3 rayPosition;
    private Vector3 destination;
    private CharacterController charControlScript;
    private float lastGroundedHeight;
    private float theta;
    private Quaternion rot;

    private Ray ray;
    private RaycastHit hit;
    private bool raycast;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = true;

        anim = GetComponent<Animator>();
        player = GameObject.Find("Hero");

        charControlScript = player.GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.updateRotation = true;

        //This code tries to account for the player jumping. AI should behave as if the player is still grounded.
        if (charControlScript.IsGrounded)
        {
            lastGroundedHeight = player.transform.position.y;
            destination = player.transform.position;
        }

        else if (!charControlScript.IsGrounded)
        {
            destination = new Vector3(player.transform.position.x, lastGroundedHeight, player.transform.position.z);
        }

        distanceToPlayer = Vector3.Distance(transform.position, destination);

        if (anim.GetBool("Death") == true)
        {
            agent.SetDestination(transform.position);
        }

        //player is too far away, do idle animations
        else if (distanceToPlayer > distanceToEngage)
        {
            anim.SetBool("Pursue", false);
            anim.SetBool("Strike", false);
            agent.SetDestination(transform.position);
        }

        //walks to the player, engages them
        else if (distanceToPlayer <= distanceToEngage && distanceToPlayer > distanceToAttack)
        {
            anim.SetBool("Pursue", true);
            anim.SetBool("Strike", false);
            agent.SetDestination(destination);
        }

        //stops moving, attacks the player
        else if (distanceToPlayer <= distanceToAttack)
        {
            anim.SetBool("Pursue", false);
            anim.SetBool("Strike", true);
            agent.SetDestination(transform.position);

            rayPosition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            ray = new Ray(rayPosition, transform.forward);
            //Debug.DrawRay(rayPosition, transform.forward);

            raycast = Physics.Raycast(ray, out hit, 3f);

            //Debug.Log(transform.forward);

            if (!raycast)
            {
                rot = Quaternion.LookRotation(player.transform.position - transform.position, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
            }
        }
    }
}
