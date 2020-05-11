using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public Transform enemy;
    public Transform spawnPoint;

    public float waveDelay = 5f;
    private float countdown = 2f;

    private int waveNumber = 0;

    void Start()
	{
        SpawnEnemy();
    }

    void Update()
    {
        if (countdown <= 0f)
		{
            //SpawnEnemy();
			//StartCoroutine(SpawnWave());
			countdown = waveDelay;
		}

        countdown -= Time.deltaTime;
	}
    
    IEnumerator SpawnWave()
	{
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
		{
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
		}
	}

    void SpawnEnemy()
	{
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}
}
