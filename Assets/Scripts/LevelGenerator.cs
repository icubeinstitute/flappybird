using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;

    [SerializeField]
    private float obstacleDistance = 4f;

    [SerializeField]
    private GameObject groundPrefab;

    public float ObstacleDistance
    {
        get { return obstacleDistance; }
    }

    public float NextObstaclePos
    {
        get;
        set;
    }

    public float NextGroundPos
    {
        get;
        set;
    }

    void Start()
    {
        NextObstaclePos = 0;

        for (int i = 0; i < 6; i++)
        {
            GameObject obst = Instantiate(obstaclePrefab, transform);
            obst.GetComponent<Obstacle>().PrepareObstacle();
        }

        NextGroundPos = -8f;
        for (int i = 0; i < 6; i++)
        {
            GameObject ground = Instantiate(groundPrefab, transform);
            ground.GetComponent<Ground>().PrepareGround();
        }
    }
}
