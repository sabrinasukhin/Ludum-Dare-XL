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
    public GameObject crlBox;

    void Start()
    {
        currentHealth = startingHealth;
    }

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Input.GetKey("e"))
        {
            AddHealth();
        }
        
            if (Physics.Raycast(new Vector3(0, 0, 0), fwd, 10, 8))
            {
                if (Input.GetKey("e"))
            {
                AddHealth();
                Destroy(crlBox, 0.00f);
            }
                
            }

        currentHealth -= decreaseTime * Time.deltaTime;
        healthBar.transform.localScale += new Vector3(-0.0001f, 0, 0);
        test.text = "" + currentHealth;
    }

    public void AddHealth()
    {
        currentHealth += 20.00f;
        healthBar.transform.localScale += new Vector3(0.10f, 0, 0);
    }
    
}