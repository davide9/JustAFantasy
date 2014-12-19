﻿using UnityEngine;
using System.Collections;

public class LifeBar : MonoBehaviour {

	private int currentLife = 5;
	private const int maxLife = 10;

    void Start()
    {
        setLifePoints(currentLife);
    }

	public void addLifePoint()
    {
		if (currentLife < 10)
			currentLife++;
		setLifePoints (currentLife);
	}

	public void removeLifePoint()
    {
		if (currentLife > 0)
			currentLife--;
		setLifePoints (currentLife);
	}

	public void setLifePoints(int n){
        if (n < 0)
            n = 0;
        if (n > maxLife)
            n = maxLife;
        currentLife = n;
		for (int i=0; i<n; i++) {
			(transform.GetChild(i+1).gameObject.GetComponent<GUITexture> ()as GUITexture).enabled = true;
				}
		for (int i=n; i<maxLife; i++) {
			(transform.GetChild(i+1).gameObject.GetComponent<GUITexture> ()as GUITexture).enabled = false;
				}
	}
}
