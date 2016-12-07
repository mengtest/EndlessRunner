using UnityEngine;

public class PickupPoints : MonoBehaviour {

    public int ScoreToGive;

    private ScoreManager scoreManager;

	void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
	
	void Update () {
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            scoreManager.AddToScore(ScoreToGive);
            gameObject.SetActive(false);
        }       
    }
}
