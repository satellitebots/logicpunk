using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider c)
    {
        Debug.Log(c.tag);
        Debug.Log("collision");
        if (c.CompareTag("orb"))
        {
            
            Destroy(this.gameObject);
        }
    }

}
