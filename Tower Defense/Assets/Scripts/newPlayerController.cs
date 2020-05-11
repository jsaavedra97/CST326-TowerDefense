using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class newPlayerController : MonoBehaviour
{
	public float rayLength;
	public LayerMask layermask;

	public Purse purse;
	public Transform turret;

	void Start()
	{
		purse.purseAmount.text = (0).ToString();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, rayLength, layermask))
			{
				if (hit.transform.tag == "Enemy")
				{
					Debug.Log("I Hit an Enemy!");
					hit.transform.SendMessage("takeDamage", purse);
				}
				//Debug.Log(hit.transform.tag);

				if(hit.transform.tag == "Defender")
                {
					Debug.Log(purse.getPurseAmount());

                    if(purse.getPurseAmount() > 0)
					{
						// Replaces Defender with Turrets
						Vector3 tempPosition = hit.transform.position;
						Quaternion tempRotation = hit.transform.rotation;

						Destroy(hit.transform.gameObject);
						Instantiate(turret, tempPosition, tempRotation);

						purse.decreaseAmount();
					}

					else
					{
						Debug.Log("Too Expensive Buddy...");
					}
				}

			}
		}
	}
}
