/* Mover.cs is applied to game objects in order to "move them". */
using UnityEngine;

public class Mover : MonoBehaviour {

     public float speed;
     public Rigidbody rb;

     void Start() {
          rb = GetComponent<Rigidbody>();
          rb.velocity = transform.forward * speed;
     }

}
