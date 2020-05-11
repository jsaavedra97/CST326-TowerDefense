using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public Waypoint currentDestination;
    public WaypointManager waypointManager;
    private int currentIndexWaypoint = 0;

    // Enemy Elements
    public bool typeA = true;
    public float speed = 1;
    public float health;
    public float damage = 1;

    public void Initialize(WaypointManager waypointManager)
    {
        this.waypointManager = waypointManager;
        GetNextWaypoint();
        transform.position = currentDestination.transform.position; // Move to WP0
        GetNextWaypoint();
    }

    void Update()
    {
        Vector3 direction = currentDestination.transform.position - transform.position;
        if (direction.magnitude < .2f)
        {
            GetNextWaypoint();
        }

        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    private void GetNextWaypoint()
    {
        currentDestination = waypointManager.GetNeWaypoint(currentIndexWaypoint);
        currentIndexWaypoint++;
    }

    public void takeDamage(Purse purse)
	{
        Debug.Log("I was hit by a Ray");
        health -= damage;
		if (health <= 0)
		{
            Debug.Log("I'm DEAD!");
			int coins = typeA ? 10 : 20;
			purse.increasePurse(coins);
			Destroy(gameObject);
		}
	}
}
