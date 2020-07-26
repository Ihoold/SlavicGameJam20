using UnityEngine;

public class FirstAid : MonoBehaviour
{
    GameObject player => GameObject.FindWithTag("Player");
    Health health => player.GetComponent<Health>();
    SpriteRenderer ren => player.GetComponent<SpriteRenderer>();
    
    void OnCollisionStay2D(Collision2D col) {
        if (col.collider.tag == "Player") {
            if (health.health < health.numOfHearts) {
                health.health += 1;
                SoundManagerScript.PlaySound("FirstAid");
                health.StartHealAnimation();
                Destroy(gameObject);
            }
        }
    }
}
