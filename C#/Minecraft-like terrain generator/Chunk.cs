using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk
{
    Material blockMaterial;
    public Block[,,] chunkBlocks;
    public GameObject chunkObject;

    public enum chunkStatus {GENERATED,DRAW,TO_DRAW};
    public chunkStatus status;
    public Chunk(string name,Vector3 position , Material material)
    {
        this.chunkObject = new GameObject(name);
        this.chunkObject.transform.position = position;
        this.blockMaterial = material;
        this.status = chunkStatus.GENERATED;
        GenerateChunk(16);
    }

    void GenerateChunk(int chunkSize)
    {
        chunkBlocks = new Block[chunkSize, chunkSize, chunkSize];
        biome biome = biomeUtils.selectBiome(this.chunkObject.transform.position); 

        for (int i = 0; i < chunkSize; i++)
        {
            for (int j = 0; j < chunkSize; j++)
            {
                for (int k = 0; k < chunkSize; k++)
                {
                    float worldX = k + chunkObject.transform.position.x;
                    float worldY = j + chunkObject.transform.position.y;
                    float worldZ = i + chunkObject.transform.position.z;

                    BlockType biomeBlock = biome.GenerateTerrain(worldX,worldY,worldZ);
                    chunkBlocks[k, j, i] = new Block(biomeBlock, this, new Vector3(k, j, i));

                    if(biomeBlock == world.blockTypes[BlockType.Types.AIR])
                    {
                        this.status = chunkStatus.TO_DRAW;
                    }
                }
            }
        }

        if(this.status == chunkStatus.TO_DRAW)
        {
            string chunkName = (int)this.chunkObject.transform.position.x + "_"
                + (int)this.chunkObject.transform.position.y + "_" + (int)this.chunkObject.transform.position.z;

            Chunk chunkBelow;

            if(world.chunks.TryGetValue(chunkName,out chunkBelow))
            {
                chunkBelow.status = chunkStatus.TO_DRAW;
            }
        }
    }

    public void RefreshChunk(string chunkName,Vector3 chunkPosition)
    {
        this.chunkObject = new GameObject(chunkName);
        this.chunkObject.transform.position = chunkPosition;

        foreach(Block block in chunkBlocks)
        {
            if(block.GetBlockType() == world.blockTypes[0])
            {
                this.status = chunkStatus.TO_DRAW;

                string name = (int)this.chunkObject.transform.position.x + "_"
                + (int)this.chunkObject.transform.position.y + "_" + (int)this.chunkObject.transform.position.z;

                Chunk chunkBelow;

                if (world.chunks.TryGetValue(name, out chunkBelow))
                {
                    chunkBelow.status = chunkStatus.TO_DRAW;
                }

                break;
            }
        }
    }

    public void DrawChunk(int chunkSize)
    {
        for (int i = 0; i < chunkSize; i++)
        {
            for (int j = 0; j < chunkSize; j++)
            {
                for (int k = 0; k < chunkSize; k++)
                {
                    chunkBlocks[k, j, i].CreateBlock();
                }
            }
        }
        CombineSides();

        this.status = chunkStatus.DRAW;
    }

    void CombineSides()
    {
        MeshFilter[] meshFilters = chunkObject.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combineSides = new CombineInstance[meshFilters.Length];
        int index = 0;
        foreach (MeshFilter meshFilter in meshFilters)
        {
            combineSides[index].mesh = meshFilter.sharedMesh;
            combineSides[index].transform = meshFilter.transform.localToWorldMatrix;
            index++;
        }

        MeshFilter blockMeshFliter = chunkObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
        blockMeshFliter.mesh = new Mesh();
        blockMeshFliter.mesh.CombineMeshes(combineSides);

        MeshRenderer renderer = chunkObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        renderer.material = blockMaterial;

        chunkObject.AddComponent(typeof(MeshCollider));

        foreach (Transform side in chunkObject.transform)
        {
            GameObject.Destroy(side.gameObject);
        }
    }
}


