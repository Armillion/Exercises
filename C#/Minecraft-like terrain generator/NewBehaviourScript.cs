using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript
{
    static int offset = 0;
    static int caveOffset = 1;
    static int maxHeight = 96;
    static int moistureOffset = 0;
    static int temperatureOffset = 0;

    public static float GenerateHeight(float x, float z,float increment = 0.02f)
    {
        float height = PerlinNiose(x * increment + offset, z * increment + offset);
        height = Map(1, maxHeight, 0, 1, height);
        return height;
    }

    public static float GenerateMoisture(float x,float z,float increment = 0.05f)
    {
        return PerlinNiose(x * increment + moistureOffset, z * increment + moistureOffset);
    }

    public static float GenerateTemperature(float x, float z, float increment = 0.05f)
    {
        return PerlinNiose(x * increment + temperatureOffset, z * increment + temperatureOffset);
    }

    static float PerlinNiose(float x, float z)
    {
        float height = Mathf.PerlinNoise(x, z);
        return height;
    }

    public static float CalculateCaveProbability(float x, float y, float z, float increment = 0.08f)
    {
        x = x * increment + caveOffset;
        y = y * increment + caveOffset;
        z = z * increment + caveOffset;
        return PerlinNoise3D(x, y, z);
    }

    static float PerlinNoise3D(float x, float y, float z)
    {
        float XY = PerlinNiose(x, y);
        float YZ = PerlinNiose(y, z);
        float XZ = PerlinNiose(x, z);

        float YX = PerlinNiose(y,x);
        float ZY = PerlinNiose(z,y);
        float ZX = PerlinNiose(z,x);

        return (XY + YZ + XZ + YX + ZY + ZX) / 6.0f;
    }

    static float Map(float from,float to,float from2,float to2,float value)
    {
        if(value <= from2)
        {
            return from;
        }

        if(value >= to2)
        {
            return to;
        }

        return (to - from) * ((value - from2) / (to2 - from2)) + from;
    }

    public static int generateRandomOffset()
    {
        offset = Random.Range(0, 1000);
        caveOffset = Random.Range(0, 1000);
        moistureOffset = Random.Range(0, 1000);
        temperatureOffset = Random.Range(0, 1000);
        return offset;
    }
     
}
