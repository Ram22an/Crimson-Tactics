using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleData obstacleData;
    public GameObject obstaclePrefab; 

    void Start()
    {
        GenerateObstacles();
    }

    void GenerateObstacles()
    {
        if (obstacleData == null || obstaclePrefab == null)
        {
            Debug.LogError("ObstacleData or ObstaclePrefab is not assigned.");
            return;
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                int index = i * 10 + j;
                if (obstacleData.obstacles[index])
                {
                    Vector3 position = new Vector3(i, 0.5f, j); 
                    Instantiate(obstaclePrefab, position, Quaternion.identity);
                }
            }
        }
    }
}
