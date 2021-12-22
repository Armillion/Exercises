using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class world : MonoBehaviour
{
    public Texture2D[] atlasTekstur;
    public static Dictionary<string, Rect> atlasDictionary = new Dictionary<string, Rect>();
    public static Dictionary<string, Chunk> chunks = new Dictionary<string, Chunk>();
    Material blockMaterial;
    public int columnHeight = 16;
    public int chunkSize = 16;
    public int worldRadius = 2;
    int offset = 0;

    GameObject Player;
    Vector2 lasiPlayerPosition;
    Vector2 currentPlayerPosition;

    public static Dictionary<BlockType.Types,BlockType> blockTypes = new Dictionary<BlockType.Types, BlockType>();

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.SetActive(false);
        UpdatePlayerPosition();
    }


    // Start is called before the first frame update
    void Start()
    {
        Texture2D atlas = GetTextureAtlas();
        Material material = new Material(Shader.Find("Standard"));
        material.mainTexture = atlas;
        blockMaterial = material;
        offset = NewBehaviourScript.generateRandomOffset();
        GenerateBlockTypes();
        GenerateWorld();
        StartCoroutine(BuildChunksColumn(true));
    }

    private void Update()
    {
        UpdatePlayerPosition();
        if(currentPlayerPosition != lasiPlayerPosition)
        {
            lasiPlayerPosition = currentPlayerPosition;
            GenerateWorld();
        }
    }

    private void FixedUpdate()
    {
        if (currentPlayerPosition != lasiPlayerPosition)
        {
            StartCoroutine(BuildChunksColumn(false));
        }
    }

    IEnumerator BuildChunksColumn(bool idFirst)
    {
        foreach( Chunk chunk in chunks.Values.ToList())
        {
            if(chunk.status == Chunk.chunkStatus.TO_DRAW)
                chunk.DrawChunk(chunkSize);

            yield return null;
        }

        if (idFirst)
            Player.SetActive(true);
    }

    void GenerateWorld()
    {

        for (int z = (-worldRadius + (int)currentPlayerPosition.y - 1); z <= (worldRadius + (int)currentPlayerPosition.y + 1); z++)
        {
            for (int x = (-worldRadius + (int)currentPlayerPosition.x - 1); x <= (worldRadius + (int)currentPlayerPosition.x + 1); x++)
            {
                for (int y = 0; y < columnHeight; y++)
                {
                    Vector3 chunkPosition = new Vector3(x*chunkSize, y * chunkSize, z*chunkSize);
                    string chunkName = GenerateChunkName(chunkPosition);
                    Chunk chunk;

                    if(z == (-worldRadius + (int)currentPlayerPosition.y - 1) || z == (worldRadius + (int)currentPlayerPosition.y + 1) ||
                       x == (-worldRadius + (int)currentPlayerPosition.x - 1) || x == (worldRadius + (int)currentPlayerPosition.x + 1))
                    {
                        if(chunks.TryGetValue(chunkName,out chunk))
                        {
                            chunk.status = Chunk.chunkStatus.GENERATED;
                            Destroy(chunk.chunkObject);
                        }

                        continue;
                    }

                    if (chunks.TryGetValue(chunkName, out chunk))
                    {
                        if (chunk.status == Chunk.chunkStatus.GENERATED)
                        {
                            chunk.RefreshChunk(chunkName, chunkPosition);
                            chunk.chunkObject.transform.parent = transform;
                        }
                    }
                    else
                    {

                        chunk = new Chunk(chunkName, chunkPosition, blockMaterial);
                        chunk.chunkObject.transform.parent = this.transform;
                        chunks.Add(chunkName, chunk);
                    }
                }
            }
        }
    }

    string GenerateChunkName(Vector3 chunkPosition)
    {
        string name = (int)chunkPosition.x + "_" + (int)chunkPosition.y + "_" + (int)chunkPosition.z;
        return name;
    } 

    Texture2D GetTextureAtlas()
    {
        Texture2D textureAtlas = new Texture2D(4800, 4800);
        Rect[] coordinates = textureAtlas.PackTextures(atlasTekstur, 0, 4800, false);
        textureAtlas.Apply();

        for (int i = 0; i < coordinates.Length; i++)
        {
            atlasDictionary.Add(atlasTekstur[i].name.ToLower(), coordinates[i]);
        }

        return textureAtlas;

    }

    void GenerateBlockTypes()
    {
        BlockType air = new BlockType("air", true, true);
        air.sidesUV = SetBlockUV();
        air.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.AIR,air);

        BlockType cave = new BlockType("cave", true, true);
        air.sidesUV = SetBlockUV();
        air.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.CAVE, cave);

        BlockType dirt = new BlockType("dirt", false, true);
        dirt.sidesUV = SetBlockUV("dirt");
        dirt.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.DIRT,dirt);

        BlockType grass = new BlockType("grass", false, false);
        grass.topUV = SetBlockUV("grass");
        grass.sidesUV = SetBlockUV("grass_dirt");
        grass.bottomUV = SetBlockUV("dirt");
        grass.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.GRASS,grass);

        BlockType sand = new BlockType("sand", false, true);
        sand.sidesUV = SetBlockUV("sand");
        sand.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.SAND,sand);

        BlockType wood = new BlockType("wood", false, false);
        wood.topUV = SetBlockUV("wood_log");
        wood.sidesUV = SetBlockUV("wood");
        wood.bottomUV = SetBlockUV("wood_log_down");
        wood.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.WOOD, wood);

        BlockType stone = new BlockType("stone", false, true);
        stone.sidesUV = SetBlockUV("stone");
        stone.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.STONE, stone);

        BlockType bedrock = new BlockType("bedrock", false, true);
        bedrock.sidesUV = SetBlockUV("bedrock");
        bedrock.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.BEDROCK, bedrock);

        BlockType hard_rock = new BlockType("hard_rock", false, true);
        hard_rock.sidesUV = SetBlockUV("hard_rock");
        hard_rock.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.HARD_ROCK, hard_rock);

        BlockType redrock = new BlockType("redrock", false, true);
        redrock.sidesUV = SetBlockUV("redrock");
        redrock.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.REDROCK, redrock);

        BlockType gravel = new BlockType("gravel", false, true);
        gravel.sidesUV = SetBlockUV("gravel");
        gravel.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.GRAVEL, gravel);

        BlockType grey_brick = new BlockType("grey_brick", false, true);
        gravel.sidesUV = SetBlockUV("grey_brick");
        gravel.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.GREY_BRICK, grey_brick);

        BlockType iron_ore = new BlockType("iron_ore", false, true);
        gravel.sidesUV = SetBlockUV("iron_ore");
        gravel.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.IRON_ORE,iron_ore);

        BlockType sanctinum_ore = new BlockType("sanctinum_ore", false, true);
        gravel.sidesUV = SetBlockUV("sanctinum_ore");
        gravel.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.SANCTINUM_ORE, sanctinum_ore);

        BlockType glass = new BlockType("glass", true, true);
        glass.sidesUV = SetBlockUV("glass");
        glass.GenerateBlockUVs();
        blockTypes.Add(BlockType.Types.GLASS,glass);
    }

    Vector2[] SetBlockUV(string name = null)
    {
        if(name == null)
        {
            return new Vector2[4] {new Vector2(0f,0f),
                                   new Vector2(1f,0f),
                                   new Vector2(0f,1f),
                                   new Vector2(1f,1f),};
        }

        return new Vector2[4]
           {
                new Vector2(atlasDictionary[name].x,atlasDictionary[name].y),
                new Vector2(atlasDictionary[name].x + atlasDictionary[name].width,atlasDictionary[name].y),
                new Vector2(atlasDictionary[name].x,atlasDictionary[name].y + atlasDictionary[name].height),
                new Vector2(atlasDictionary[name].x + atlasDictionary[name].width,atlasDictionary[name].y + atlasDictionary[name].height),
           };
    }

    void UpdatePlayerPosition()
    {
        currentPlayerPosition.x = Mathf.Floor(Player.transform.position.x / 16);
        currentPlayerPosition.y = Mathf.Floor(Player.transform.position.z / 16);
    }
   
}
