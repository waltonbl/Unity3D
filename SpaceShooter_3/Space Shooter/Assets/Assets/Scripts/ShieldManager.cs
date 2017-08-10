using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour {

     public GameObject shield;
     public GameObject explosion;

     // Use this for initialization
     void Start () {
          shield.SetActive(false);
          GameState.timeToShieldDown = 0;
	}

     // Update is called once per frame
     void FixedUpdate () {
          if (GameState.timeToShieldDown > 0)
               shield.SetActive(true);
          else
               shield.SetActive(false);

          if(GameState.timeToShieldDown > 0)
               GameState.timeToShieldDown -= Time.deltaTime;
	}


     void OnTriggerEnter(Collider other) {
          if ( other.CompareTag("Enemy") || other.CompareTag("Boss_1") || other.CompareTag("Boss_2")
            || other.CompareTag("Boss_3") || other.CompareTag("Boss_4") || other.CompareTag("Boss_5") || other.CompareTag("Boss_6")) {
               Instantiate(explosion, other.transform.position, other.transform.rotation);
          }
     }



}

/* CITATIONS:
[1] https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html
*/
