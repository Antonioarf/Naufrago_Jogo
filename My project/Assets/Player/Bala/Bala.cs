using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((rb.position.x < -25) | (rb.position.x >50) | (rb.position.y < -15) | (rb.position.y > 65)) {
        Destroy(gameObject);        }
    }

    void OnBecameInvisible()
{
    // Destroy the bullet if it goes out of the camera's view
    //Destroy(rb);
     Destroy(gameObject);
}
}
