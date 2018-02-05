using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDetector : MonoBehaviour {

	private Rigidbody2D car_rigidbody;
	private NormalCarController car_controller;
	// Use this for initialization
	void Start () {
		car_rigidbody = this.GetComponentInParent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D _other){
		float car_dis = Vector2.Distance (_other.transform.position, _other.transform.position);
		float safe_dis = car_rigidbody.velocity.magnitude * Random.Range (CarParams.min_safe_time, CarParams.max_safe_time);
		
	}
}
