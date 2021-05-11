using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class GrappleHook : MonoBehaviour
{
    public float hookSpeed, maxRange;
    public PathCreator grapplePath;
    float distance;

    public GameObject enemy;
    Rigidbody rb;

    public float boostSpeed = 7f, boostTurnIntensity = 100f, slowdownSpeed = 5f;
    public float normalPlayerSpeed = 5f, normalTurnIntensity = 70, normalEnemySpeed = 10f;

    float lifeOfObject = 2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        //distance += hookSpeed * Time.deltaTime;
        //transform.position = grapplePath.path.GetPointAtDistance(distance);

        //transform.position = grapplePath.path.GetPointAtDistance(maxRange * hookSpeed * Time.deltaTime);
        //Vector3 point = grapplePath.path.GetClosestPointOnPath(transform.position);
        //Vector3 nextPoint = grapplePath.path.GetPointAtDistance(-distance);
        //rb.MovePosition(grapplePath.path.GetDirection(10f));
        //print(nextPoint);
        Vector3 pos = Vector3.MoveTowards(transform.position, enemy.transform.position, 100f * Time.deltaTime);
        rb.MovePosition(pos);

        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            //print("detected");
            GameObject.FindGameObjectWithTag("Player").GetComponent<KartControl>().forwardAcc = boostSpeed;
            GameObject.FindGameObjectWithTag("Player").GetComponent<KartControl>().turnIntensity = boostTurnIntensity;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<FollowPath>().speed = slowdownSpeed;
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<FollowPath>().smo.Play();
        }
    }

    private void OnDestroy()
    {
        //print("back to normal");
        GameObject.FindGameObjectWithTag("Player").GetComponent<KartControl>().magnesisOn = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<KartControl>().forwardAcc = normalPlayerSpeed;
        GameObject.FindGameObjectWithTag("Player").GetComponent<KartControl>().turnIntensity = normalTurnIntensity;
        GameObject.FindGameObjectWithTag("Enemy").GetComponent<FollowPath>().speed = normalEnemySpeed;
    }
}
