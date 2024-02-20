using System.Collections;
using System.Collections.Generic;
// TileHighlighter.cs
using UnityEngine;
using TMPro;

public class TileHighlighter : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    void Update()
    {
        // Perform ray cast when the mouse is over the game window
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit object has the TileInfoScript attached
            TileInfoScript tileInfo = hit.collider.GetComponent<TileInfoScript>();

            if (tileInfo != null)
            {
                // Display the grid position in the console
                Debug.Log(tileInfo.name);
                displayText.text = "Tile Name:" + tileInfo.name + "\nGrid Position: (" + tileInfo.gridPosition.x + ", " + tileInfo.gridPosition.y + ")";

            }
            else
            {
                // Clear the console if not hovering over a tile with TileInfoScript
                Debug.Log("No Tile Info");
            }
        }
    }
}