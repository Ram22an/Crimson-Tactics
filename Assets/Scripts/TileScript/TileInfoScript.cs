using UnityEngine;

public class TileInfo : MonoBehaviour
{
    public int x, y;
    public string additionalInfo; 

    public void SetPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2 GetPosition()
    {
        return new Vector2(x, y);
    }

    public string GetTileInfo()
    {
        return $"Tile Position: ({x}, {y})\nInfo: {additionalInfo}";
    }

}
