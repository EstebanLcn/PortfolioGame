using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Abilities : MonoBehaviour
{
    public Image abilityImage1;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability1;

    public Image abilityImage2;
    public float cooldown2 = 15;
    bool isCooldown2 = false;
    public KeyCode ability2;

    public Image abilityImage3;
    public float cooldown3 = 10;
    bool isCooldown3 = false;
    public KeyCode ability3;

    public Weapon shooting;
    public PlayerSpeedIncrease speed;
    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
        Ability3();
    }

    void Ability1()
    {
        if(Input.GetKey(ability1) && isCooldown == false)
        {
            isCooldown = true;
            abilityImage1.fillAmount = 1;
            shooting.ShootAbility1();
        }

        if(isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
    void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
            PlayerHealthController.instance.HealPlayer();
        }

        if (isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }
    void Ability3()
    {
        if (Input.GetKey(ability3) && isCooldown3 == false)
        {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
            speed.SpeedPlayer();
        }

        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            if (abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }
}
