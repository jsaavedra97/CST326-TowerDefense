using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SmartEnemyScript : MonoBehaviour
{

    // Enemy Elements
    public bool typeA = true;
    public float speed = 1;
    public float startHealth;
    private float health;
    public float damage = 1;

    private NavMeshAgent enemy;
    public GameObject tower;
    public float distance = 4.0f;

    //Health Bar Stuff
    [Header("Unity Stuff")]
    public Image healthbar;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        tower = GameObject.FindGameObjectWithTag("Tower");

        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(tower.transform.position);
    }

    public void takeDamage(Purse purse)
    {
        Debug.Log("OUCH!");
        health -= damage;

        healthbar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Debug.Log("I'm DEAD!");
            int coins = typeA ? 10 : 20;
            purse.increasePurse(coins);
            Destroy(gameObject);
        }
    }
}
