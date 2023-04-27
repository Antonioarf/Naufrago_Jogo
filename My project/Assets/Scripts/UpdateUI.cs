using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour
{

    public GameObject player;    
    private TextMeshProUGUI UIText;

    private void Awake()
    {
        UIText = GetComponent<TextMeshProUGUI>();
    }


    public void LateUpdate()
    {
        UIText.text = "HP: " + player.GetComponent<PlayerController>().healthPoints + "\n" +
                      "Wood: " + player.GetComponent<PlayerController>().woodCollected + "\n" +
                      "Rope: " + player.GetComponent<PlayerController>().ropeCollected + "\n" +
                      "Fabric: " + player.GetComponent<PlayerController>().fabricCollected + "\n";
    }
}
