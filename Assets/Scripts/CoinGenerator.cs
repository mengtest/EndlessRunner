using UnityEngine;

public class CoinGenerator : MonoBehaviour {

    public ObjectPooler CoinPool;

    public float DistanceBetweenCoins;

    public void SpawnCoins(Vector3 startPosition)
    {
        var coinOne = CoinPool.GetPooledObject();
        coinOne.transform.position = startPosition;
        coinOne.SetActive(true);

        var coinTwo = CoinPool.GetPooledObject();
        coinTwo.transform.position = new Vector3(startPosition.x - DistanceBetweenCoins, startPosition.y, startPosition.z);
        coinTwo.SetActive(true);

        var coinThree = CoinPool.GetPooledObject();
        coinThree.transform.position = new Vector3(startPosition.x + DistanceBetweenCoins, startPosition.y, startPosition.z); ;
        coinThree.SetActive(true);
    }
}
