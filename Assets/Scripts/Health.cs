using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject healthBar;
    public float startingHealth = 100.00f;
    private float currentHealth;
    public float decreaseTime = 5.00f;
    public Camera cam;
    public Text test;
    public GameObject cerealBox;
    public GameObject crlBox;
    public Material highlight;
    public Material norm;

    void Start()
    {
        currentHealth = startingHealth;
    }

    void Update()
    {
        Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        int layerMask = 1 << 8;
        if (Physics.Raycast(rayOrigin, fwd, 2, layerMask))
        {
            Debug.DrawRay(rayOrigin, fwd, Color.green);
            crlBox.GetComponent<Renderer>().material = highlight;
            if (Input.GetKey("e"))
            {
                AddHealth();
                Destroy(cerealBox, 0.00f);
            }
        }
        else
        {
            crlBox.GetComponent<Renderer>().material = norm;
        }

        //currentHealth -= decreaseTime * Time.deltaTime;
        //healthBar.transform.localScale += new Vector3(-0.0001f, 0, 0);
        test.text = "" + currentHealth;
    }

    public void AddHealth()
    {
        currentHealth += 20.00f;
        healthBar.transform.localScale += new Vector3(0.001f, 0, 0);
    }

    public void DealDamage()
    {
        currentHealth -= 10.00f;
        healthBar.transform.localScale += new Vector3(-.001f, 0, 0);
    }
    
}