/* GameController.cs is used to control game actions such as spawning waves of enemies,
 * level control, scoring, and scene transition fading. */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

     private bool gameOver;
     private bool restart;
     private float fadeTime;
     private bool allSpawnsCompleted;

     public GameObject[] hazards;
     public GameObject[] bosses;
     public GUIText gameOverText;
     public GUIText restartText;
     public GUIText scoreText;
     public GUIText missionText;
     public GUIText message;
     public Vector3 spawnValues;
     public int hazardCount;
     public int bossCount;
     public int waveCount;
     public float spawnWait;
     public float startWait;
     public float waveWait;

     private void Start() {

          gameOver = false;
          gameOverText.text = ""; 
          restart = false;
          restartText.text = "";
          allSpawnsCompleted = false;
          UpdateScore();
          GameState.bossesDestroyed = 0;
          GameState.bossesNotDestroyed = 0;
          GameState.playerDestroyed = 0;
          StartCoroutine (SpawnWaves());
     }


     private void Update() {

          if (restart) {
               if (Input.GetKeyDown(KeyCode.R)) {
                    ResetState(true);
                    StartCoroutine(LoadLevelZero());
               }
          }

          if (GameState.bossesDestroyed >= bossCount) {
               Scene scene = SceneManager.GetActiveScene();
               if(scene.name != "Winner") {
                    StartCoroutine(ChangeLevel(scene));
               }

          }

          if (allSpawnsCompleted == true && GameState.bossesNotDestroyed > 0) {
               ResetState(true);
               StartCoroutine(LoadLevelZero());
          }

          if (Input.GetKeyDown(KeyCode.Escape) == true) { // WILL NOT NWORK IN EDITOR! OK in builds.
               Application.Quit();
          }

          if (Input.GetKeyDown(KeyCode.P) == true) {
               Scene scene = SceneManager.GetActiveScene();
               if (scene.name == "Winner") {
                    ResetState(false);
               }
               else {
                    ResetState(true);
               }
               StartCoroutine(LoadLevelZero());
          }

          if (Input.GetKeyDown(KeyCode.J) == true) {
               Scene scene = SceneManager.GetActiveScene();
               if (scene.name != "Winner") {
                    ResetState(false);
                    StartCoroutine(ChangeLevel(scene));
               }
               else {
                    ResetState(true);
                    StartCoroutine(LoadLevelZero());
               }
          }

          if (gameOver) {
               ResetState(true);
               StartCoroutine(LoadLevelZero());
          }

     }


     IEnumerator SpawnWaves() {
          yield return new WaitForSeconds(startWait);
          while (waveCount > 0) {
               for (int i = 0; i < hazardCount; i++) {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
               }

               waveCount--;
               yield return new WaitForSeconds(waveWait);

               if (waveCount < 1 && GameState.bossesDestroyed < bossCount && GameState.playerDestroyed == 0) {
                    for (int i = 0; i < bossCount; i++) {
                         GameObject boss = bosses[Random.Range(0, bosses.Length)];
                         Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                         Quaternion spawnRotation = Quaternion.identity;
                         Instantiate(boss, spawnPosition, spawnRotation);
                         yield return new WaitForSeconds(spawnWait);
                    }
               }

               if (gameOver) {
                    restartText.text = "Press 'R' for Restart";
                    restart = true;
                    ResetState(true);
                    break;
               }
          }

          allSpawnsCompleted = true;
     }


     IEnumerator ChangeLevel(Scene scene) {
          fadeTime = GameObject.Find("_GM").GetComponent<Fader>().BeginFade(1);
          ResetState(false);
          yield return new WaitForSeconds(fadeTime);
          SceneManager.LoadScene(scene.buildIndex + 1);
     }


     IEnumerator LoadLevelZero() {
          fadeTime = GameObject.Find("_GM").GetComponent<Fader>().BeginFade(1);
          yield return new WaitForSeconds(fadeTime);
          SceneManager.LoadScene(0);
     }


     public void AddScore(int newScoreValue) {
          GameState.score += newScoreValue;
          UpdateScore();
          if (newScoreValue > 49) {
               GameState.bossesDestroyed++;
               GameState.bossesDestroyedDB++;
          }
     }


      void UpdateScore() {
          scoreText.text = "Score: " + GameState.score;
 //       failedToDestroy.text = "BD: " + GameState.bossesDestroyed + " BD_db: " + GameState.bossesDestroyedDB + 
 //                              " BND: " + GameState.bossesNotDestroyed + " BND_db: " + GameState.bossesNotDestroyedDB +
 //                              " PD: " + GameState.playerDestroyed + " PD_db: " + GameState.playerDestroyedDB;
      }


    void ResetState(bool alsoResetScore) {
          GameState.bossesNotDestroyed = 0;
          GameState.bossesDestroyed = 0;
          GameState.playerDestroyed = 0;
          if (alsoResetScore) {
               GameState.score = 0;
          }
     }


     public void GameOver() {
          gameOverText.text = "Game Over!";
          gameOver = true;
          restart = true;
     }

}

/* CITATIONS:
[1] http://answers.unity3d.com/questions/1113318/applicationloadlevelapplicationloadedlevel-obsolet.html
[2] http://answers.unity3d.com/questions/698531/how-to-make-esc-button-quit.html
[3] https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.GetSceneAt.html
*/
