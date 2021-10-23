using UnityEngine;


public class LevelLoader : MonoBehaviour
{
    public Texture2D levelMap;
    public LevelPiece[] pieces;

    private void Start()
    {
        LoadLevelRoutine();        
    }

    public void LoadLevelRoutine()
    {
       
        Vector2 mapSize = new Vector2(levelMap.width, levelMap.height);
        
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                Color col = levelMap.GetPixel(x, y);
                foreach (LevelPiece piece in pieces)
                {
                    if (col == piece.color)
                    {
                        Instantiate(piece.prefab, transform.position + Vector3.right * x + Vector3.up * y, Quaternion.identity);
                    }
                }
            }
        }
    }
}
