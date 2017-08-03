/* BossWeaponController.cs script is the auto firing controller for Enemy Boss ships. */
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossWeaponController : MonoBehaviour {
     private AudioSource audioSource;
     private float fireRate;
     private int sceneID;

     public GameObject shot;
     public Transform shotSpawn_1;
     public Transform shotSpawn_2;
     public Transform shotSpawn_3;

     public float delay;

     void Start() {
          audioSource = GetComponent<AudioSource>();
          sceneID = SceneManager.GetActiveScene().buildIndex;
          if (sceneID == 0)
               fireRate = 1.0f;
          else if (sceneID == 1)
               fireRate = 0.75f;
          else if (sceneID == 2)
               fireRate = 0.5f;
          else if (sceneID == 3)
               fireRate = 0.4f;
          else if (sceneID == 4)
               fireRate = 0.4f;
          else if (sceneID == 5)
               fireRate = 0.4f;
          InvokeRepeating("Fire", delay, fireRate);
     }

     void Fire() {
          // Main
          if (sceneID == 0) {
               Instantiate(shot, shotSpawn_1.position, shotSpawn_1.rotation);
          }
          // Level_2
          else if (sceneID == 1) {
               Instantiate(shot, shotSpawn_1.position, shotSpawn_1.rotation);
               Instantiate(shot, shotSpawn_2.position, shotSpawn_2.rotation);
               Instantiate(shot, shotSpawn_3.position, shotSpawn_3.rotation);
          }
          // Level_3
          else if (sceneID == 2) {
               Instantiate(shot, shotSpawn_1.position, shotSpawn_1.rotation);
               Instantiate(shot, shotSpawn_2.position, shotSpawn_2.rotation);
               Instantiate(shot, shotSpawn_3.position, shotSpawn_3.rotation);
          }
          // Level_4
          else if (sceneID == 3) {
               Instantiate(shot, shotSpawn_1.position, shotSpawn_1.rotation);
               Instantiate(shot, shotSpawn_2.position, shotSpawn_2.rotation);
          }
          // Level_5
          else if (sceneID == 4) {
               Instantiate(shot, shotSpawn_1.position, shotSpawn_1.rotation);
               Instantiate(shot, shotSpawn_2.position, shotSpawn_2.rotation);
          }
          // Level_6
          else if (sceneID == 5) {
               Instantiate(shot, shotSpawn_1.position, shotSpawn_1.rotation);
               Instantiate(shot, shotSpawn_2.position, shotSpawn_2.rotation);
          }
          audioSource.Play();
     }

}
