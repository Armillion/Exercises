using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spellSystem : MonoBehaviour
{
    public bool firstSpellUnlocked = false;
    public bool secondSpellUnlocked = false;
    public bool thirdSpellUnlocked = false;
    public bool fourthSpellUnlocked = false;

    public int firstSpellCost = 4;
    public int secondSpellCost = 2;
    public int thirdSpellCost = 1;
    public int forthSpellCost = 5;

    public float secondSpellTIme = 2f;
    public bool secondSpellActive = false;

    float timer = 0f;
    float effectTimer = 0f;

    Stats statystyki;
    int pomocnicza;

    public GameObject projectile;
    GameObject proj;
    playerMovement movement;

    Stats[] przeciwnicy;

    public GameObject heal_fx;
    public GameObject invin_fx;
    public GameObject death_fx;
    bool fxActive = false;

    public Image firstSpellImg;
    public Image secondSpellImg;
    public Image thirdSpellImg;
    public Image fourthSpellImg;

    SpriteRenderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        statystyki = GetComponent<Stats>();
        movement = GetComponent<playerMovement>();
        renderer = movement.render;

        firstSpellImg.enabled = false;
        secondSpellImg.enabled = false;
        thirdSpellImg.enabled = false;
        fourthSpellImg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Spell1") && firstSpellUnlocked && (statystyki.Mp >= firstSpellCost))
        {
            fxActive = true;
            heal_fx.GetComponent<SpriteRenderer>().enabled = true;
            statystyki.Health = statystyki.MaxHealth;
            statystyki.Mp -= firstSpellCost;
            if(movement.dir.x >0)
            {
                renderer.sprite = movement.attackAnims[4];
            }
            else
            {
                renderer.sprite = movement.attackAnims[5];
            }
            movement.animationTimer = 0f;
        }

        if (Input.GetButtonDown("Spell2") && secondSpellUnlocked && (statystyki.Mp >= secondSpellCost) && !secondSpellActive)
        {
            fxActive = true;
            invin_fx.GetComponent<SpriteRenderer>().enabled = true;
            secondSpellActive = true;
            pomocnicza = statystyki.Health;
            statystyki.Mp -= secondSpellCost;
            if (movement.dir.x > 0)
            {
                renderer.sprite = movement.attackAnims[4];
            }
            else
            {
                renderer.sprite = movement.attackAnims[5];
            }
            movement.animationTimer = 0f;
        }

        if (Input.GetButtonDown("Spell3") && thirdSpellUnlocked && (statystyki.Mp >= thirdSpellCost))
        {
            proj = Instantiate(projectile, transform.position, Quaternion.identity);
            proj.GetComponent<projectileScript>().targetPlayer = false;
            proj.GetComponent<projectileScript>().dir = movement.dir;
            proj.GetComponent<projectileScript>().dmg = (int)statystyki.Mgc/2;
            proj.GetComponent<projectileScript>().speed = statystyki.Mgc/3;
            statystyki.Mp -= thirdSpellCost;

            if (movement.dir.x > 0)
            {
                renderer.sprite = movement.attackAnims[4];
            }
            else
            {
                renderer.sprite = movement.attackAnims[5];
            }
            movement.animationTimer = 0f;
        }
        if (Input.GetButtonDown("Spell4") && fourthSpellUnlocked && (statystyki.Mp >= forthSpellCost))
        {
            if (movement.dir.x > 0)
            {
                renderer.sprite = movement.attackAnims[4];
            }
            else
            {
                renderer.sprite = movement.attackAnims[5];
            }
            movement.animationTimer = 0f;

            for (int i = 0; i < 5; i++)
            {
                float spawnY = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
                float spawnX = Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

                Vector2 spawnPosition = new Vector2(spawnX, spawnY);
                Instantiate(death_fx, spawnPosition, Quaternion.identity);
            }

            przeciwnicy = GameObject.FindObjectsOfType<Stats>();
            foreach(Stats obiekt in przeciwnicy)
            {
                if(obiekt.isPlayer == false && Random.Range(0,2) == 0)
                {
                    obiekt.umrzyj();
                }
            }
            statystyki.Mp -= forthSpellCost;
        }

        if (secondSpellActive)
        {
            timer += Time.deltaTime;
            statystyki.Health = pomocnicza;
            if(timer >= secondSpellTIme)
            {
                secondSpellActive = false;
            }
        }

        if(fxActive)
        {
            effectTimer += Time.deltaTime;
            if(effectTimer >= secondSpellTIme)
            {
                invin_fx.GetComponent<SpriteRenderer>().enabled = false;
                heal_fx.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        firstSpellImg.enabled = firstSpellUnlocked;
        secondSpellImg.enabled = secondSpellUnlocked;
        thirdSpellImg.enabled = thirdSpellUnlocked;
        fourthSpellImg.enabled = fourthSpellUnlocked;
    }

       
}
