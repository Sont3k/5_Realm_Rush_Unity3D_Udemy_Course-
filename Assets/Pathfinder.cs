using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Waypoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true; //TODO make private

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        // ExploreNeighbours();
        Pathfind();
    }

    void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (var waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            // overlapping blocks?
            bool isOverlapping = grid.ContainsKey(gridPos);

            if (isOverlapping)
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint);
            }
            else
            {
                // add to dictionary
                grid.Add(gridPos, waypoint);
            }
        }
    }

    void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.cyan);
    }

    void ExploreNeighbours()
    {
        foreach (var direction in directions)
        {
            Vector2Int explorationCoordinates = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[explorationCoordinates].SetTopColor(Color.blue);
                print("Exploring " + explorationCoordinates);
            }
            catch (System.Exception)
            {
                // do nothing                
            }
        }
    }

    void Pathfind()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0)
        {
            var searchCenter = queue.Dequeue();
            print("Searching from: " + searchCenter); //TODO remove log
            HaltIfEndFound(searchCenter);
        }

        print("Finished pathfinding?");
    }

    void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Start and end point are the same. Pathfind algorithm is stopped."); //TODO remove log
            isRunning = false;
        }
    }
}
