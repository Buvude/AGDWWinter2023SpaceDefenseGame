using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int health;
    public TextMeshProUGUI healthText;
    private int ammo;
    public TextMeshProUGUI ammoText;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        healthText.text = "Health: " + health + "%";
        ammo = 6;
        ammoText.text = "Ammo: " + ammo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
