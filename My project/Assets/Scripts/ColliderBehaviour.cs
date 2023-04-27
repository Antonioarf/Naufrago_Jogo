using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBehaviour : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            transform.parent.parent.GetComponent<CollectableObject>().CollisionWithPlayerDetected();
        }
    }
}
