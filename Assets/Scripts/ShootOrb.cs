using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOrb : MonoBehaviour
{

    public float cooldown = 3f;
    private float cdTime = 3f;
    public GameObject orb;
    private Rigidbody rb;
    public Transform playerTransform;
    private Vector3 initialPlayerDistance;
    private HealthAndMana HPandManaScript;

    //orb is destroyed after it has travelled maxDistance away from its spawn point
    public float maxDistance = 10f;
    private GameObject projectileOrb;

    //will need to change these offsets when the character model is updated
    private Vector3 offset = new Vector3(0f, 1f, 0f);
    private Vector3 teleportOffset = new Vector3(0f, -1f, 0f);

    private Vector3 spawnpoint;

    public float orbSpeed = 8f;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        initialPlayerDistance = playerTransform.position;
        HPandManaScript = GetComponent<HealthAndMana>();
    }

    // Update is called once per frame
    void Update()
    {
        cdTime += Time.deltaTime;

        //teleport if an orb already exists. this code block MUST run before firing the projectile or it will be immediately consumed (second if block)
        if (Input.GetButtonDown("Fire1") && projectileOrb)
        {
            playerTransform.position = projectileOrb.transform.position + teleportOffset;
            Destroy(projectileOrb);
        }

        //send out orb if one doesn't exist and it isn't on cooldown
        if (Input.GetButtonDown("Fire1") && cdTime > cooldown && !projectileOrb && HPandManaScript.currMana > 0)
        {
            HPandManaScript.LoseMana();
            spawnpoint = playerTransform.position + offset;
            initialPlayerDistance = playerTransform.position;
            projectileOrb = Instantiate(orb, spawnpoint, orb.transform.rotation);
            projectileOrb.SetActive(true);
            rb = projectileOrb.GetComponent<Rigidbody>();
            rb.velocity = playerTransform.forward * orbSpeed;
            cdTime = 0;

        }


        //if orb is too far away, destroy it
        checkForDestroyDistance(projectileOrb, playerTransform, maxDistance);
    }

    public void checkForDestroyDistance(GameObject projectileOrb, Transform playerTransform, float maxDistance)
    {
        if (projectileOrb)
        {
            if (Vector3.Distance(projectileOrb.transform.position, playerTransform.position) > maxDistance)
            {
                Destroy(projectileOrb);
            }
        }
    }

    //distance formula
    //THIS ISN'T WORKING. USE VECTOR3.DISTANCE(A,B) INSTEAD.
    public float getDistance(Vector3 v1, Vector3 v2)
    {
        return Mathf.Pow(Mathf.Pow(v2.z - v1.z, 2) + Mathf.Pow(v2.y - v1.y, 2) + Mathf.Pow(v2.x - v2.x, 2), 0.5f);
    }
}
