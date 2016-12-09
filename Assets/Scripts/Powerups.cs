using UnityEngine;

public class Powerups : MonoBehaviour {

    public Sprite[] PowerupSprites;

    public bool DoublePoints;
    public bool SafeMode;

    public float PowerUpLength;

    private PowerupManager powerupManager;

    void Awake()
    {
        var powerupSelector = Random.Range(0, 2);

        switch (powerupSelector)
        {
            case 0:
                DoublePoints = true;
                break;

            case 1:
                SafeMode = true;
                break;
        }

        GetComponent<SpriteRenderer>().sprite = PowerupSprites[powerupSelector];
    }

    void Start () {
        powerupManager = FindObjectOfType<PowerupManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Equals("Player"))
        {
            powerupManager.ActivatePowerup(DoublePoints, SafeMode, PowerUpLength);
        }

        gameObject.SetActive(false);
    }
}
