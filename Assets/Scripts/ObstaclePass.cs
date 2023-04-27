using System.Collections;
using TMPro;
using UnityEngine;

public class ObstaclePass : MonoBehaviour
{
    [SerializeField]
    AudioClip pointAudioClip;

    AudioSource audios;
    PointManager pointManager;
    private void Awake()
    {
        audios = GetComponent<AudioSource>();
        pointManager = FindObjectOfType<PointManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlaySound();

        if(pointManager != null)
        {
            pointManager.AddPoint();
        }
        StartCoroutine(ShiftObstacleForward());
    }

    void PlaySound()
    {
        audios.clip = pointAudioClip;
        audios.Play();
    }

    IEnumerator ShiftObstacleForward()
    {
        yield return new WaitForSeconds(1.3f);
        GetComponentInParent<Obstacle>().PrepareObstacle();
    }
}
