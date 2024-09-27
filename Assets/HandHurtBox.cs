using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHurtBox : MonoBehaviour
{

    public GameObject player;
    public Transform rootTransform;
    public GameObject skeleton;
    public EnemyHealth enemyHealthScript;
    public HealthAndMana HPandMPScript;
    public float damage = 10;
    public float hp;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rootTransform = transform.root;
        skeleton = rootTransform.gameObject;
        enemyHealthScript = skeleton.GetComponent<EnemyHealth>();
        player = GameObject.Find("Hero");
        //player = enemyHealthScript.player;
        HPandMPScript = player.GetComponent<HealthAndMana>();
        hp = HPandMPScript.currHP;
        anim = skeleton.GetComponent<Animator>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider c)
    {
        Debug.Log(c);

        if (anim.GetBool("Swinging") == true && c.tag == "Player")
        {
            Debug.Log("collision");
            HPandMPScript.LoseHealth(damage);
            hp = HPandMPScript.currHP;
        }      
    }
}
