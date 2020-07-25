﻿using UnityEngine;

public class Shooting : MonoBehaviour
{
    Gun gun => GetComponentInChildren<Gun>();

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && gun.CanShoot()) {
            gun.Shoot();
        }
    }
}
