using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject Platform;
    public Transform GenerationPoint;
    public ObjectPooler[] ObjectPools;
    public ObjectPooler SpikePool;
    public ObjectPooler PowerupPool;
    public Transform maxHeightPoint;

    private CoinGenerator coinGenerator;

    public float DistanceBetween;
    public float DistanceBetweenMin;
    public float DistanceBetweenMax;
    public float MaxHeightChange;
    public float RandomCoingThreshold;
    public float RandomSpikeThreshold;
    public float RandomPowerupThreshold;
    public float PowerupHeight;
    public bool ShouldCreateSpikes;

    private float platformWidth;
    private int platformSelector;
    private float minPlatformHeight;
    private float maxPlatformHeight;
    private float heightChange;
    private float[] plaformWidths;

    void Start () {
        coinGenerator = FindObjectOfType<CoinGenerator>();

        plaformWidths = new float[ObjectPools.Length];

        for (int i = 0; i < ObjectPools.Length; i++)
        {
            plaformWidths[i] = ObjectPools[i].PoolObject.GetComponent<BoxCollider2D>().size.x;
        }

        minPlatformHeight = transform.position.y;
        maxPlatformHeight = maxHeightPoint.position.y;

        ShouldCreateSpikes = true;
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

            if (Random.Range(0, 100f) < RandomPowerupThreshold)
            {
                var newPowerup = PowerupPool.GetPooledObject();

                newPowerup.transform.position = transform.position + new Vector3(DistanceBetween / 2, Random.Range(PowerupHeight / 2, PowerupHeight), 0f);
                newPowerup.transform.rotation = transform.rotation;

                newPowerup.SetActive(true);
            }

            var newPlatform = ObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if(Random.Range(0, 100f) < RandomCoingThreshold)
            {
                coinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z));
            }

            if ((Random.Range(0, 100f) < RandomSpikeThreshold) && ShouldCreateSpikes)
            {
                var newSpike = SpikePool.GetPooledObject();
                var spikeXPosition = Random.Range(-plaformWidths[platformSelector] / 2f + 1f, plaformWidths[platformSelector] / 2f - 1f);
                var spikePosition = new Vector3(spikeXPosition, 0.5f, 0f);

                newSpike.transform.position = transform.position + spikePosition;
                newSpike.transform.rotation = transform.rotation;

                newSpike.SetActive(true);
            }

            transform.position = new Vector3(transform.position.x + (plaformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
    }
}
