/* DestroyByBoundary.cs is utilzed to remove gameObjects once "off screen". */
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

     void OnTriggerExit(Collider other) {
          if(other.tag == "Boss" || other.tag == "Boss_1" || other.tag == "Boss_2" || other.tag == "Boss_3") {
               GameState.bossesNotDestroyed++;
          }
          Destroy(other.gameObject);
     }
}
