using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private bool gameOver;
    private bool restart;

    public GameObject[] hazards;
    public GUIText gameOverText;
    public GUIText restartText;
    public GUIText scoreText;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    private void Start() {
        gameOver = false;
        gameOverText.text = ""; 
        restart = false;
        restartText.text = "";
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }

    private void Update() {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(0); //SceneManager.GetActiveScene().buildIndex);
            }
        }
        if(GameState.score >= 100) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++) {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver) {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                GameState.score = 0;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue) {
        GameState.score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = "Score: " + GameState.score;
    }

    public void GameOver() {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

}

// http://answers.unity3d.com/questions/1113318/applicationloadlevelapplicationloadedlevel-obsolet.html