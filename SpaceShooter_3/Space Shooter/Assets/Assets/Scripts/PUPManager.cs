using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPManager : MonoBehaviour {

     private GameController gameController;
     public GameObject explosion;
     public int scoreValue;
     public int timeIncrement;


     private void Start() {
          GameObject gameControllerObject = GameObject.FindWithTag("GameController");
          if (gameControllerObject != null) {
               gameController = gameControllerObject.GetComponent<GameController>();
          }
          if (gameController == null) {
               Debug.Log("Cannot find 'GameController' script.");
          }

     }

     void OnTriggerEnter(Collider other) {
          if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Boss")
              || other.CompareTag("Boss_1") || other.CompareTag("Boss_2") || other.CompareTag("Boss_3")
              || other.CompareTag("ShieldPUP") || other.CompareTag("PlayerBolt") ) {
               return;
          }


          if (explosion != null) {
               Instantiate(explosion, transform.position, transform.rotation);
          }

          if (other.CompareTag("Player")) {
               GameState.timeToShieldDown += timeIncrement;
          }

          gameController.AddScore(scoreValue);
     }


}
