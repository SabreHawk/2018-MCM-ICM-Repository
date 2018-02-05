using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour {
	public MilepostDetector milepost_detector_model;
	List<List<MilepostDetector>> milepost_detector_list;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void init_normal_car(Transform _transform,float _velocity,int _lane){
	//	GameObject tmp_car = GameObject.Instantiate
	}

	void init_milepost_detector_5(){
		foreach (List<MilepostDetector> tmp_list in milepost_detector_list) {
			for (int i = 0; i < DataAnalzyer.Instance.mailpost_5.Count; ++i) {
				GameObject temp_milepost = GameObject.Instantiate (milepost_detector_model,new Vector2 (float(i) * RoadParams.road_width, milepost_detector_list [i]));
				temp_milepost.transform.SetParent (GameObject.Find ("Traffic_Flow"));
			}

		}
	}

}
