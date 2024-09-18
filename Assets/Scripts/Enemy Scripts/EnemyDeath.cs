using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Renderer rdr;
    private float alpha;
    private Animator anim;
    private EnemyHealth enemyHealthScript;

    void Start()
    {
        rdr = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
        alpha = rdr.material.color.a;
        enemyHealthScript = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (anim.GetBool("Death") == true)
        {
            //fade out character

            if (rdr.material.color.a > 0)
            {
                alpha += -0.01f;
                rdr.material.color = new Color(1f, 1f, 1f, alpha);
            }

            else
            {
                Destroy(gameObject);
                Destroy(enemyHealthScript.healthbar);
            }
        }
    }
}
