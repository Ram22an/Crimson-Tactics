using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "ScriptableObjects/ObstacleData", order = 1)]
public class ObstacleData : ScriptableObject
{
    public bool[] obstacles = new bool[100]; // 10x10 grid
}
