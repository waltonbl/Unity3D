/* DestroyBycontact.cs used by Asteroids, Enmey Bolts, and Enemy ships (ramming works!) to 
 * destroy the Player game Object. */
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

     public GameObject explosion;
     public GameObject playerExplosion;
     public int scoreValue;
     private GameController gameController;

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
              || other.CompareTag("Boss_1") || other.CompareTag("Boss_2") || other.CompareTag("Boss_3")) {
                    return;
          }

          if (explosion != null) {
               Instantiate(explosion, transform.position, transform.rotation);
          }

          if (other.CompareTag("Player")) {
               Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
               GameState.playerDestroyed++;
               gameController.GameOver();
          }

          gameController.AddScore(scoreValue);

          Destroy(other.gameObject);
          Destroy(gameObject);
     }
}
