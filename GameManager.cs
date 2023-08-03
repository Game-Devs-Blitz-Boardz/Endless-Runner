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
    int highScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI startText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI newHighScoreText;
    bool gameStarted = false;


    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("highScore")) {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        score = 0;
        scoreText.gameObject.SetActive(false);
        startText.gameObject.SetActive(true);
        nameText.gameObject.SetActive(true);

        highScoreText.text = "highscore: " + highScore;
        highScoreText.gameObject.SetActive(true);

        if (PlayerPrefs.GetInt("highScore") == PlayerPrefs.GetInt("score")) {
            newHighScoreText.gameObject.SetActive(true);
        } else {
            newHighScoreText.gameObject.SetActive(false);
        }
    }

    void Update() {
        if (Input.anyKeyDown && !gameStarted) {
            newHighScoreText.gameObject.SetActive(false);
            startText.gameObject.SetActive(false);
            nameText.gameObject.SetActive(false);
            highScoreText.gameObject.SetActive(false);
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
        if (score > highScore) {
            PlayerPrefs.SetInt("highScore", score);
        } 
        PlayerPrefs.SetInt("score", score);
        SceneManager.LoadScene("Game");
    }

    public void ScoreUp() {
        score++;
        scoreText.text = score.ToString();
    }
}
