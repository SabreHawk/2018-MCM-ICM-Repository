using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCarController : MonoBehaviour {

    public Rigidbody2D car_rigidbody;


	
	// Update is called once per frame
	void Update () {
		
	}

    public void set_velocity(float _v) {
        Vector2 tmp_velocity = new Vector2(0, _v);
        car_rigidbody.velocity = tmp_velocity;
    }
}
