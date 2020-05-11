using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
	public GameObject buttonShow;

    public float towerHealth = 4;
	private float health;

	//Health Bar Stuff
	[Header("Unity Stuff")]
	public Image healthbar;

    void Start()
	{
		health = towerHealth;
	}


	void OnCollisionEnter(Collision collision)
	{
        if(collision.gameObject.tag == "Enemy")
		{
            Debug.Log("Ouch");
			Destroy(collision.gameObject);
            health--;

			healthbar.fillAmount = health / towerHealth;


			if (health == 0)
			{
				buttonShow.SetActive(true);
				Destroy(gameObject);
			}
		}
	}
}
