﻿/* BGSCroller.cs used to scroll the background to enhance the flight illusion. */
using UnityEngine;

public class BGScroller : MonoBehaviour {

     public float scrollSpeed;
     public float tileSizeZ;

     private Vector3 startPosition;

     private void Start() {
          startPosition = transform.position;
     }

     void Update () {
          float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
          transform.position = startPosition + Vector3.forward * newPosition;
     }
}
