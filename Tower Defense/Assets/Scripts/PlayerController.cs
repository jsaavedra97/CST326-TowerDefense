using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float rayLength;
    public LayerMask layermask;

	public Purse purse;

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
				hit.transform.parent.SendMessage("takeDamage", purse);
				Debug.Log("Hit an enemy");

			}
		}
	}
}
