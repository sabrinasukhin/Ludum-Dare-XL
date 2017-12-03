using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float startingHealth = 100.00f;
    private float currentHealth;
    public float decreaseTime = 5.00f;
    public Camera cam;
    //public Text test;
    public Material highlight;
    public Material norm;
    public Slider healthBar;
    
    private GameObject cerealParent = null;
    private GameObject cerealChild = null;
    private bool cerealExists = false;

    void Start()
    {
        currentHealth = startingHealth;
        healthBar.value = CalcHealth();
    }

    void Update()
    {
        if(cerealExists)
        {
            try
            {
                cerealChild.GetComponent<Renderer>().material = norm;
            }
            catch (Exception e)
            {
                cerealExists = false;
            }
        }
        
        Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int layerMask = 1 << 8;
        
        RaycastHit hit;
        
        if (Physics.Raycast(rayOrigin, fwd, out hit, 2, layerMask))
        {
            cerealParent = hit.transform.gameObject;
            cerealChild = hit.transform.GetChild(0).gameObject;
            cerealExists = true;
            
            Debug.DrawRay(rayOrigin, fwd, Color.green);
            cerealChild.GetComponent<Renderer>().material = highlight;
            
            if (Input.GetKey("e"))
            {
                Destroy(cerealParent);
                cerealExists = false;
                AddHealth();
            }
        }

        currentHealth -= decreaseTime * Time.deltaTime;
        healthBar.value = CalcHealth();
        //test.text = "" + currentHealth;
    }

    float CalcHealth()
    {
        return currentHealth / startingHealth;
    }

    public void AddHealth()
    {
        currentHealth += 20.00f;
        healthBar.value = CalcHealth();
    }

    public void DealDamage()
    {
        currentHealth -= 10.00f;
        healthBar.value = CalcHealth();
    }
    
}