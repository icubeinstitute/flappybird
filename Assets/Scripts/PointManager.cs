using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{

    [SerializeField]
    private TMP_Text txtPoints;

    int points = 0;

    public void AddPoint()
    {
        points++;
        txtPoints.text = points.ToString();
    }
}
