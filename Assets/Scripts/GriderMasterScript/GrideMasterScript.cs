using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject cubePrefab;
    private int gridSize = 10;

    void Start()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 position = new Vector3(x, 0, y);
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
                TileInfo tileInfo = cube.GetComponent<TileInfo>();
                tileInfo.SetPosition(x, y);
                tileInfo.additionalInfo = $"We are touching the tiles";
            }
        }
    }
}
