using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        DealDamage();
        DeathTrigger();
    }

    public void DealDamage()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            health -= 1;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Special effects, damaging enemies
        if (col.gameObject.tag == "PlayerBullet")
        {
            health -= 1;
            Debug.Log("Hit!");
        }
    }



    public void DeathTrigger()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}

