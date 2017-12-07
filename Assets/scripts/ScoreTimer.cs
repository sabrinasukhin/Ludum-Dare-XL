using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimer : MonoBehaviour
{
    static float timeSurvived = 0.0f;
    float timeStarted;

	void Start ()
    {
		if(gameObject.tag == "Player")
        {
            timeSurvived = 0.0f;
            timeStarted = Time.time;
        }
        else if(gameObject.tag == "ScoreText")
        {
            float oldRecord = PlayerPrefs.GetFloat("highscore", 0.0f); 
        
            if(timeSurvived > oldRecord)
            {
                PlayerPrefs.SetFloat("highscore", timeSurvived);
                gameObject.GetComponent<Text>().text = "You survived for " + timeSurvived.ToString() + " seconds.\nThat's a new record!";
            }
            else
                gameObject.GetComponent<Text>().text = "You survived for " + timeSurvived.ToString() + " seconds.\nYour record is " + oldRecord.ToString() + " seconds.";
        }
	}
    
    void OnDestroy ()
    {
        if(gameObject.tag == "Player")
        {
            timeSurvived = Time.time - timeStarted;
        }
    }
}
