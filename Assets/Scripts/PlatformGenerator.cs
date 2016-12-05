using JetBrains.Annotations;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject Platform;
    public GameObject[] Platforms;
    public Transform GenerationPoint;
    public ObjectPooler ObjectPool;

    public float DistanceBetween;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    
    private float platformWidth;
    private int platformSelector;
    private float[] plaformWidths;

    [UsedImplicitly]
    void Start () {
        plaformWidths = new float[Platforms.Length];

        for (int i = 0; i < Platforms.Length; i++)
        {
            plaformWidths[i] = Platforms[i].GetComponent<BoxCollider2D>().size.x;
        }
    }
	
    [UsedImplicitly]
	void Update () {
		if(transform.position.x < GenerationPoint.position.x)
        {
            DistanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, Platforms.Length);

            transform.position = new Vector3(transform.position.x + plaformWidths[platformSelector] + DistanceBetween, transform.position.y, transform.position.z);

            Instantiate(Platforms[platformSelector], transform.position, transform.rotation);
            //var newPlatform = ObjectPool.GetPooledObject();

            //newPlatform.transform.position = transform.position;
            //newPlatform.transform.rotation = transform.rotation;

            //newPlatform.SetActive(true);
        }
    }
}
