using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class biome 
{
   public virtual float typeIncrement { get { return 0.08f; } }
    public virtual float layerIncrement { get  { return 0.02f; } }

    protected float typeProbability;
    protected float oreProbability;
    protected int generatedY;

    public virtual BlockType GenerateTerrain(float x,float y,float z)
    {
        GenerateTerrainVaules(x, y, z);

        if(y == generatedY)
        {
            return GenerateSurface();
        }

        if(y > generatedY - 6 && y < generatedY)
        {
            return GenerateFirstLayer();
        }

        if(typeProbability < 0.3f && y < generatedY - 6 && y != 0)
        {
            return GenerateCave();
        }

        if(y < generatedY - 6 && y != 0)
        {
            return GenerateSecondLayer();
        }

        if (y == 0)
            return world.blockTypes[BlockType.Types.BEDROCK];

        return world.blockTypes[BlockType.Types.AIR];
    }

    protected virtual BlockType GenerateSecondLayer()
    {
        return world.blockTypes[BlockType.Types.STONE];
    }
     
    protected virtual BlockType GenerateFirstLayer()
    {
        return world.blockTypes[BlockType.Types.DIRT];
    }

    protected virtual BlockType GenerateCave()
    {
        return world.blockTypes[BlockType.Types.CAVE];
    }

    protected virtual BlockType GenerateSurface()
    {
        return world.blockTypes[BlockType.Types.GRASS];
    }

    protected virtual void GenerateTerrainVaules(float x,float y,float z)
    {
        typeProbability = NewBehaviourScript.CalculateCaveProbability(x, y, z,typeIncrement);
        oreProbability = NewBehaviourScript.CalculateCaveProbability(x, y, z, 0.5f);
        generatedY = (int)NewBehaviourScript.GenerateHeight(x, z,layerIncrement);
    }
}
