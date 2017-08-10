using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary_t
{
    public float xMin_t, xMax_t, zMin_t, zMax_t;
}


public class PlayerController_test : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    public Boundary_t boundary;
   // public float tilt;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //QualitySettings.vSyncCount = 0;
    }
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin_t, boundary.xMax_t),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin_t, boundary.zMax_t)
        );
        //this breaks the custom asset for some reason.
        //ship dissapears from view while messing around with it in play mode.
        //rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
