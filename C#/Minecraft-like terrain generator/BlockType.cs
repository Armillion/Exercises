using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockType
{
    public enum Types { AIR,DIRT,GRASS,SAND,WOOD,STONE,BEDROCK,HARD_ROCK,REDROCK,GRAVEL,GREY_BRICK,IRON_ORE,SANCTINUM_ORE,GLASS,CAVE}

   public string name { get; private set; }
   public bool isTransparent { get; private set; }
   public bool everySideSame { get; private set; }

   public Vector2[] topUV { private get; set; }
   public Vector2[] sidesUV { private get; set; }
   public Vector2[] bottomUV { private get; set; }

    List<Vector2[]> blockUVs = new List<Vector2[]>();

    public BlockType(string typeName , bool isTransparent, bool everySideSame)
    {
        this.name = typeName;
        this.isTransparent = isTransparent;
        this.everySideSame = everySideSame;
    }

    public Vector2[] getUV(Block.BlockSide side)
    {
        if(everySideSame || (side != Block.BlockSide.TOP && side != Block.BlockSide.BOTTOM))
        {
            return this.sidesUV;
        }

        if(side == Block.BlockSide.TOP)
        {
            return this.topUV;
        }
        else
        {
            return this.bottomUV;
        }
    }

    public Vector2[] GetBlockUVs(Block.BlockSide side)
    {
        if (everySideSame || (side != Block.BlockSide.TOP && side != Block.BlockSide.BOTTOM))
        {
            return this.sidesUV;
        }

        if (side == Block.BlockSide.TOP)
        {
            return this.topUV;
        }
        else
        {
            return this.bottomUV;
        }
    }

    public void GenerateBlockUVs()
    {
        this.blockUVs.Add(new Vector2[] { sidesUV[3], sidesUV[2], sidesUV[0], sidesUV[1] });

        if (everySideSame)
            return;

        if(topUV.Length > 0)
        {
            this.blockUVs.Add(new Vector2[] { topUV[3], topUV[2], topUV[0], topUV[1] });
        }

        if(bottomUV.Length > 0)
        {
            this.blockUVs.Add(new Vector2[] { bottomUV[3], bottomUV[2], bottomUV[0], bottomUV[1] });
        }
    }
}
