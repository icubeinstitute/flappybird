using System.Collections;
using UnityEngine;

public class Ground : MonoBehaviour
{
    float groundSizeX;
    LevelGenerator levelGenerator;
    private void Awake()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
        groundSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(MoveForward());
        
    }

    IEnumerator MoveForward()
    {
        yield return new WaitForSeconds(3f);
        PrepareGround();
       
        
    }

    public void PrepareGround()
    {
        transform.localPosition = new Vector3(levelGenerator.NextGroundPos, transform.position.y, 0f);
        levelGenerator.NextGroundPos += groundSizeX;
    }
}
