using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private Transform[] obstacles;

    LevelGenerator levelGenerator;
    void Awake()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
    }


    public void PrepareObstacle()
    {
        float randDistance = Random.Range(4.2f, 4.9f);
        obstacles[0].transform.localPosition = new Vector3(0f, randDistance, 0f);
        obstacles[1].transform.localPosition = new Vector3(0f, -randDistance, 0f);

        float randHeight = Random.Range(0.3f, 2.7f);
        levelGenerator.NextObstaclePos += levelGenerator.ObstacleDistance;
        transform.localPosition = new Vector3(levelGenerator.NextObstaclePos, randHeight, 0f);
    }
}
