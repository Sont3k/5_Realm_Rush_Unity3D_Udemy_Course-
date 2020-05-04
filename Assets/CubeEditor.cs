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

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    private void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        Vector2 gridPos = waypoint.GetGridPos();

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
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
            0f,
            gridPos.y
        );
    }
}
