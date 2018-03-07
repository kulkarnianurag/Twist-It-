using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
public class playerMovement : MonoBehaviour {

    public float speed;

    private Rigidbody myRigidBody;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y <= -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        speed *= 1.0001f;
        if (speed >= 8.0f)
        {
            speed = 8.0f;
        }

        myRigidBody.velocity += Vector3.forward * speed * Time.deltaTime;
	}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    transform.parent = collision.transform;
    //}
}
