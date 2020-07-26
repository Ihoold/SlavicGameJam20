using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public float flashingPeriod = 0.4f;

    SpriteRenderer ren => GetComponent<SpriteRenderer>();

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        DeathTrigger();
    }

    public void DealDamage(int howMuch)
    {
        health -= howMuch;
        StartCoroutine(HitAnimation());
    }

    IEnumerator HitAnimation() {
        int loops = (int) (flashingPeriod / .2f);
        for(int i = 0; i < loops; i++) {
            ren.color = Color.red;
            yield return new WaitForSeconds(.1f);
            ren.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
        ren.color = Color.white;
        yield return null;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Special effects, damaging enemies
        if (col.gameObject.tag == "PlayerBullet")
        {
            DealDamage(1);
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

