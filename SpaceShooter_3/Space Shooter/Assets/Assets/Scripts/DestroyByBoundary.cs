/* DestroyByBoundary.cs is utilzed to remove gameObjects once "off screen". */
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

     void OnTriggerExit(Collider other) {
          if(other.tag == "Boss") {
               GameState.bossesNotDestroyed++;
               GameState.bossesNotDestroyedDB++;
          }
          Destroy(other.gameObject);
     }
}
