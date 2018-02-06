using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilepostDetector : MonoBehaviour {
    public GameObject normal_car_model;
	public int milepost_index;
	public int lane_index;
    public float init_car_probability;
    public Queue<int> waiting_queue = new Queue<int>(); //0 - normal car ;1 - sef-driving car ;

    private void Update() {
        init_car();
    }
    void OnTriggerEnter2D(){
	}
    public void set_index(int _x,int _y) {
        lane_index = _x;
        milepost_index = _y;
    }
    public void set_probability(float _p) {
        this.init_car_probability = _p;
    }
    public void add_normal_car(int _type) {
        waiting_queue.Enqueue(_type);
    }

    public void init_car() {
        if(waiting_queue.Count == 0) {
            return;
        }
        int car_type = waiting_queue.Dequeue();
        if(car_type == 0) {
            init_nor_car();
        }else if(car_type == 1) {
            init_sef_car();
        }
    }

    private void init_nor_car() {
        GameObject tmp_car = Instantiate(normal_car_model, this.transform.position,Quaternion.identity);
        tmp_car.GetComponent<NormalCarController>().set_velocity(3f);
        tmp_car.transform.SetParent(GameObject.Find("Traffic_Flow").transform);
    }
    private void init_sef_car() {

    }
}
