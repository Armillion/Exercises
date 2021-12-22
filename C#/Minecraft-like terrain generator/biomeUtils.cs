using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class biomeUtils 
{
    public static biome selectBiome(Vector3 chunkPos)
    {
         float temperature = NewBehaviourScript.GenerateTemperature(chunkPos.x,chunkPos.z);
         float moisture = NewBehaviourScript.GenerateMoisture(chunkPos.x,chunkPos.z);
         biome biome = new plains();

        if (temperature < 0.25f)
            biome = new rocky();
        else if (moisture < 0.5f)
            biome = new desert();
        else
            biome = new plains();

        return biome;
    }
}
