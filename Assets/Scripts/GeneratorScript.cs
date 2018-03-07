using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour {

    public Transform generatorPoint;
    public Transform[] generators;
    public Transform tile;
    public Transform loopParent;

    private Transform instantiatedLoop;
    private float skippedTile;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    // Use this for initialization
    void Start () {

        originalPosition = generators[0].position;
        originalRotation = generators[0].rotation;

	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.z <= generatorPoint.position.z)
        {
            //Makes some random holes in the tube
            skippedTile = Random.Range(0, generators.Length);

  
            for(byte i = 0; i < generators.Length; i++)
            {
                if(i == skippedTile)
                {
                    skippedTile += 2;
                    continue;
                }

                //instantiatedLoop = (Transform)Instantiate(tile, generators[i].position, generators[i].rotation);
                instantiatedLoop = (Transform)Instantiate(tile, generators[i].position, generators[i].rotation);
                instantiatedLoop.parent = loopParent;               
            }

            transform.position = transform.position + (Vector3.forward * 2.7f);
        }
	}
}
