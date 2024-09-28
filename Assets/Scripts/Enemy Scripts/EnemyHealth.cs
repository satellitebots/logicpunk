using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private GameObject healthbarOriginal;
    public GameObject healthbar;
    public float health = 50;
    private Slider slider;
    private GameObject cam;

    private GameObject canvas;

    public GameObject player;

    private Animator anim;
    

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        player = GameObject.Find("Hero");
        healthbarOriginal = GameObject.Find("Canvas/EnemyHealthBar");
        healthbar = Instantiate(healthbarOriginal, canvas.transform);
        cam = GameObject.Find("Hero/Main Camera");
        anim = GetComponent<Animator>();

        slider = healthbar.GetComponent<Slider>();
        slider.maxValue = health;
        slider.value = health;

        healthbar.transform.position = new Vector3(0f, 3f, 0f);        
    }

    void LateUpdate()
    {
        healthbar.transform.position = transform.position + new Vector3(0f, 2f, 0f);
        healthbar.transform.LookAt(cam.transform.position, Vector3.up);
    }

    public void TakeDamage(float dmg)
    {
        //enemy takes damage.
        slider.value += -dmg;

        if (slider.value <= 0)
        {
            anim.SetBool("Death", true);
        }

        else
        {
            anim.SetBool("Damage", true);
        }
    }
}
