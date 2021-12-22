using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Pathfinding;

public class Stats : MonoBehaviour
{
    public int lvl = 1;
    public int score = 0;
    public int lvlUpPrice = 1;

    public int Atk = 5;
    public int Wit = 1;

    public int Health;
    public int MaxHealth;

    public bool isPlayer = true;

    public List<GameObject> drops;
    public float drapchance = 0.25f;

    public GameObject HealthPoint;
    public GameObject HPbar;
    [SerializeField]List<GameObject> HP;
    GameObject obj;

    //public GameObject deathScreen;

    public Text scr_text;
    public Text atk_text;
    public Text wit_text;

    public int nrOfBatteries = 0;
    public int money = 0;

    public Text batteriesTxt;
    public Text moneyTxt;
    ParticleSystem particle;

    //public GameObject deathObject;

    //disslove death effect for enemies
    Material material;
    AIPath ai;
    public enemyGeneral colision;
    float timer = 0f;
    float fade = 1f;
    public float deathTime = 2f;

    //damage taking cooldowns for player
    float dmgTimer = 0f;
    public float dmgCooldown = 0.5f;
    bool canBeDamaged = true;

    private void Start()
    {
        MaxHealth = 2 * Wit;
        Health = MaxHealth;
        if (isPlayer)
        {
            particle = GetComponent<ParticleSystem>();
            moneyTxt.text = money.ToString() + "$";
            batteriesTxt.text = nrOfBatteries.ToString();
            scr_text.text = "OmniTools: " + score.ToString();
            atk_text.text = "Offense: " + Atk.ToString();
            wit_text.text = "Defence: " + Wit.ToString();
            for (int i = 0; i < Health; i++)
            {
                obj = Instantiate(HealthPoint);
                obj.transform.parent = HPbar.transform;
                HP.Add(obj);
            }
        }
        else
        {
            material = GetComponent<SpriteRenderer>().material;
            ai = GetComponent<AIPath>();
            colision = GetComponent<enemyGeneral>();
        }
    }

    

    public void upAtk()
    {
        if (score >= lvlUpPrice)
        {
            Atk++;
            score -= lvlUpPrice;
            scr_text.text = "OmniTools: " + score.ToString();
            atk_text.text = "Offense: " + Atk.ToString();
        }
    }

    public void upWit()
    {
        if (score >= lvlUpPrice)
        {
            Wit++;
            MaxHealth = MaxHealth + 1;
            Health += 1;
            score -= lvlUpPrice;
            lvlUpPrice += (int)(lvlUpPrice * 0.2f);
            scr_text.text = "OmniTools: " + score.ToString();
            wit_text.text = "Defence: " + Wit.ToString();

            obj = Instantiate(HealthPoint);
            obj.transform.parent = HPbar.transform;
            HP.Add(obj);
            
        }
    }

    private void Update()
    {
        if(isPlayer && HP.Count != Health)
        {
            if(HP.Count > Health)
            {
                Destroy(HP[HP.Count - 1]);
                HP.RemoveAt(HP.Count - 1);
            }
            else if (HP.Count < Health)
            {
                obj = Instantiate(HealthPoint);
                obj.transform.parent = HPbar.transform;
                HP.Add(obj);
            }
        }

        if(Health > MaxHealth)
        {
            Health = MaxHealth;
        }

        if(Input.GetButtonDown("Heal") && Health != MaxHealth)
        {
            nrOfBatteries--;
            Health += 4;
        }

        if (isPlayer)
        {
            moneyTxt.text = money.ToString() + "$";
            batteriesTxt.text = nrOfBatteries.ToString();
            dmgTimer += Time.deltaTime;
            if(dmgTimer > dmgCooldown)
            {
                canBeDamaged = true;
            }
        }

        if (Health <= 0)
        {
            umrzyj();
        }
    }

    public void umrzyj()
    {   
        if(isPlayer)
            Destroy(gameObject);
        else
        {
            colision.enabled = false;
            ai.enabled = false;
            timer += Time.deltaTime;
            fade -= Time.deltaTime / deathTime;
            material.SetFloat("_Fade",fade);
            Debug.Log(material.GetFloat("_Fade").ToString());
            if(timer >= deathTime)
            {
                Destroy(gameObject);
            }
        }
    }

    //a function that handles taking damage and events asocieted with it
    public void takeDmg(int amount)
    {
        if(canBeDamaged)
        {
            dmgTimer = 0f;
            Health -= amount;
            if (isPlayer)
            {
                for (int i = 0; i < amount; i++)
                {
                    Destroy(HP[HP.Count - 1]);
                    HP.RemoveAt(HP.Count - 1);
                }
            }
        }
    }

    public void batteryPickUp(int amount)
    {
        nrOfBatteries++;
        //TODO: play sound
    }

    public void moneyPickUp(int amount)
    {
        money += amount;
        //TODO: play sound
    }

    public void toolPickUp(int amount)
    {
        score += amount;
        scr_text.text = "OmniTools: " + score.ToString();
    }

}
