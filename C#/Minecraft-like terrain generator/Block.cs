using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{
    public enum BlockSide { FRONT, BACK, RIGHT, LEFT, TOP, BOTTOM };
    BlockType blockType;
    bool isTransparent;
    Chunk chunkParent;
    Vector3 blockPosition;

    static Vector3[] verticles = new Vector3[8] {new Vector3(-0.5f, -0.5f, 0.5f),
                                                 new Vector3( 0.5f, -0.5f, 0.5f),
                                                 new Vector3( 0.5f, -0.5f,-0.5f),
                                                 new Vector3(-0.5f, -0.5f,-0.5f),
                                                 new Vector3(-0.5f,  0.5f, 0.5f),
                                                 new Vector3( 0.5f,  0.5f, 0.5f),
                                                 new Vector3( 0.5f,  0.5f,-0.5f),
                                                 new Vector3(-0.5f,  0.5f,-0.5f),};

    static Vector3[] frontVertex = new Vector3[4] { verticles[4], verticles[5], verticles[1], verticles[0] };
    static Vector3[] backVertex = new Vector3[4] { verticles[6], verticles[7], verticles[3], verticles[2] };
    static Vector3[] leftVertex = new Vector3[4] { verticles[7], verticles[4], verticles[0], verticles[3] };
    static Vector3[] rightVertex = new Vector3[4] { verticles[5], verticles[6], verticles[2], verticles[1] };
    static Vector3[] topVertex = new Vector3[4] { verticles[7], verticles[6], verticles[5], verticles[4] };
    static Vector3[] downVertex = new Vector3[4] { verticles[0], verticles[1], verticles[2], verticles[3] };

    /*Vector2[] uv = new Vector2[4] {new Vector2(0f,0f),
                                   new Vector2(1f,0f),
                                   new Vector2(0f,1f),
                                   new Vector2(1f,1f)}; */

    static Vector3[] forwardVectors = new Vector3[4] { Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward };
    static Vector3[] backVectors = new Vector3[4] { Vector3.back, Vector3.back, Vector3.back, Vector3.back };
    static Vector3[] rightVectors = new Vector3[4] { Vector3.right, Vector3.right, Vector3.right, Vector3.right };
    static Vector3[] leftVectors = new Vector3[4] { Vector3.left, Vector3.left, Vector3.left, Vector3.left };
    static Vector3[] upVectors = new Vector3[4] { Vector3.up, Vector3.up, Vector3.up, Vector3.up };
    static Vector3[] downVectors = new Vector3[4] { Vector3.down, Vector3.down, Vector3.down, Vector3.down };
    static int[] triangles = new int[6] { 3, 1, 0, 3, 2, 1 };


    public Block(BlockType type, Chunk chunkParent, Vector3 blockPosition)
    {
        this.blockType = type;
        this.chunkParent = chunkParent;
        this.blockPosition = blockPosition;

        if (blockType.isTransparent)
            isTransparent = true;
        else
            isTransparent = false;
    }
    public void CreateBlock()
    {
        if (blockType.isTransparent)
            return;

        if (HasTransparentNeighbour(BlockSide.FRONT))
            CreateBlockSide(BlockSide.FRONT);
        if (HasTransparentNeighbour(BlockSide.BACK))
            CreateBlockSide(BlockSide.BACK);
        if (HasTransparentNeighbour(BlockSide.RIGHT))
            CreateBlockSide(BlockSide.RIGHT);
        if (HasTransparentNeighbour(BlockSide.LEFT))
            CreateBlockSide(BlockSide.LEFT);
        if (HasTransparentNeighbour(BlockSide.TOP))
            CreateBlockSide(BlockSide.TOP);
        if (HasTransparentNeighbour(BlockSide.BOTTOM))
            CreateBlockSide(BlockSide.BOTTOM);
    }

    bool HasTransparentNeighbour(BlockSide blockSide)
    {
        Block[,,] chunkBlocks = chunkParent.chunkBlocks;
        Vector3 neighbourPosition = new Vector3(0, 0, 0);

        if (blockSide == BlockSide.FRONT)
            neighbourPosition = new Vector3(blockPosition.x, blockPosition.y, blockPosition.z + 1);
        else if (blockSide == BlockSide.BACK)
            neighbourPosition = new Vector3(blockPosition.x, blockPosition.y, blockPosition.z - 1);
        else if (blockSide == BlockSide.TOP)
            neighbourPosition = new Vector3(blockPosition.x, blockPosition.y + 1, blockPosition.z);
        else if (blockSide == BlockSide.BOTTOM)
            neighbourPosition = new Vector3(blockPosition.x, blockPosition.y - 1, blockPosition.z);
        else if (blockSide == BlockSide.LEFT)
            neighbourPosition = new Vector3(blockPosition.x - 1, blockPosition.y, blockPosition.z);
        else if (blockSide == BlockSide.RIGHT)
            neighbourPosition = new Vector3(blockPosition.x + 1, blockPosition.y, blockPosition.z);

        if (neighbourPosition.x >= 0 && neighbourPosition.x < chunkBlocks.GetLength(0) &&
           neighbourPosition.y >= 0 && neighbourPosition.y < chunkBlocks.GetLength(1) &&
           neighbourPosition.z >= 0 && neighbourPosition.z < chunkBlocks.GetLength(2))
        {
            return chunkBlocks[(int)neighbourPosition.x, (int)neighbourPosition.y, (int)neighbourPosition.z].isTransparent;
        }
        return true;
    }

    void CreateBlockSide(BlockSide side)
    {
        Vector2[] uvs = blockType.getUV(side);

        Mesh mesh = new Mesh();
        mesh = GenerateBlockSide(mesh, side, uvs);

        GameObject blockSide = new GameObject("Block Side");
        blockSide.transform.position = blockPosition;
            blockSide.transform.parent = chunkParent.chunkObject.transform;

        MeshFilter meshFilter = blockSide.AddComponent(typeof(MeshFilter)) as MeshFilter;
        meshFilter.mesh = mesh;

    }

   
    //funkcja generuje mesh na podstawie danego identyfikatora sciany
    Mesh GenerateBlockSide(Mesh mesh, BlockSide side, Vector2[] uv)
    {
        switch (side)
        {
            case BlockSide.FRONT:
                mesh.vertices = frontVertex;
                mesh.normals = forwardVectors;
                mesh.uv = blockType.GetBlockUVs(side);
                mesh.triangles = triangles;
                break;
            case BlockSide.BACK:
                mesh.vertices = backVertex;
                mesh.normals = backVectors;
                mesh.uv = blockType.GetBlockUVs(side);
                mesh.triangles = triangles;
                break;
            case BlockSide.LEFT:
                mesh.vertices = leftVertex;
                mesh.normals = leftVectors;
                mesh.uv = blockType.GetBlockUVs(side);
                mesh.triangles = triangles;
                break;
            case BlockSide.RIGHT:
                mesh.vertices = rightVertex;
                mesh.normals = rightVectors;
                mesh.uv = blockType.GetBlockUVs(side);
                mesh.triangles = triangles;
                break;
            case BlockSide.TOP:
                mesh.vertices = topVertex;
                mesh.normals = upVectors;
                mesh.uv = blockType.GetBlockUVs(side);
                mesh.triangles = triangles;
                break;
            case BlockSide.BOTTOM:
                mesh.vertices = downVertex;
                mesh.normals = downVectors;
                mesh.uv = blockType.GetBlockUVs(side);
                mesh.triangles = triangles;
                break;
        }
        return mesh;
    }

    public BlockType GetBlockType()
    {
        return this.blockType;
    }
}
