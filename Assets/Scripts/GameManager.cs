using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int health;
    public TextMeshProUGUI healthText;
    public int oxygen;
    public TextMeshProUGUI oxygenText;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        healthText.text = "Health: " + health + "%";
        oxygen = 100;
        oxygenText.text = "O2: " + oxygen + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
