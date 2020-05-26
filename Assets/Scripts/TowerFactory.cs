using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower tower;
    [SerializeField] Transform towerParent;

    Queue<Tower> towers = new Queue<Tower>();

    int numTowers = 0;

    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towers.Count;

        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        tower.transform.position = new Vector3(baseWaypoint.transform.position.x, baseWaypoint.transform.position.y - 2.5f, baseWaypoint.transform.position.z);
        var newTower = Instantiate(tower, tower.transform.position, transform.rotation);
        baseWaypoint.isPlaceable = false;

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        // Add to tower holder object
        newTower.transform.parent = towerParent;

        towers.Enqueue(newTower);
    }

    private void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towers.Dequeue();
        
        oldTower.baseWaypoint.isPlaceable = true; // free-up the block
        newBaseWaypoint.isPlaceable = false;
        
        oldTower.baseWaypoint = newBaseWaypoint;
        oldTower.transform.position = newBaseWaypoint.transform.position;

        towers.Enqueue(oldTower);
    }
}
