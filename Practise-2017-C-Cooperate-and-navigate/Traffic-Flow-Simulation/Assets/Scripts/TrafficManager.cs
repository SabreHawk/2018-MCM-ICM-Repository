using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager: MonoBehaviour {
    public static TrafficManager Instance;
	public GameObject milepost_detector_model;
    private List<List<MilepostDetector>> milepost_detector_list_5 = new List<List<MilepostDetector>>();
    private List<List<MilepostDetector>> milepost_detector_list_90 = new List<List<MilepostDetector>>();
    private List<List<MilepostDetector>> milepost_detector_list_405 = new List<List<MilepostDetector>>();
    private List<List<MilepostDetector>> milepost_detector_list_520 = new List<List<MilepostDetector>>();
    public float simulation_timer;
    public float game_timer = 0;
    public int normal_car_num;
    public int self_car_num;
    public float normal_car_ratio = 0.3f;
    public List<GameObject> car_list = new List<GameObject>();
    public float total_velocity;
    public float average_velocity;
    public float min_velocity = 100;
    public float new_enter_car_ratio;
    // Use this for initialization
    void Start () {
        Debug.Log("Start Initiate Milepost Detector No.5");
        normal_car_num = 0;
        self_car_num = 0;
        Instance = this;
        InitEnterRoadDetector();
        InitFollowingRoadDetector(2);
        min_velocity = 100;
    }

    int temp = 0;
	// Update is called once per frame
	void Update () {
        game_timer += Time.deltaTime;  
        simulation_timer += Time.deltaTime;
        if (simulation_timer > GeneralParams.interval_time) {
            init_car_405();//call each milepost detector to init cars
            simulation_timer = 0;
            if (temp != (int)Mathf.Round(game_timer / 60) % 5) {
                if (temp == 0) {
                    //Debug.Log(car_num);
                    Debug.Log(game_timer / 60);
                }
            }
            temp = (int)Mathf.Round(game_timer / 60) % 5;
            //Debug.Log(car_num);
            //Debug.Log(game_timer / 60);

        }
        total_velocity = 0;
        int tmp_car_num = 0;
        foreach (GameObject tmp in car_list) {
            if(tmp != null) {
                total_velocity += tmp.GetComponent<Rigidbody2D>().velocity.magnitude;
                tmp_car_num++;
            }

        }
        average_velocity = total_velocity / tmp_car_num;
        if(average_velocity < min_velocity) {
            min_velocity = average_velocity;
        }
        if(game_timer/10 > 1) {
            game_timer = 0;
            average_velocity = 0;
            min_velocity = 100;
        }
    }

    public void InitEnterRoadDetector() {
        for (int i = 0; i < 1; ++i) {
            List<MilepostDetector> tmp_list = new List<MilepostDetector>();
            float tmp_lane_num = DataAnalyzer.Instance.lanes_number_405[i][0] + DataAnalyzer.Instance.lanes_number_405[i][1];
            for (int j = 0; j < DataAnalyzer.Instance.lanes_number_405[i][0]; ++j) {

                GameObject tmp_milepost = Instantiate(milepost_detector_model, new Vector3(j * RoadParams.road_width, DataAnalyzer.Instance.milepost_405[i] * GeneralParams.scale * RoadParams.mile2feet - RoadParams.road_405_start_milespost, 0), Quaternion.identity);
                tmp_milepost.transform.SetParent(GameObject.Find("Mileposts").transform);
                tmp_milepost.GetComponent<MilepostDetector>().set_index(j, i);
                //The probability of initiation of car in each lane = daily_avg_car_count / init_car_interval_time * (lane ratio of the total lanes)
                tmp_milepost.GetComponent<MilepostDetector>().set_probability(2 * DataAnalyzer.Instance.traffic_counts_405[i] / CarParams.init_car_probability_denominator * (DataAnalyzer.Instance.lanes_number_405[i][0] / tmp_lane_num));
                tmp_list.Add(tmp_milepost.GetComponent<MilepostDetector>());
            }
            milepost_detector_list_405.Add(tmp_list);
        }
    }

    public void InitFollowingRoadDetector(int _detector_num) {
        int detector_num = _detector_num > DataAnalyzer.Instance.milepost_405.Count ? DataAnalyzer.Instance.milepost_405.Count : _detector_num;
        for (int i = 1; i < detector_num; ++i) {
            List<MilepostDetector> tmp_list = new List<MilepostDetector>();
            float tmp_lane_num = DataAnalyzer.Instance.lanes_number_405[i][0] + DataAnalyzer.Instance.lanes_number_405[i][1];
            for (int j = 0; j < DataAnalyzer.Instance.lanes_number_405[i][0]; ++j) {

                GameObject tmp_milepost = Instantiate(milepost_detector_model, new Vector3(j * RoadParams.road_width, DataAnalyzer.Instance.milepost_405[i] * GeneralParams.scale * RoadParams.mile2feet - RoadParams.road_405_start_milespost, 0), Quaternion.identity);
                tmp_milepost.transform.SetParent(GameObject.Find("Mileposts").transform);
                tmp_milepost.GetComponent<MilepostDetector>().set_index(j, i);
                //The probability of initiation of car in each lane = daily_avg_car_count / init_car_interval_time * (lane ratio of the total lanes)
                tmp_milepost.GetComponent<MilepostDetector>().set_probability(DataAnalyzer.Instance.traffic_counts_405[i] / CarParams.init_car_probability_denominator * (DataAnalyzer.Instance.lanes_number_405[i][0] / tmp_lane_num*0.3f ));
                tmp_list.Add(tmp_milepost.GetComponent<MilepostDetector>());
            }
            milepost_detector_list_405.Add(tmp_list);
        }
    }
    public void init_car_405() {
        foreach (List<MilepostDetector> tmp_list in milepost_detector_list_405) {
            foreach(MilepostDetector tmp_mp_detector in tmp_list) {     
                if (Random.Range(0,100) <= tmp_mp_detector.init_car_probability*100) {
                    if (Random.Range(0, 100) <= normal_car_ratio * 100) {
                        tmp_mp_detector.add_car(0);
                        normal_car_num++;
                    } else {
                        tmp_mp_detector.add_car(1);
                        self_car_num++;
                    }
                }

            }
        }
    }
    public void init_car_5() {
        foreach (List<MilepostDetector> tmp_list in milepost_detector_list_5) {
            foreach (MilepostDetector tmp_mp_detector in tmp_list) {
                if (Random.Range(0, 100) <= tmp_mp_detector.init_car_probability * 100) {

                    tmp_mp_detector.add_car(0);
                    //car_num++;
                }

            }
        }
    }
    void init_milepost_detector_5(){
        for (int i = 0; i < DataAnalyzer.Instance.milepost_5.Count-1; ++i) {
            List<MilepostDetector> tmp_list = new List<MilepostDetector>();
            float tmp_lane_num = DataAnalyzer.Instance.lanes_number_5[i][0] + DataAnalyzer.Instance.lanes_number_5[i][1];
            for (int j = 0; j < DataAnalyzer.Instance.lanes_number_5[i][0]; ++j) {
                GameObject tmp_milepost = Instantiate(milepost_detector_model, new Vector3(j * RoadParams.road_width, DataAnalyzer.Instance.milepost_5[i] * GeneralParams.scale * RoadParams.mile2feet - RoadParams.road_5_start_milespost, 0), Quaternion.identity);
                tmp_milepost.transform.SetParent(GameObject.Find("Mileposts").transform);
                tmp_milepost.GetComponent<MilepostDetector>().set_index(j, i);
                //The probability of initiation of car in each lane = daily_avg_car_count / init_car_interval_time * (lane ratio of the total lanes)
                tmp_milepost.GetComponent<MilepostDetector>().set_probability(DataAnalyzer.Instance.traffic_counts_5[i] /  CarParams.init_car_probability_denominator *(DataAnalyzer.Instance.lanes_number_405[i][0] / tmp_lane_num * new_enter_car_ratio));
                tmp_list.Add(tmp_milepost.GetComponent<MilepostDetector>());
            }
            milepost_detector_list_5.Add(tmp_list);
        }
	}
    void init_milepost_detector_405() {
        for (int i = 0; i < 2; ++i) {
            List<MilepostDetector> tmp_list = new List<MilepostDetector>();
            float tmp_lane_num = DataAnalyzer.Instance.lanes_number_405[i][0] + DataAnalyzer.Instance.lanes_number_405[i][1];
            for (int j = 0; j < DataAnalyzer.Instance.lanes_number_405[i][0]; ++j) {

                GameObject tmp_milepost = Instantiate(milepost_detector_model, new Vector3(j * RoadParams.road_width, DataAnalyzer.Instance.milepost_405[i] * GeneralParams.scale * RoadParams.mile2feet - RoadParams.road_405_start_milespost, 0), Quaternion.identity);
                tmp_milepost.transform.SetParent(GameObject.Find("Mileposts").transform);
                tmp_milepost.GetComponent<MilepostDetector>().set_index(j, i);
                //The probability of initiation of car in each lane = daily_avg_car_count / init_car_interval_time * (lane ratio of the total lanes)
                tmp_milepost.GetComponent<MilepostDetector>().set_probability(DataAnalyzer.Instance.traffic_counts_405[i] / CarParams.init_car_probability_denominator *(DataAnalyzer.Instance.lanes_number_405[i][0]/tmp_lane_num) );
                tmp_list.Add(tmp_milepost.GetComponent<MilepostDetector>());
            }
            milepost_detector_list_405.Add(tmp_list);
        }
    }

}
