using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = (transform.right * speed);
        Destroy(this.gameObject, 2f);
    }
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Engel"))
        {
            print("elledi");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
