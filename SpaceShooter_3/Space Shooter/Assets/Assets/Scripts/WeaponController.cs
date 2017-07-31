/* WeaponController.cs script is the auto firing controller for Enemy ships. */
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponController : MonoBehaviour {

     private AudioSource audioSource;
     private float fireRate;
     private int sceneID;

     public GameObject shot;
     public Transform shotSpawn;
     public float delay;

	void Start () {
          audioSource = GetComponent<AudioSource>();
          sceneID = SceneManager.GetActiveScene().buildIndex;
          if (sceneID == 0)
               fireRate = 1.5f;
          else if (sceneID == 1)
               fireRate = 1.0f;
          else if (sceneID == 2)
               fireRate = 0.75f;
          else if (sceneID == 3)
               fireRate = 0.5f;
          else if (sceneID == 4)
               fireRate = 0.3f;
          else if (sceneID == 5)
               fireRate = 0.2f;
          InvokeRepeating("Fire", delay, fireRate);
     }

     void Fire() {
          Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
          audioSource.Play();
     }

}
