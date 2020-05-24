using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower tower;
    // [SerializeField] GameObject towerHolder;

    int numTowers = 0;

    public void AddTower(Waypoint baseWaypoint)
    {
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower();
        }
    }

    private static void MoveExistingTower()
    {
        print("Can't place new tower, tower limit is reached.");
        //todo actually moving
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        tower.transform.position = new Vector3(baseWaypoint.transform.position.x, baseWaypoint.transform.position.y - 2.5f, baseWaypoint.transform.position.z);

        var towerClone = Instantiate(tower, tower.transform.position, transform.rotation);
        // towerClone.transform.parent = towerHolder.transform;
        baseWaypoint.isPlaceable = false;

        numTowers++;
    }
}
