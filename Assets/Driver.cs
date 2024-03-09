using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float speed_steer = 0.1f;
    [SerializeField] float speed_move = 20f;
    [SerializeField] float speed_boost = 30f;
    [SerializeField] float speed_slow = 10f;
    void Update()
    {
        float steer_amount = Input.GetAxis("Horizontal") * speed_steer * Time.deltaTime;
        float move_amount = Input.GetAxis("Vertical") * speed_move * Time.deltaTime;
        transform.Translate(0,move_amount,0);
        transform.Rotate(0, 0, -steer_amount);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        speed_move = speed_slow;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boost" )
        {
            Debug.Log("boosting");
            speed_move = speed_boost;
        }
    }
}
