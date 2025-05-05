using System.Collections;
using UnityEngine;

public class SpawnManagerAI : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;

    [SerializeField]
    private GameObject [] powerUps;
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnRandomPowerUpRoutine());
    }


    public IEnumerator SpawnEnemyRoutine() 
    {
        while(true)
        {
            yield return new WaitForSeconds(3.0f);
            SpawnEnemy();
        }
    } 

    public IEnumerator SpawnRandomPowerUpRoutine() 
    {
        while(true) 
        {
            yield return new WaitForSeconds(7.0f);
            SpawnRandomPowerUp();

        }
    }
    public void SpawnEnemy()
    {
        Instantiate(enemyShipPrefab, transform.position = new Vector3(Random.Range(-8.75f, 8.75f), Random.Range(5.9f, 10.0f), 0), Quaternion.identity);
    }

    public void SpawnRandomPowerUp() 
    {
        int randomPowerUpId = Random.Range(0, 3);
        Instantiate(powerUps[randomPowerUpId], transform.position = new Vector3(Random.Range(-8.75f, 8.75f), Random.Range(7f, 11f), 0), Quaternion.identity);
    }
}