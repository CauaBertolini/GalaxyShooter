using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private UIManager _uiManager;
    [SerializeField]
    private GameObject [] enemyShipPrefab;

    [SerializeField]
    private GameObject [] powerUps;

    private GameManager _gameManager;
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    public void StartSpawnCoroutines(){
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnRandomPowerUpRoutine());
    }

    public IEnumerator SpawnEnemyRoutine() 
    {
        double runtimeTimer = 0;
        double lastRuningtimeTimer = _gameManager.lastRuningTimeTimer;

        while(_gameManager.isGameRunning == true)
        {
            runtimeTimer = Time.time - lastRuningtimeTimer;
            if (runtimeTimer <= 30) {
                yield return new WaitForSeconds(3.0f);
                SpawnEnemy();
            } else if (runtimeTimer > 30 && runtimeTimer < 60) {
                yield return new WaitForSeconds(1.5f);
                SpawnEnemy();
            } else {
                yield return new WaitForSeconds(0.7f);
                SpawnEnemy();
            }
            
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
        int n = Random.Range(0, 11);

        Debug.Log(n);
        if (n <= 9) {
            n = 0;
        } else {
            n = 1;
        }

        Instantiate(enemyShipPrefab[n], transform.position = new Vector3(Random.Range(-8.75f, 8.75f), Random.Range(5.9f, 10.0f), 0), Quaternion.identity);
    }

    public void SpawnRandomPowerUp() 
    {
        int randomPowerUpId = Random.Range(0, 3);
        Instantiate(powerUps[randomPowerUpId], transform.position = new Vector3(Random.Range(-8.75f, 8.75f), Random.Range(7f, 11f), 0), Quaternion.identity);
    }
}