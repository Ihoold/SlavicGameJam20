using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col) {
        // Special effects, damaging enemies
        Destroy(this.gameObject);
    }
}
