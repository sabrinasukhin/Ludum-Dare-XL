using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider healthSlider;
    public float startingHealth = 100.00f;
    public float currentHealth;
    public float decreaseTime = 5.00f;
    bool damaged;
    
    void Start ()
    {
        currentHealth = startingHealth;
	}
	
	void Update ()
    {
        currentHealth -= decreaseTime * Time.deltaTime;
    }
}
