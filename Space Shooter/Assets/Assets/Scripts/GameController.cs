/* GameController.cs is used to control game actions such as spawning waves of enemies,
 * level control, and scoring. */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

     private bool gameOver;
     private bool restart;

     public GameObject[] hazards;
     public GUIText gameOverText;
     public GUIText restartText;
     public GUIText scoreText;
     public GUIText missionText;
     public Vector3 spawnValues;
     public int hazardCount;
     public float spawnWait;
     public float startWait;
     public float waveWait;
     public int changeLow_L1;
     public int changeHigh_L1;
     public int changeLow_L2;
     public int changeHigh_L2;

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
                    SceneManager.LoadScene(0);
               }
          }
          if(GameState.score >= changeLow_L1 && GameState.score <= changeHigh_L1) {
               Scene scene = SceneManager.GetActiveScene();
               if (scene.name == "Main") {
                    SceneManager.LoadScene(scene.buildIndex + 1);
                }
          }
          else if (GameState.score >= changeLow_L2 && GameState.score <= changeHigh_L2) {
               Scene scene = SceneManager.GetActiveScene();
               if (scene.name == "Level_2")
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
                    GameState.count = 0;
                    break;
               }
          }
     }

     public void AddScore(int newScoreValue) {
          GameState.score += newScoreValue;
          GameState.count++;
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