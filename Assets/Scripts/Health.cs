using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject healthBar;
    public float startingHealth = 100.00f;
    public float currentHealth;
    public float decreaseTime = 5.00f;
    bool damaged;
    public Text test;

    void Start()
    {
        currentHealth = startingHealth;
    }

    void Update()
    {
        currentHealth -= decreaseTime * Time.deltaTime;
        healthBar.transform.localScale += new Vector3(-0.0001F, 0, 0);
        test.text = "" + currentHealth;
    }
}