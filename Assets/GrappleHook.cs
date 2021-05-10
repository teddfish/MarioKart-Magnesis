using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class GrappleHook : MonoBehaviour
{
    public float hookSpeed, maxRange;
    public PathCreator grapplePath;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //distance += hookSpeed * Time.deltaTime;
        //transform.position = grapplePath.path.GetPointAtDistance(distance);

        //transform.position = grapplePath.path.GetPointAtDistance(maxRange * hookSpeed * Time.deltaTime);
        transform.Translate(grapplePath.path.GetClosestPointOnPath(transform.position));
    }
}
