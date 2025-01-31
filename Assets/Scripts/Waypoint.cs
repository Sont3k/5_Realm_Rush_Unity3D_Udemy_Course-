﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // public ok here as is a data class
    public bool isExplored;
    public Waypoint exploredFrom;
    public bool isPlaceable = true;

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
        if (Input.GetMouseButtonDown(0)) // left click
        {
            if (isPlaceable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            else
            {
                print("Can't place here");
            }
        }
    }
}
