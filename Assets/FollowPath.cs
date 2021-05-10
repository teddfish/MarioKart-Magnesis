using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FollowPath : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = .5f;
    public float fastpeed = 25f;
    public float timeTaken = 15f;
    float distanceTravelled;

    private void Update()
    {
        distanceTravelled += Mathf.Lerp(speed, fastpeed, timeTaken) * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}
