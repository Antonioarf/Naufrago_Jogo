using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSprite : MonoBehaviour
{
    public Sprite[] sprites;

    public void Awake() {
        int index = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

}
