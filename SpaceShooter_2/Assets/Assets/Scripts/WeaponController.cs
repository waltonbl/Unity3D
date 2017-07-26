/* WeaponController.cd script is the auto firing controller for Enemy ships/ */
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponController : MonoBehaviour {

     private AudioSource audioSource;
     private int sceneID;
     public GameObject shot;
     public Transform shotSpawn;
     private float fireRate;
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
          InvokeRepeating("Fire", delay, fireRate);
     }

     void Fire() {
          Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
          audioSource.Play();
     }
}
