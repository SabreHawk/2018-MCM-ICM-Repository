using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCarController : MonoBehaviour {

    public Rigidbody2D car_rigidbody;
    public float reaction_time = 0.8f;
    private float g = 9.8f * RoadParams.meter2feet;
    private float u = 0.8f;
    public float v;
    public float max_velocity;

    public bool isSafe;
    public float front_car_distance = 100;

    private void Awake() {
        isSafe = true;
    }

    // Update is called once per frame
    void Update () {
        float security_distance = 10*(car_rigidbody.velocity.y * reaction_time + Mathf.Pow(car_rigidbody.velocity.y, 2) / (2 * g * u));
        set_security_distance(security_distance+4.5f);
        max_velocity = 60000 / 60 / 60 * RoadParams.meter2feet * 0.1f;

        if (!isSafe) {
            Vector2 temp_velocity = new Vector2(0, -10 * Time.deltaTime / Mathf.Pow(front_car_distance + 0.1f, 2));
            car_rigidbody.velocity += temp_velocity;
        } else {
            car_rigidbody.velocity *= 1.004f;
            if (car_rigidbody.velocity.y > max_velocity) {
                car_rigidbody.velocity = new Vector2(0, max_velocity);
            }
        }
        //print(car_rigidbody.velocity);
        v = car_rigidbody.velocity.y;
    }

    public void set_velocity(float _v) {
        Vector2 tmp_velocity = new Vector2(0, _v);
        car_rigidbody.velocity = tmp_velocity;
    }

    public void set_security_distance(float _s) {
        car_rigidbody.GetComponentInChildren<CircleCollider2D>().radius = _s;
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.tag == Tag.normal_car) {
            Debug.LogError("Collision");
        }

    }
}
