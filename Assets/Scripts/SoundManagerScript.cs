using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
  public static AudioClip shootSound, hitSound, enemyShoot, enemyAuto, firstAid;

    static AudioSource audioSource;

 
    void Start()
    {
        shootSound = Resources.Load<AudioClip>("Shoot");
        // hitSound = Resources.Load<AudioClip> ("Hit");
        enemyShoot = Resources.Load<AudioClip>("EnemyShoot");
        enemyAuto = Resources.Load<AudioClip>("AutoGun");
        firstAid = Resources.Load<AudioClip>("FirstAid");

        audioSource = GetComponent<AudioSource> ();
        audioSource.volume = PlayerPrefs.GetFloat("Volume", 1f);
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

            case "FirstAid":
                audioSource.PlayOneShot(firstAid);
                break;
        }
    }
}
