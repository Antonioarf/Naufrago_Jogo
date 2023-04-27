using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float linear_speed;
    public float rotation_speed;

    public int healthPoints = 80;
    public int maxHealthPoints = 100;

    public int woodCollected = 0;
    public int ropeCollected = 0;
    public int fabricCollected = 0;

    public GameObject bulletPrefab; // assign your bullet prefab in the Inspector
    public float bullet_speed;


    Vector2 movementInput;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    private void FixedUpdate() {
        if(movementInput != Vector2.zero){
            GetComponent<Animator>().SetBool("Andando", true);
            rb.MovePosition(rb.position + movementInput * linear_speed * Time.fixedDeltaTime);
            Rotate(movementInput);
        } else {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            GetComponent<Animator>().SetBool("Andando", false);
        }}



    
    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire(InputValue clickValue) {
        GetComponent<Animator>().SetTrigger("Tiro");
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 direction = mousePosition - transform.position;
        direction.z = 0f;
        direction.Normalize();

        // Create a new bullet instance and set its position and rotation
        Quaternion playerRotation = transform.rotation;
        Vector3 offset = playerRotation * new Vector3(0.5f, -0.5f, 0f); // adjust the offset as needed
        GameObject bullet = Instantiate(bulletPrefab, (transform.position+offset), Quaternion.identity);
        bullet.transform.rotation = Quaternion.LookRotation(Vector3.forward,direction);

        // Shoot the bullet in the direction of the mouse cursor
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = direction * bullet_speed;
    }

    
    void Rotate(Vector2 direction){ // essa eh na conta do GPT
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void increaseHealthPoints(int amount) {
        if (healthPoints + amount > maxHealthPoints) {
            healthPoints = maxHealthPoints;
        } else {
            healthPoints += amount;
        }
    }
}

