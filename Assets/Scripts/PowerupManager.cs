using UnityEngine;

public class PowerupManager : MonoBehaviour {

    private ScoreManager scoreManager;
    private PlatformGenerator platformGenerator;
    private PlatformDestroyer[] spikeList;
    private GameManager gameManager;

    private bool doublePoints;
    private bool safeMode;
    private bool powerupActive;

    private float powerupLengthCounter;

    void Start () {
        scoreManager = FindObjectOfType<ScoreManager>();
        platformGenerator = FindObjectOfType<PlatformGenerator>();
        gameManager = FindObjectOfType<GameManager>();
    }

	void Update () {
        if (powerupActive)
        {
            powerupLengthCounter -= Time.deltaTime;

            if (gameManager.PowerupReset)
            {
                powerupLengthCounter = 0;
                gameManager.PowerupReset = false;
            }

            if (powerupLengthCounter > 0)
            {
                if (doublePoints)
                {
                    scoreManager.ShouldDouble = true;
                }

                if (safeMode)
                {
                    platformGenerator.ShouldCreateSpikes = false;
                }
            }
            else
            {
                powerupActive = false;
                scoreManager.ShouldDouble = false;
                platformGenerator.ShouldCreateSpikes = true;
            }
        }
	}

    public void ActivatePowerup(bool points, bool safe, float time)
    {
        doublePoints = points;
        safeMode = safe;
        powerupLengthCounter = time;

        if (safeMode)
        {
            spikeList = FindObjectsOfType<PlatformDestroyer>();

            foreach (var spike in spikeList)
            {
                if (spike.gameObject.name.Contains("spikes"))
                {
                    spike.gameObject.SetActive(false);
                }             
            }
        }

        powerupActive = true;
    }
}
