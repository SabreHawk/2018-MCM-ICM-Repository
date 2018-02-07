using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilepostDetector : MonoBehaviour {
    public GameObject normal_car_model;
    public GameObject self_car_model;
	public int milepost_index;
	public int lane_index;
    public float init_car_probability;
    public Queue<int> waiting_queue = new Queue<int>(); //0 - normal car ;1 - sef-driving car ;
    public int queue_len;
    public int SafeAeraCarNum = 0;
    public int passCarNum = 0;
    public int initCarNum = 0;
    private void Start() {
        queue_len = 0;
    }
    private void Update() {
        init_car();
        queue_len = waiting_queue.Count;
    }
    private void OnTriggerEnter2D(Collider2D _other){
        if(_other.transform.tag == Tag.normal_car &&  Mathf.Abs(_other.transform.position.x -this.transform.position.x) < 0.2f && _other.transform.position.y < this.transform.position.y) {
            SafeAeraCarNum++;
            passCarNum++;
        }
	}
    private void OnTriggerExit2D(Collider2D _other) {
        if (_other.transform.tag == Tag.normal_car && Mathf.Abs(_other.transform.position.x - this.transform.position.x) < 0.2f && _other.transform.position.y > this.transform.position.y) {
            SafeAeraCarNum--;
        }
    }
    public void set_index(int _x,int _y) {
        lane_index = _x;
        milepost_index = _y;
    }
    public void set_probability(float _p) {
        this.init_car_probability = _p;
    }
    public void add_car(int _type) {
        waiting_queue.Enqueue(_type);
    }

    public void init_car() {
        if(waiting_queue.Count == 0) {
            return;
        }
        int car_type = waiting_queue.Dequeue();
        if(SafeAeraCarNum+initCarNum > 0) {
            return;
        }
        if (car_type == 0) {
            init_nor_car();
        }else if(car_type == 1) {
            init_sef_car();
        }
    }

    private void init_nor_car() {
        GameObject tmp_car = Instantiate(normal_car_model, this.transform.position,Quaternion.identity);
        tmp_car.GetComponent<NormalCarController>().set_velocity(13.889f*RoadParams.meter2feet*0.1f);
        tmp_car.GetComponent<NormalCarController>().max_velocity = Random.Range(80, 120) / CarParams.max_car_velocity;
        tmp_car.transform.SetParent(GameObject.Find("Traffic_Flow").transform);
        TrafficManager.Instance.car_list.Add(tmp_car);
        initCarNum++;
    }
    private void init_sef_car() {
        GameObject tmp_car = Instantiate(self_car_model, this.transform.position, Quaternion.identity);
        tmp_car.GetComponent<NormalCarController>().reaction_time = 0.01f;
        tmp_car.GetComponent<NormalCarController>().set_velocity(13.889f * RoadParams.meter2feet * 0.1f);
        tmp_car.transform.SetParent(GameObject.Find("Traffic_Flow").transform);
        TrafficManager.Instance.car_list.Add(tmp_car);
        initCarNum++;
    }
}
