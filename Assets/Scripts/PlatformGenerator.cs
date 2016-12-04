using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject Platform;
    public Transform GenerationPoint;
    public float DistanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    private float platformWidth;
    
    void Start () {
        platformWidth = Platform.GetComponent<BoxCollider2D>().size.x;
	}
	

	void Update () {
		if(transform.position.x < GenerationPoint.position.x)
        {
            DistanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            transform.position = new Vector3(transform.position.x + platformWidth + DistanceBetween, transform.position.y, transform.position.z);
        }

        Instantiate(Platform, transform.position, transform.rotation);
	}
}
