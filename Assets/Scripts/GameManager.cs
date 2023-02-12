using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int health;
    public TextMeshProUGUI healthText;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        healthText.text = "Health: " + health + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
