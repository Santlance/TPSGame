using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainAddHeight : MonoBehaviour
{
    public Terrain terrain;
    public float addHeight;
    // Start is called before the first frame update
    void Start()
    {
        int width = terrain.terrainData.heightmapResolution;
        float[,] heights = terrain.terrainData.GetHeights(0, 0, width, width);
        for(int i = 0; i < width; i++)
        {
            for (int j = 0; j < width; j++)
                heights[i, j] += addHeight;
        }
        terrain.terrainData.SetHeights(0, 0, heights);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
