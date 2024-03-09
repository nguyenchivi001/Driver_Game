using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 has_packed_color = new Color32(1,1,1,1);
    [SerializeField] Color32 no_packed_color = new Color32(1,1,1,1);

    SpriteRenderer sprite_renderer;
    bool has_packed;
    [SerializeField] float time_to_destroy = 0.5f;

    void Start()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && has_packed == false )
        {
            has_packed = true;
            Debug.Log("Package picked up");
            sprite_renderer.color = has_packed_color;
            Destroy(other.gameObject , time_to_destroy);
        }
        else if(other.tag == "Customer" && has_packed == true)
        {
            has_packed = false;
            Debug.Log("Package delivered");
            sprite_renderer.color = no_packed_color;
        }
    }
}
