using System.Collections;
using System.Collections.Generic;
// Modify TileInfoScript.cs
using UnityEngine;

public class TileInfoScript : MonoBehaviour
{
    public Vector2Int gridPosition;
    public string terrainType;
    public bool isObstacleOccupied = false;

    void Start()
    {
        CalculateGridPosition();
        SetTerrainType("Grass");
    }

    void CalculateGridPosition()
    {
        // Assuming a basic isometric grid where each cube is positioned at (x, 0, z) with isometric calculations
        float isoX = transform.position.x;
        float isoZ = transform.position.z;

        // Convert isometric position to grid position
        gridPosition.x = Mathf.RoundToInt(isoX / 1.41f); // Adjust with your specific isometric transformation
        gridPosition.y = Mathf.RoundToInt(isoZ / 1.41f);
    }

    public void SetTerrainType(string newTerrainType)
    {
        terrainType = newTerrainType;
    }

    void OnMouseDown()
    {
        // Toggle obstacle on click for testing purposes
        isObstacleOccupied = !isObstacleOccupied;
        GetComponent<Renderer>().material.color = isObstacleOccupied ? Color.red : Color.white;
    }
}
