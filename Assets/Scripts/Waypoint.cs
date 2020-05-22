using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // public ok here as is a data class
    public bool isExplored;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

    [SerializeField] Tower tower;
    // [SerializeField] GameObject towerHolder;

    Vector2Int gridPos;
    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize)
        );
    }

    // public void SetTopColor(Color color)
    // {
    //     MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
    //     topMeshRenderer.material.color = color;
    // }

    private void OnMouseOver()
    {
        tower.transform.position = new Vector3(transform.position.x, transform.position.y - 2.5f, transform.position.z);

        if (Input.GetMouseButtonDown(0)) // left click
        {
            if (isPlaceable)
            {
                print(gameObject.name + " tower placement");
                var towerClone = Instantiate(tower, tower.transform.position, transform.rotation);
                
                // towerClone.transform.parent = towerHolder.transform;
                isPlaceable = false;
            }
            else
            {
                print("Can't place here");
            }
        }
    }
}
