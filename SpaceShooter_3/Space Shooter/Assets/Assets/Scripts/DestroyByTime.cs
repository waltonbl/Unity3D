/* DestroybyTime.cs is used by the various explosion objects to ensure their removal. */
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

     public float lifetime;
 
	void Start () {
          Destroy(gameObject, lifetime);
	}
}
