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
    private float healthbarX;
    private float healthbarY;
    private float healthbarZ;
    private float healthbarW;

    private GameObject canvas;

    public GameObject player;
    

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        healthbarOriginal = GameObject.Find("Canvas/EnemyHealthBar");
        healthbar = Instantiate(healthbarOriginal, canvas.transform);
        healthbarOriginal.SetActive(false);
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
}
