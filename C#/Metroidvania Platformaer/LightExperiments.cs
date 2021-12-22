using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Experimental.Rendering.Universal;

public class LightExperiments : MonoBehaviour
{
    public GameObject shadowCasterPrefab;

    public void Start()
    {
        var tilemap = GetComponent<Tilemap>();
        int i = 0;
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.GetTile(position) == null)
                continue;

            GameObject shadowCaster = GameObject.Instantiate(shadowCasterPrefab, transform);
            shadowCaster.transform.position = new Vector3Int(position.x + 1, position.y + 1, 0);
            shadowCaster.name = "Shadow Caster " + i;
            i++;
        }
    }
}
