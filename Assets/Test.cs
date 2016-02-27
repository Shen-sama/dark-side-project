using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

    public Transform[] waypointArray;
    public float percentsPerSecond = 0.2f; // %2 of the path moved per second
    float currentPathPercent = 0.0f; //min 0, max 1

    float pathVelocity;
    float pathLength = 0;

    void Start()
    {
        pathLength = iTween.PathLength(waypointArray);
        pathVelocity = pathLength * percentsPerSecond;
        Debug.Log(pathLength);
        Debug.Log(pathVelocity);
    }

    void Update()
    {
        float v = Input.GetAxis("Horizontal");
        float deltaPercent = percentsPerSecond * Time.deltaTime;
        Vector3 nextPoint = iTween.PointOnPath(waypointArray, currentPathPercent + deltaPercent);
        float calcDist = Vector3.Magnitude(nextPoint - transform.position);
        float calcVelocity = calcDist / Time.deltaTime;
        float velocityScale = pathVelocity / calcVelocity;            // if we are going at double velocity, velocityScale is 1/2; if at half vel, it's 2

        currentPathPercent += (deltaPercent * v);
        // For looping
        if (currentPathPercent > 1.0f)
            currentPathPercent -= 1.0f;
        else if (currentPathPercent < 0)
            currentPathPercent += 1.0f;

        iTween.PutOnPath(gameObject, waypointArray, currentPathPercent);
    }
}
