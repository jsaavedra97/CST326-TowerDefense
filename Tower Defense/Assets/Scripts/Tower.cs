using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float towerHealth = 4;

	void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.tag == "Enemy")
		{
            Debug.Log("Ouch");
			Destroy(collision.gameObject);
            towerHealth--;

			if (towerHealth == 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
