using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageShip : MonoBehaviour
{
    public bool isShipDamaged;
    public int cooldown = 10;
    public int oxygenDrain = 1;
    public int breakStateMin = 1;
    public int breakStateMax = 7;
    public int breakState;
    public float checkBetween = 5.0f;
    public float repeatRate = 1.0f;
    public GameManager gameManager;

    // Start is called before the first frame update
    private void Start()
    {
        if (gameManager.isGameActive)
        {
            StartCoroutine(BreakShip());
            if (breakState == 6)
            {
                ShipDamage();
            }
        }
    }
    public void ShipStatus()
    {
        
    }

    public void ShipDamage()
    {
        isShipDamaged = true;
        StopCoroutine("BreakShip");


        if (isShipDamaged)
        {
            gameManager.oxygen -= oxygenDrain;
        }
        if (gameManager.oxygen == 0)
        {
            gameManager.GameOver();
        }

    }

    public IEnumerator BreakShip()
    {
        breakState = Random.Range(breakStateMin, breakStateMax);
        yield return new WaitForSeconds(checkBetween);
    }
}
