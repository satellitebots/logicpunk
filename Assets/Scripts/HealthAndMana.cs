using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndMana : MonoBehaviour
{

    public GameObject healthbar;
    public GameObject manawheel;
    public GameObject damagedObject;
    private Slider hpSlider;
    private Slider manaSlider;
    private Slider damagedSlider;
    public float maxHP = 100;
    public float currHP = 100;
    private int maxMana = 6;
    public int currMana = 6;

    private bool losingHP = false;
    private float losingHPtimer = 0;
    private float losingHPCD = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        hpSlider = healthbar.GetComponent<Slider>();
        hpSlider.maxValue = maxHP;
        hpSlider.value = maxHP;

        manaSlider = manawheel.GetComponent<Slider>();
        manaSlider.maxValue = 1;
        manaSlider.value = 1;

        damagedSlider = damagedObject.GetComponent<Slider>();
        damagedSlider.maxValue = maxHP;
        damagedSlider.value = maxHP;
        MapToUIManaWheel();

    }

    // Update is called once per frame
    void Update()
    {

        if (damagedSlider.value < hpSlider.value)
        {
            losingHP = false;
            damagedSlider.value = hpSlider.value;
            losingHPtimer = 0;
        }

        if (losingHP)
        {
            losingHPtimer += Time.deltaTime;

            if (losingHPtimer > losingHPCD)
            {
                damagedSlider.value += -15f * Time.deltaTime;
            }
        }
    }

    public void LoseHealth(float dmg)
    {

        losingHP = true;

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

    private int[] manaAmounts = new int[4] { 0, 1, 2, 3 };

}
