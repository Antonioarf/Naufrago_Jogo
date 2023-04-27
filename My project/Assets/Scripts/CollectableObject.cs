using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public GameObject player;
    private string collectableType;

    private AudioSource audioSource;
    public AudioClip collectSound;


    void Awake(){
        collectableType = gameObject.tag;
        audioSource = GetComponent<AudioSource>();
    }

    private void DestroySelf() {
        Destroy(gameObject);
    }

    public void CollisionWithPlayerDetected() {
        Debug.Log("Collision with " + collectableType);


        if (gameObject.CompareTag("Food")) {
            player.GetComponent<PlayerController>().increaseHealthPoints(10);
        } 
        else if (gameObject.CompareTag("Wood")) {
            player.GetComponent<PlayerController>().woodCollected += 1;
        }
        else if (gameObject.CompareTag("Rope")) {
            player.GetComponent<PlayerController>().ropeCollected += 1;
        } 
        else if (gameObject.CompareTag("Fabric")) {
            player.GetComponent<PlayerController>().fabricCollected += 1;
        }


        
        audioSource.PlayOneShot(collectSound);

        Invoke("DestroySelf", 0.2f);
    }
}
