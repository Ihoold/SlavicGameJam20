using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void OnRestartClick()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
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
        if (col.gameObject.tag == "EnemyBullet")
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
            OnRestartClick();
        }
    }

}
