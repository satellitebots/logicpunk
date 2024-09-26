using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndMana : MonoBehaviour
{

    public GameObject healthbar;
    public GameObject manawheel;
    private Slider hpSlider;
    private Slider manaSlider;
    public float maxHP = 100;
    public float currHP = 100;
    private int maxMana = 6;
    public int currMana = 6;

    // Start is called before the first frame update
    void Start()
    {
        hpSlider = healthbar.GetComponent<Slider>();
        hpSlider.maxValue = maxHP;
        hpSlider.value = maxHP;

        manaSlider = manawheel.GetComponent<Slider>();
        manaSlider.maxValue = 1;
        manaSlider.value = 1;

        MapToUIManaWheel();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseHealth(float dmg)
    {
        currHP += -dmg;
        if (currHP > 0)
        {
            hpSlider.value = currHP;
        }

        else
        {
            currHP = 0;
            hpSlider.value = 0;
        }
    }

    public void GainHealth(float hp)
    {
        currHP += hp;
        if (currHP < maxHP)
        {
            hpSlider.value = currHP;
        }

        else
        {
            currHP = maxHP;
            hpSlider.value = maxHP;
        }
    }

    public void LoseMana()
    {
        if (currMana > 0)
        {
            currMana += -1;
        }

        else
        {
            currMana = 0;
        }

        MapToUIManaWheel();
    }

    public void GainMana()
    {
        if (currMana < maxMana)
        {
            currMana += 1;
        }

        else
        {
            currMana = maxMana;
        }

        MapToUIManaWheel();
    }

    public void MapToUIManaWheel()
    {
        if (currMana == 0)
        {
            manaSlider.value = 0;
        }

        else if (currMana == 1)
        {
            manaSlider.value = 0.17f;
        }

        else if (currMana == 2)
        {
            manaSlider.value = 0.326f;
        }

        else if (currMana == 3)
        {
            manaSlider.value = 0.5f;
        }

        else if (currMana == 4)
        {
            manaSlider.value = 0.672f;
        }

        else if (currMana == 5)
        {
            manaSlider.value = 0.825f;
        }

        else if (currMana == 6)
        {
            manaSlider.value = 1.0f;
        }
    }

}
