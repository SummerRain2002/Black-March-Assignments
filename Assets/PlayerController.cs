using System.Collections;
using System.Collections.Generic;
// PlayerController.cs
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool isMoving = false;
    private Vector3 targetPosition;
    private TileInfoScript targetTile;

    void Update()
    {
        if (!isMoving && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                TileInfoScript clickedTile = hit.collider.GetComponent<TileInfoScript>();

                if (clickedTile != null && !clickedTile.isObstacleOccupied)
                {
                    StartCoroutine(MoveToTile(clickedTile));
                }
            }
        }
    }

    IEnumerator MoveToTile(TileInfoScript tile)
    {
        isMoving = true;

        // Calculate the target position based on the clicked tile's isometric coordinates
        targetPosition = new Vector3(tile.transform.position.x, 3.4f, tile.transform.position.z);
        targetTile = tile;

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);
            yield return null;
        }

        // Ensure the player lands exactly on the target position
        transform.position = targetPosition;

        isMoving = false;
    }
}

