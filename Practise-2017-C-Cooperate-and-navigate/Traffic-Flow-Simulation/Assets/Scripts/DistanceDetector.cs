using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDetector : MonoBehaviour {

	private Rigidbody2D car_rigidbody;
	private NormalCarController car_controller;
    public int detect_car_num = 0;

    private float x_offset = 0.2f;
	// Use this for initialization
	void Start () {
		car_rigidbody = this.GetComponentInParent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(detect_car_num==0) {
            this.GetComponentInParent<NormalCarController>().isSafe = true;
        } else {
            this.GetComponentInParent<NormalCarController>().isSafe = false;
        }
	}

	void OnTriggerEnter2D(Collider2D _other){
        if (_other.tag == Tag.normal_car) {
            if (Mathf.Abs(_other.GetComponentInParent<Transform>().position.x - this.GetComponentInParent<Transform>().position.x) < x_offset &&
                _other.GetComponentInParent<Transform>().position.y > this.GetComponentInParent<Transform>().position.y) {
                detect_car_num++;
            }
        }
	}

    void OnTriggerExit2D(Collider2D _other) {
        if (_other.tag == Tag.normal_car) {
            if (Mathf.Abs(_other.GetComponentInParent<Transform>().position.x - this.GetComponentInParent<Transform>().position.x) < x_offset && 
                _other.GetComponentInParent<Transform>().position.y > this.GetComponentInParent<Transform>().position.y) {
                detect_car_num--;
                this.GetComponentInParent<NormalCarController>().front_car_distance = 0f;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D _other) {
        if (_other.tag == Tag.normal_car) {
            if (Mathf.Abs(_other.GetComponentInParent<Transform>().position.x - this.GetComponentInParent<Transform>().position.x) < x_offset &&
                _other.GetComponentInParent<Transform>().position.y > this.GetComponentInParent<Transform>().position.y) {
                this.GetComponentInParent<NormalCarController>().front_car_distance =
                    _other.GetComponentInParent<Transform>().position.y - this.GetComponentInParent<Transform>().position.y;
            }
        }
    }
}
