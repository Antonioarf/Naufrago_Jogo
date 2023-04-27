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
            player.GetComponent<PlayerController>().healthPoints += 10;
        }
        switch (collectableType)
        {
            case "Food":
                player.GetComponent<PlayerController>().healthPoints += 10;
                break;
                
            case "Wood":
                player.GetComponent<PlayerController>().woodCollected += 1;
                break;

            case "Rope":
                player.GetComponent<PlayerController>().ropeCollected += 1;
                break;

            case "Fabric":
                player.GetComponent<PlayerController>().tissueCollected += 1;
                break;

            default:
                break;
        }
        
        audioSource.PlayOneShot(collectSound);

        Invoke("DestroySelf", 0.5f);
    }
}
