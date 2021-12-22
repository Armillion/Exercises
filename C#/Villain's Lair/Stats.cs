using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public int lvl = 1;
    public int score = 0;
    public int lvlUpPrice = 10;

    public int Atk = 5;
    public int Wit = 5;
    public int Mgc = 5;
    public int Spd = 5;

    public int Health;
    public int MaxHealth;

    public int Mp;
    public int maxMp;

    public bool isPlayer = true;

    public List<GameObject> drops;
    public float drapchance = 0.25f;

    public int highScore = 0;
    public GameObject deathScreen;
    public Text score_text;
    public Text highScore_text;

    public Text hp_text;
    public Text mp_text;
    public Text scr_text;
    public Text lvl_text;
    public Text lvlUp_text;
    public Text atk_text;
    public Text wit_text;
    public Text mgc_text;
    public Text spd_text;

    public GameObject deathObject;

    playerMovement movement;
    Attack attack;

    private void Start()
    {
        MaxHealth = 2 * Wit;
        Health = MaxHealth;
        maxMp = Mgc;
        Mp = maxMp;

        highScore = PlayerPrefs.GetInt("Highscore", 0);


        if(isPlayer)
        {
            movement = GetComponent<playerMovement>();
            attack = GetComponent<Attack>();
        }
    }

    

    public void upAtk()
    {
        if (score >= lvlUpPrice)
        {
            Atk++;
            lvl++;
            score -= lvlUpPrice;
            lvlUpPrice += (int)(lvlUpPrice * 0.2f);

        }
    }

    public void upWit()
    {
        if (score >= lvlUpPrice)
        {
            Wit++;
            MaxHealth = MaxHealth + 1;
            Health += 2;
            lvl++;
            score -= lvlUpPrice;
            lvlUpPrice += (int)(lvlUpPrice * 0.2f);
        }
    }

    public void upMgc()
    {
        if (score >= lvlUpPrice)
        {
            Mgc++;
            maxMp += 2;
            Mp = maxMp;
            lvl++;
            score -= lvlUpPrice;
            lvlUpPrice += (int)(lvlUpPrice * 0.2f);
        }
    }

    public void upSpd()
    {
        if (score >= lvlUpPrice)
        {
            Spd++;
            lvl++;
            score -= lvlUpPrice;
            lvlUpPrice += (int)(lvlUpPrice * 0.2f);
        }
    }

    private void Update()
    {
        if (isPlayer)
        {
            hp_text.text = Health.ToString();
            mp_text.text = Mp.ToString();
            scr_text.text = score.ToString();
            lvl_text.text = lvl.ToString();
            lvlUp_text.text = lvlUpPrice.ToString();
            atk_text.text = Atk.ToString();
            wit_text.text = Wit.ToString();
            mgc_text.text = Mgc.ToString();
            spd_text.text = Spd.ToString();
        }

        if(Input.GetButtonDown("UpgradeAtk"))
        {
            upAtk();
        }
        if(Input.GetButtonDown("UpgradeWit"))
        {
            upWit();
        }
        if(Input.GetButtonDown("UpgradeMgc"))
        {
            upMgc();
        }
        if(Input.GetButtonDown("UpgradeSpd"))
        {
            upSpd();
        }

        if(Health <= 0)
        {
            umrzyj();
        }
    }

    public void umrzyj()
    {
        if(!isPlayer)
        {
            Instantiate(deathObject, transform.position, Quaternion.identity);
            GameObject.FindWithTag("Player").GetComponent<Stats>().score += (Atk + Mgc + Wit + Spd) / 2;
        }
        if(Random.Range(0,100) <= drapchance*100 && !isPlayer)
        {
            Instantiate(drops[Random.Range(0, drops.Count)], transform.position, Quaternion.identity);
        }
        
        if(isPlayer)
        {
            movement.enabled = false;
            attack.enabled = false;
            deathScreen.SetActive(true);
            if(score > highScore)
                PlayerPrefs.SetInt("Highscore",score);
            score_text.text = "Your score: " + score.ToString();
            highScore_text.text = "Highest score: " + highScore.ToString();
            this.enabled = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
