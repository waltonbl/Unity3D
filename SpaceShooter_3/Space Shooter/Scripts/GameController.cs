﻿/* GameController.cs is used to control game actions such as spawning waves of enemies,
 * level control, scoring, and scene transition fading. */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

     private bool gameOver;
     private bool restart;
     private float fadeTime;

     public GameObject[] hazards;
     public GUIText gameOverText;
     public GUIText restartText;
     public GUIText scoreText;
     public GUIText missionText;
     public GUIText fuelText;
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
          GameState.fuelAmount = 50;
          UpdateFuel();
          StartCoroutine (SpawnWaves());
          StartCoroutine(DecreaseFuel());
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
                   StartCoroutine(ChangeLevel(scene));
                }
          }
          else if (GameState.score >= changeLow_L2 && GameState.score <= changeHigh_L2) {
               Scene scene = SceneManager.GetActiveScene();
               if (scene.name == "Level_2")
                    StartCoroutine(ChangeLevel(scene));
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

     IEnumerator ChangeLevel(Scene scene) {
          fadeTime = GameObject.Find("_GM").GetComponent<Fader>().BeginFade(1);
          yield return new WaitForSeconds(fadeTime);
          SceneManager.LoadScene(scene.buildIndex + 1);
     }

    IEnumerator DecreaseFuel()
    {
        yield return new WaitForSeconds(1F);
        GameState.fuelAmount--;
        UpdateFuel();
        if (GameState.fuelAmount <= 0)
        {
            GameOver();
        }
        StartCoroutine(DecreaseFuel());
    }

     public void AddScore(int newScoreValue) {
          GameState.score += newScoreValue;
          GameState.count++;
          UpdateScore();
     }

     public void AddFuel(int fuelValue)
     {
          GameState.fuelAmount += fuelValue;
          GameState.fuelAmount = Mathf.Clamp(GameState.fuelAmount, 0, 50);
          UpdateFuel();
     }

     void UpdateScore() {
          scoreText.text = "Score: " + GameState.score;
     }

     void UpdateFuel()
     {
          fuelText.text = "Fuel: " + GameState.fuelAmount;
     }

     public void GameOver() {
          gameOverText.text = "Game Over!";
          gameOver = true;
     }

}

// http://answers.unity3d.com/questions/1113318/applicationloadlevelapplicationloadedlevel-obsolet.html