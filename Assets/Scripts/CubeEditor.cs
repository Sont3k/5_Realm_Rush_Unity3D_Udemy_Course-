using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;
    TextMesh textMesh;
    [SerializeField] float blockHeight = 0f;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
        textMesh = GetComponentInChildren<TextMesh>();
    }

    private void Update()
    {
        SnapToGrid();
        
        if (textMesh)
        {
            UpdateLabel();
        }
    }

    private void UpdateLabel()
    {
        Vector2 gridPos = waypoint.GetGridPos();


        string labelText = (gridPos.x) + "," + (gridPos.y);
        textMesh.text = labelText;
        gameObject.name = labelText;
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        Vector2 gridPos = waypoint.GetGridPos() * gridSize;

        transform.position = new Vector3(
            gridPos.x,
            blockHeight,
            gridPos.y
        );
    }
}
