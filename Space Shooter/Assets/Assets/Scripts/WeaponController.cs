using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    private AudioSource audioSource;

    public GameObject shot;
    public Transform shotSpawn;
//    public Transform shotSpawn_1;
//    public Transform shotSpawn_2;
    public float fireRate;
    public float delay;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire() {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
//        Instantiate(shot, shotSpawn_1.position, shotSpawn_1.rotation);
//        Instantiate(shot, shotSpawn_2.position, shotSpawn_2.rotation);
        audioSource.Play();
    }

}
