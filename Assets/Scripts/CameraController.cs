using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

    public Transform player;

    private KeyCode exit;

	// Use this for initialization
	void Start () {
        exit = KeyCode.Escape;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(exit))
        {
            SceneManager.LoadScene("MenuScene");
        }

	}

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z - 3.5f);
    }
}
