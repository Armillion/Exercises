using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<GameObject> przeciwnicy = new List<GameObject>();
    float timer = 0f;
    GameObject przeciwnik;
    Stats statystyki;

    public bool hasEnemy = false;
    public bool canSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(przeciwnik == null)
        {
            hasEnemy = false;
        }

        if(canSpawn)
        {
            Spawning();
        }
    }

    void Spawning()
    {
        hasEnemy = true;
        canSpawn = false;
        przeciwnik = Instantiate(przeciwnicy[Random.Range(0, przeciwnicy.Count)], transform.position, Quaternion.identity);
        statystyki = przeciwnik.GetComponent<Stats>();
        for (int i = 0; i < (int)(timer / 10); i++)
        {
            statystyki.upAtk();
            statystyki.upMgc();
            statystyki.upSpd();
            statystyki.upWit();
        }
    }
}
