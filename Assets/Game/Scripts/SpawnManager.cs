using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;

    [SerializeField]
    private GameObject [] powerUps;

    private GameManager _gameManager;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void StartSpawnCoroutines(){
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnRandomPowerUpRoutine());
    }

    public IEnumerator SpawnEnemyRoutine() 
    {
        while(_gameManager.isGameRunning == true)
        {
            yield return new WaitForSeconds(3.0f);
            SpawnEnemy();
        }
    } 

    public IEnumerator SpawnRandomPowerUpRoutine() 
    {
        while(_gameManager.isGameRunning == true) 
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