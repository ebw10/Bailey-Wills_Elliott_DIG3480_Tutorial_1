using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {

    public float speed = 2.5f;
    public float moveLength = 5.0f;
	
	void Update () {
        transform.position = new Vector3(35.3f, 0, Mathf.PingPong(Time.time * speed, moveLength));
	}
}
