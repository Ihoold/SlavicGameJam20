using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public float invurnerabilityPeriod = 1f;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    Renderer rendererObject => GetComponent<Renderer>();
    float vurnerableTimer = 0;

    void OnRestartClick()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void Update()
    {
        health = Mathf.Min(health, numOfHearts);

        for (int i = 0; i < hearts.Length; i++) {
            hearts[i].sprite = (i < health) ? fullHeart : emptyHeart;
            hearts[i].enabled = (i < numOfHearts);
        }

        DeathTrigger();
    }

    void DealDamage(int howMuch) {
        if (isVurnerable()) {
            health -= howMuch;
            setInvurnerable();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Special effects, damaging enemies
        if (col.gameObject.tag == "EnemyBullet") {
            DealDamage(1);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy") {
            DealDamage(1);
        }
    }

    bool isVurnerable() {
        return Time.time >= vurnerableTimer;
    }

    IEnumerator InvurnerabilityAnimation() {
        int loops = (int) (invurnerabilityPeriod / .2f);
        for(int i = 0; i < loops; i++) {
            rendererObject.enabled = true;
            yield return new WaitForSeconds(.1f);
            rendererObject.enabled = false;
            yield return new WaitForSeconds(.1f);
        }
        rendererObject.enabled = true;
        yield return null;
    }

    void setInvurnerable() {
        vurnerableTimer = Time.time + invurnerabilityPeriod;
        StartCoroutine(InvurnerabilityAnimation());
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
