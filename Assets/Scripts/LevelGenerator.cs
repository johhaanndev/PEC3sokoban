
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public Transform initialPos;

    // creating the array with ColorToPrefab elements
    public ColorToPrefab[] colorMappings;

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        // iterate over all the pixels in map PNG
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                // generate Tile
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);
        
        if (pixelColor.a == 0)
        {
            // if pixel is transparent, we ignore it
            return;
        }
        
        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector2 position = new Vector2(x + initialPos.position.x, y + initialPos.position.y);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }
    }
}