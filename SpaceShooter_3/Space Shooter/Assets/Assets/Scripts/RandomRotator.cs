/* RandomRotator.cs is the scrpit applied to asteroids to frandomly rotate them. */
using UnityEngine;

public class RandomRotator : MonoBehaviour {

     public float tumble;
     public Rigidbody rb;

     private void Start() {
          rb = GetComponent<Rigidbody>();
          rb.angularVelocity = Random.insideUnitSphere * tumble;
     }
}
