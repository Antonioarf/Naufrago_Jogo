using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    public float speed;
    public float chasingSpeed;

    public float walkingTime;
    public float idleTime;

    public float minDistanceToChasePlayer = 10f;
    public float distanceToAttackPlayer = 1f;

    private Rigidbody2D rb;
    private Animator animator;
    
    private float waitTime;
    private float initialTime;

    private Vector2 movingDirection;
    private float distanceToPlayer;
    private float movingSpeed;

    private Vector2[] directions = { 
        Vector2.zero, Vector2.up,
        Vector2.zero, Vector2.down,
        Vector2.zero, Vector2.left,
        Vector2.zero, Vector2.right,
    }; // 50% chance of not moving;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();


        initialTime = Time.time;
        waitTime = walkingTime;
    }

    void Update() 
    {
        Vector2 playerPosition = GameObject.FindWithTag("Player").transform.position;
        float distanceToPlayer = Vector2.Distance(rb.transform.position, playerPosition);

        if (distanceToPlayer < minDistanceToChasePlayer) {
            movingDirection = playerPosition - (Vector2) transform.position;
            movingSpeed = chasingSpeed;

            if (distanceToPlayer < distanceToAttackPlayer) {
                Debug.Log("Attack!");
                animator.SetBool("EnemyIsMoving", false);
                animator.SetTrigger("EnemyIsAttacking");
                // attack(gameObject player);
            }
            
        } else {
            movingSpeed = speed;

            if (Time.time - initialTime > waitTime) {
                movingDirection = ChangeDirectionRandomly();
                waitTime = setWaitTime(movingDirection);

                initialTime = Time.time;
            }

        }

    }
    
    void FixedUpdate ()
    {
        if (movingDirection != Vector2.zero) {
            animator.SetBool("EnemyIsMoving", true);
            rb.MovePosition(rb.position + movingDirection * movingSpeed * Time.fixedDeltaTime);
            rb.rotation = Mathf.Atan2(movingDirection.y, movingDirection.x) * Mathf.Rad2Deg;
        } 
        else {
            animator.SetBool("EnemyIsMoving", false);
        }

    }
    
    float setWaitTime(Vector2 direction) {
        if (direction == Vector2.zero) {
            return idleTime;
        } 
            
        return walkingTime;
        
    }

    Vector2 ChangeDirectionRandomly () {
        int index = Random.Range(0, directions.Length);
        return directions[index];
    }
}
