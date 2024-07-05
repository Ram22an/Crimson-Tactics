using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MouseRaycast : MonoBehaviour
{
    public TextMeshProUGUI uiText; // Reference to the UI Text element
    public Camera mainCamera;

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            TileInfo tileInfo = hit.collider.GetComponent<TileInfo>();
            if (tileInfo != null)
            {
                string tileDetails = tileInfo.GetTileInfo();
                uiText.text = tileDetails;
            }
        }
        else
        {
            uiText.text = "";
        }
    }
}
