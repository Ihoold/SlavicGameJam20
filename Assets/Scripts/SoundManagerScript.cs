using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
  public static AudioClip shootSound, hitSound, enemyShoot, enemyAuto;

    static AudioSource audioSource;

 
    void Start()
    {
        shootSound = Resources.Load<AudioClip>("Shoot");
        Debug.Log(shootSound);
        // hitSound = Resources.Load<AudioClip> ("Hit");
        enemyShoot = Resources.Load<AudioClip>("EnemyShoot");
        enemyAuto = Resources.Load<AudioClip>("AutoGun");

        audioSource = GetComponent<AudioSource> ();
    }

    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Shoot":
                audioSource.PlayOneShot(shootSound);
                break;

            // case "Hit":
            //    audioSource.PlayOneShot(hitSound);
            //   break;

            case "EnemyShoot":
                audioSource.PlayOneShot(enemyShoot);
                break;

            case "AutoGun":
                audioSource.PlayOneShot(enemyAuto);
                break;
        }
    }
}
