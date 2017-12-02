using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    public int HealthPoints = 20;
    public bool SpecialDeath = false;

	void OnTriggerEnter(Collider other)
    {
        HealthPoints -= 1;
        
        if(HealthPoints <= 0)
        {
            if(SpecialDeath)
                SendMessage("Death");
            else
                Destroy(this.gameObject);
        }
    }
}
