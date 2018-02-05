using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager: MonoBehaviour {
    public TrafficManager Instance;
	public GameObject milepost_detector_model;
    private List<List<MilepostDetector>> milepost_detector_list_5 = new List<List<MilepostDetector>>();
    private List<List<MilepostDetector>> milepost_detector_list_90 = new List<List<MilepostDetector>>();
    private List<List<MilepostDetector>> milepost_detector_list_405 = new List<List<MilepostDetector>>();
    private List<List<MilepostDetector>> milepost_detector_list_520 = new List<List<MilepostDetector>>();
    public float simulation_timer;
    public float game_timer = 0;
    public int car_num;
    // Use this for initialization
    void Start () {
        Debug.Log("Start Initiate Milepost Detector No.5");
        init_milepost_detector_5();
        car_num = 0;
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        game_timer += Time.deltaTime;  
        simulation_timer += Time.deltaTime;
        if (simulation_timer > GeneralParams.interval_time) {
            init_car();//call each milepost detector to init cars
            simulation_timer = 0;
            Debug.Log(car_num);
            Debug.Log(game_timer/60);


        }
    }
    public void init_car() {
        foreach (List<MilepostDetector> tmp_list in milepost_detector_list_5) {
            foreach(MilepostDetector tmp_mp_detector in tmp_list) {
                if (Random.Range(0,100) <= tmp_mp_detector.init_car_probability*100) {
                    tmp_mp_detector.add_normal_car(0);
                    car_num++;
                }

            }
        }
    }
	void init_milepost_detector_5(){
        for (int i = 0; i < DataAnalyzer.Instance.mailpost_5.Count-1; ++i) {
            List<MilepostDetector> tmp_list = new List<MilepostDetector>();
            float tmp_lane_num = DataAnalyzer.Instance.lanes_number_5[i][0] + DataAnalyzer.Instance.lanes_number_5[i][1];
            for (int j = 0; j < DataAnalyzer.Instance.lanes_number_5[i][0]; ++j) {
                GameObject tmp_milepost = Instantiate(milepost_detector_model, new Vector3(j * RoadParams.road_width, DataAnalyzer.Instance.mailpost_5[i] * GeneralParams.scale * RoadParams.mile2feet - RoadParams.road_5_start_milespost, 0), Quaternion.identity);
                tmp_milepost.transform.SetParent(GameObject.Find("Mileposts").transform);
                tmp_milepost.GetComponent<MilepostDetector>().set_index(j, i);
                //The probability of initiation of car in each lane = daily_avg_car_count / init_car_interval_time * (lane ratio of the total lanes)
                tmp_milepost.GetComponent<MilepostDetector>().set_probability(DataAnalyzer.Instance.traffic_counts_5[i] /  CarParams.init_car_probability_denominator / tmp_lane_num *0.1f);
                tmp_list.Add(tmp_milepost.GetComponent<MilepostDetector>());
            }
            milepost_detector_list_5.Add(tmp_list);
        }
	}

}
