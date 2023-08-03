using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float maxSpawnPointX = 1.5f;
    public float spawnRate = 0.8f;
    int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI startText;
    bool gameStarted = false;


    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        score = 0;
        scoreText.gameObject.SetActive(false);
        startText.gameObject.SetActive(true);
    }

    void Update() {
        if (Input.anyKeyDown && !gameStarted) {
            startText.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(true);
            gameStarted = true;
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies() {
        while (true) {
            Spawn();

            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void Spawn() {

        float randomSpawnX = Random.Range(-maxSpawnPointX, maxSpawnPointX);

        Vector3 enemySpawnPos = spawnPoint.position;
        enemySpawnPos.x = randomSpawnX;

        Instantiate(enemyPrefab, enemySpawnPos, Quaternion.identity);
    }
    
    public void ReloadScene() {
        SceneManager.LoadScene("Game");
    }

    public void ScoreUp() {
        score++;
        scoreText.text = score.ToString();
    }
}
