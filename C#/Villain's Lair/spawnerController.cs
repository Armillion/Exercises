using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerController : MonoBehaviour
{
    public List<Spawn> spawners;
    float timer = 0f;
    public bool timeToSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach( Spawn spawner in spawners )
        {
            if (!spawner.hasEnemy)
                timeToSpawn = true;
            else
            {
                timeToSpawn = false;
                break;
            }
        }
        timer += Time.deltaTime;

        if(timeToSpawn)
        {
            int numberOfEnemies = (int)timer / 10;
            if (numberOfEnemies > 3)
                numberOfEnemies = 3;

            switch(numberOfEnemies)
            {
                case 1:
                    spawners[Random.Range(0, spawners.Count/2)].canSpawn = true;
                    spawners[Random.Range(spawners.Count/2 + 1, spawners.Count)].canSpawn = true;
                    break;
                case 2:
                    spawners[Random.Range(0, spawners.Count / 2)].canSpawn = true;
                    spawners[3].canSpawn = true;
                    spawners[2].canSpawn = true;
                    break;
                case 3:
                    spawners[0].canSpawn = true;
                    spawners[1].canSpawn = true;
                    spawners[2].canSpawn = true;
                    spawners[3].canSpawn = true;
                    break;
                default:
                    spawners[Random.Range(0, spawners.Count)].canSpawn = true;
                    break;
            }
        }
    }
}
