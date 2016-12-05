using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject Platform;
    public Transform GenerationPoint;
    public ObjectPooler[] ObjectPools;
    public Transform maxHeightPoint;

    public float DistanceBetween;
    public float DistanceBetweenMin;
    public float DistanceBetweenMax;
    public float MaxHeightChange;

    private float platformWidth;
    private int platformSelector;
    private float minPlatformHeight;
    private float maxPlatformHeight;
    private float heightChange;
    private float[] plaformWidths;

    void Start () {
        plaformWidths = new float[ObjectPools.Length];

        for (int i = 0; i < ObjectPools.Length; i++)
        {
            plaformWidths[i] = ObjectPools[i].PoolObject.GetComponent<BoxCollider2D>().size.x;
        }

        minPlatformHeight = transform.position.y;
        maxPlatformHeight = maxHeightPoint.position.y;
    }
	
	void Update () {
		if(transform.position.x < GenerationPoint.position.x)
        {
            DistanceBetween = Random.Range(DistanceBetweenMin, DistanceBetweenMax);
            platformSelector = Random.Range(0, ObjectPools.Length);

            heightChange = transform.position.y + Random.Range(-MaxHeightChange, MaxHeightChange);

            if(heightChange > maxPlatformHeight)
            {
                heightChange = maxPlatformHeight;
            }
            else if(heightChange < minPlatformHeight)
            {
                heightChange = minPlatformHeight;
            }

            transform.position = new Vector3(transform.position.x + (plaformWidths[platformSelector] / 2) + DistanceBetween, heightChange, transform.position.z);

            var newPlatform = ObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;

            newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + (plaformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
    }
}
