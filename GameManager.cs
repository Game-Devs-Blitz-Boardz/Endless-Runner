using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float maxSpaqwnPointX = 1.5f;
    public float spawnRate = 0.8f;


    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        while (true) {
            Spawn();

            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void Spawn() {

        float randomSpawnX = Random.Range(-maxSpaqwnPointX, maxSpaqwnPointX);

        Vector3 enemySpawnPos = spawnPoint.position;
        enemySpawnPos.x = randomSpawnX;

        Instantiate(enemyPrefab, enemySpawnPos, Quaternion.identity);
    }
    
    public void ReloadScene() {
        SceneManager.LoadScene("Game");
    }
}
