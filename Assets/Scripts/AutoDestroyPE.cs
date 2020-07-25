using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyPE : MonoBehaviour
{
    // Cleanup
    void Start()
    {
        ParticleSystem parts = GetComponentInChildren<ParticleSystem>();
        float totalDuration = parts.duration + parts.startLifetime;
        Destroy(gameObject, totalDuration);
    }
}
