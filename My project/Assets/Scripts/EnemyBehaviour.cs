using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    public float speed;
    public float chasingSpeed;

    public float walkingTime;
    public float idleTime;

    public GameObject target;
    public float minDistanceToChasePlayer = 10f;
    public float distanceToAttackPlayer = 1f;

    public float zombieHealthPoints = 10f;
    public float zombieDamage = 5f;
    public float attackCooldown = 2f;

    // playlist of soundeffects
    public AudioClip[] zombieSounds;
    public AudioSource zombieAudioSource;
    public float zombieSoundCooldown = 5f;
    
    private Rigidbody2D rb;
    private Animator animator;
    
    private float waitTime;
    private float initialTime;

    private float lastAttack;

    private Vector2 movingDirection;
    private float movingSpeed;
    
    private float distanceToPlayer;
    private bool canAttack = false;
    private bool hasAttacked = false;


    private Vector2[] directions = { 
        Vector2.zero, Vector2.up,
        Vector2.zero, Vector2.down,
        Vector2.zero, Vector2.left,
        Vector2.zero, Vector2.right,
    }; // 50% chance of not moving;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        target = GameObject.FindWithTag("Player");

        initialTime = Time.time;
        waitTime = walkingTime;
    }

    void Update() 
    {
        Vector2 playerPosition = target.transform.position;
        float distanceToPlayer = Vector2.Distance(rb.transform.position, playerPosition);

        if (distanceToPlayer < minDistanceToChasePlayer) {
            movingDirection = playerPosition - (Vector2) transform.position;
            movingSpeed = chasingSpeed;

            if (distanceToPlayer < distanceToAttackPlayer) {
                canAttack = true;
                
                attack(target);
            } else {
                canAttack = false;
            }
            
        } else {
            movingSpeed = speed;

            if (Time.time - initialTime > waitTime) {
                movingDirection = ChangeDirectionRandomly();
                waitTime = setWaitTime(movingDirection);

                initialTime = Time.time;
            }

        }

        if (hasAttacked) {
            if (Time.time - lastAttack > attackCooldown) {
                hasAttacked = false;
                lastAttack = Time.time;
            }
        }

    }
    
    void FixedUpdate ()
    {
        if (!hasAttacked) {
            if (movingDirection != Vector2.zero) {
                animator.SetBool("EnemyIsMoving", true);
                rb.MovePosition(rb.position + movingDirection * movingSpeed * Time.fixedDeltaTime);
                rb.rotation = Mathf.Atan2(movingDirection.y, movingDirection.x) * Mathf.Rad2Deg;
            } 
            else {
                animator.SetBool("EnemyIsMoving", false);
            }
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

    void attack(GameObject target)
    {
        if (canAttack && !hasAttacked)
        {
            hasAttacked = true;
            lastAttack = Time.time;

            animator.SetBool("EnemyIsMoving", false);
            animator.SetTrigger("EnemyIsAttacking");

            Debug.Log("Attacked! Player HP: " +  target.GetComponent<PlayerController>().healthPoints);
            target.GetComponent<PlayerController>().healthPoints -= zombieDamage;

            int index = Random.Range(0, zombieSounds.Length);
            zombieAudioSource.PlayOneShot(zombieSounds[index], .6f);
        }

    }
}
