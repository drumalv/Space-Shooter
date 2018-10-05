using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMax, xMin, zMax, zMin;
}

public class PlayerController : MonoBehaviour {
    private Rigidbody rig;
    public float speed, tilt;
    public Boundary boundary;
    
	// Use this for initialization
	void Awake () {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rig.velocity = movement*speed;
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xMax, boundary.xMin), 0f, Mathf.Clamp(rig.position.z, boundary.zMax, boundary.zMin));
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);
	}
}
