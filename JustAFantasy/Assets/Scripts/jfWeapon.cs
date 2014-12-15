﻿using UnityEngine;
using System.Collections;

public abstract class jfWeapon : MonoBehaviour {

	public int Ammo = 0;
	public int maxAmmo = -1;
	public string weaponName = "";

    public float fireRatio = 1.0f;

    public KeyCode fastSelect;

    protected void OnStart()
    {
        if (transform.parent != null && transform.parent.gameObject.tag == "Player")
            renderer.enabled = true;
        else
            renderer.enabled = false;
    }

    public int reload(int ammo)
    {
        Ammo += ammo;
        int d = maxAmmo - Ammo;
        if (d < 0)
        {
            maxAmmo -= d;
            return -d;
        }
        else
            return 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(fastSelect) && transform.parent != null && transform.parent.gameObject.tag != "Player")
        {/*
            if (transform.parent != null && transform.parent.gameObject.transform.parent != null)
            {
                
                GameObject weapons = transform.parent.gameObject;
                GameObject levelController = weapons.transform.parent.gameObject;
                GameObject player = levelController.transform.GetChild(3).gameObject;
                GameObject oldWeapon = player.transform.GetChild(1).gameObject;
                oldWeapon.transform.parent = weapons.transform;
                transform.parent = player.transform;
                transform.position = oldWeapon.transform.position;
                transform.rotation = oldWeapon.transform.rotation;
                renderer.enabled = true;
                oldWeapon.renderer.enabled = false;
                */
                transform.parent.SendMessage("ChangeWeapon", transform.gameObject, SendMessageOptions.DontRequireReceiver);
            //}
        }
    }

    void Shoot()
    {
        OpenFire();
    }

    abstract public void OpenFire();
}
