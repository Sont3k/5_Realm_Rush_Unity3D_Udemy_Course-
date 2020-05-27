using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticle;

    // Start is called before the first frame update
    private void Start()
    {
        // StartCoroutine(FollowPath());
        // print("Hi, human");
        // to here

        Pathfinder pathFinder = FindObjectOfType<Pathfinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    private IEnumerator FollowPath(IEnumerable<Waypoint> path)
    {
        print("Starting patrol...");

        foreach(Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.GetChild(0).position;
            yield return new WaitForSeconds(movementPeriod);
        }

        SelfDestruct();

        print("Ending patrol");
    }

    void SelfDestruct()
    {
        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
        Destroy(vfx.gameObject, vfx.main.duration);
    }
}
