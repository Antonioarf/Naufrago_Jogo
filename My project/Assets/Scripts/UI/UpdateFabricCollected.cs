using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateFabricCollected : MonoBehaviour
{

    private TextMeshProUGUI UIText;
    private GameObject player;
    private void Awake()
    {
        UIText = GetComponent<TextMeshProUGUI>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    public void LateUpdate()
    {
        UIText.text = player.GetComponent<PlayerController>().fabricCollected.ToString();
        // TODO: add / NEEDED TO COLLECT
    }
}
