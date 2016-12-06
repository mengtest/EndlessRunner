using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform PlatformGenerator;
    public PlayerController Player;

    private Vector3 platformStartPoint;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    [UsedImplicitly]
    void Start ()
    {
        platformStartPoint = PlatformGenerator.position;
        playerStartPoint = Player.transform.position;
    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    public IEnumerator RestartGameCo()
    {
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
    }
}
