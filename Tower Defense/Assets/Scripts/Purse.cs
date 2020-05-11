using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Purse : MonoBehaviour
{

	public Text purseAmount;
	static public float amount = 10;

	void Start()
	{
		purseAmount.text = amount.ToString();
	}

    void Update()
	{
		purseAmount.text = amount.ToString();
	}

	public void increasePurse(int coins)
	{
        amount += coins;
        purseAmount.text = amount.ToString();
	}

    public void decreaseAmount()
	{
		amount -= 10;
	}

    public float getPurseAmount()
	{
		return amount;
	}
}
