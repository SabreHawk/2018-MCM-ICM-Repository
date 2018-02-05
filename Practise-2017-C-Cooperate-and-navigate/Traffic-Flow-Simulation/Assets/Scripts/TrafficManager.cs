using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour {
	public GameObject milepost_detector_model;
    private List<List<MilepostDetector>> milepost_detector_list_5 = new List<List<MilepostDetector>>();
    private List<List<MilepostDetector>> milepost_detector_list_90 = new List<List<MilepostDetector>>();
    private List<List<MilepostDetector>> milepost_detector_list_405 = new List<List<MilepostDetector>>();
    private List<List<MilepostDetector>> milepost_detector_list_520 = new List<List<MilepostDetector>>();
    // Use this for initialization
    void Start () {
        Debug.Log("Start Initiate Milepost Detector No.5");
        init_milepost_detector_5();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void init_normal_car(Transform _transform,float _velocity,int _lane){
	//	GameObject tmp_car = GameObject.Instantiate
	}

	void init_milepost_detector_5(){
        Debug.Log(DataAnalzyer.Instance.mailpost_5.Count);
        for (int i = 0; i < DataAnalzyer.Instance.mailpost_5.Count; ++i) {
            List<MilepostDetector> tmp_list = new List<MilepostDetector>();
            for (int j = 0; j < DataAnalzyer.Instance.mailpost_5.Count; ++j) {
                GameObject tmp_milepost = Instantiate(milepost_detector_model, new Vector3(j * RoadParams.road_width, DataAnalzyer.Instance.mailpost_5[i], 0), Quaternion.identity);
                tmp_milepost.transform.SetParent(GameObject.Find("Traffic_Flow").transform);
                tmp_list.Add(tmp_milepost.GetComponent<MilepostDetector>());
            }
            milepost_detector_list_5.Add(tmp_list);
        }
	}

}
