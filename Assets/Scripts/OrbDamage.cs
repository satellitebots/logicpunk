using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDamage : MonoBehaviour
{

    public GameObject skeleton;
    public float orbDamage = 30f;
    public EnemyHealth enemyHealthScript;
    public GameObject player;
    public ShootOrb orbScript;
    private float maxDistance;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Hero");
        orbScript = player.GetComponent<ShootOrb>();
        maxDistance = orbScript.maxDistance;
        playerTransform = orbScript.playerTransform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "enemy")
        {
            skeleton = c.gameObject;
            enemyHealthScript = skeleton.GetComponent<EnemyHealth>();
            enemyHealthScript.TakeDamage(orbDamage);
        }
    }
}
