using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.transform.tag == Tag.normal_car) {
            Destroy(collision.gameObject);
        }

    }
}
