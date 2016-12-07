using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform PlatformGenerator;
    public PlayerController Player;

    private ScoreManager scoreManager;

    private Vector3 platformStartPoint;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    [UsedImplicitly]
    void Start ()
    {
        platformStartPoint = PlatformGenerator.position;
        playerStartPoint = Player.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
        scoreManager.ScoreIncreasing = false;

        Player.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        platformList = FindObjectsOfType<PlatformDestroyer>();

        foreach (var platformDestroyer in platformList)
        {
            platformDestroyer.gameObject.SetActive(false);
        }

        Player.transform.position = playerStartPoint;
        PlatformGenerator.position = platformStartPoint;

        Player.gameObject.SetActive(true);

        scoreManager.ScoreCount = 0;
        scoreManager.ScoreIncreasing = true;
    }
}
