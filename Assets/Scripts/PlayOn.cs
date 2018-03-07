using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOn : MonoBehaviour {

    private bool right, left = false;
	private ScoreTime theScoreManager;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreTime> ();

	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (right == true)
            {
                // do nothing
            }
            else
            {
                left = true;
            }        
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (left == true)
            {
                // do nothing
            }
            else
            {
                right = true;
            }           
        }

        if (right)
        {
            //transform.Rotate(0, 0, -45);
            //right = false;
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, transform.localEulerAngles + Vector3.forward * -45, Time.deltaTime * 5.05f);
            Invoke("ResetAll", 0.2f);
        }
        else if (left)
        {
            //transform.Rotate(0, 0, 45);
            //left = false;
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, transform.localEulerAngles + Vector3.forward * 45, Time.deltaTime * 5.05f);
            Invoke("ResetAll", 0.2f);
        }
    }

    void ResetAll()
    {
		theScoreManager.scoreIncreasing = false;

        if (Mathf.Abs(transform.localEulerAngles.z % 45) > 0 && right)
        {
            transform.localEulerAngles -= Vector3.forward * (transform.localEulerAngles.z % 45 - 45);
        }
        else if (Mathf.Abs(transform.localEulerAngles.z % 45) > 0 && left)
        {
            transform.localEulerAngles -= Vector3.forward * (transform.localEulerAngles.z % 45);
        }
        right = false;
        left = false;

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
    }
}
