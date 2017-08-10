/* Mover.cs is applied to game objects in order to "move them". */
using UnityEngine;

public class Mover : MonoBehaviour {

     public float speed;

     void Start() {
          GetComponent<Rigidbody>().velocity = transform.forward * speed;
     }
}
