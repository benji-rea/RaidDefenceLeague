using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public static Transform[] points; //Let's this be referenced where ever in the scene.

    void Awake () //Array builder
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
