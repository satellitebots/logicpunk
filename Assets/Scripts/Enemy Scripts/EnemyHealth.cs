using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public GameObject healthbarOriginal;
    public GameObject healthbar;
    public float health = 50;
    private Slider slider;
    public Camera cam;
    

    void Start()
    {
        //healthbar = GameObject.Find("Canvas/EnemyHealthBar");
        healthbar = Instantiate(healthbarOriginal, healthbarOriginal.transform);
        healthbar.SetActive(true);
        slider = healthbar.GetComponent<Slider>();
        slider.maxValue = health;
        slider.value = health;

        cam = Camera.main;
        
        

    }

    // Update is called once per frame
    void Update()
    {
        //see https://www.youtube.com/watch?v=6U_OZkFtyxY for reference
        //won't be able to get this working until camera work is finished
        healthbar.transform.position = transform.position + new Vector3(0f, 2f, 0f);
        healthbar.transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
    }
}
