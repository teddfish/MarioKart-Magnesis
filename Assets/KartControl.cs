using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartControl : MonoBehaviour
{
    public Rigidbody rbSphere;

    public GameObject magnet, theBullet;

    public float forwardAcc = 5f, reverseAcc = 2f, maxSpeed = 10f, turnIntensity = 70f;

    public float accInput, turnInput;

    public bool magnesisOn;

    // Start is called before the first frame update
    void Start()
    {
        rbSphere.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        accInput = 0f;
        if (Input.GetAxis("Vertical") > 0)
        {
            accInput = Input.GetAxis("Vertical") * forwardAcc * 10;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            accInput = Input.GetAxis("Vertical") * reverseAcc * 10;
        }

        turnInput = Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + 
                             new Vector3(0f, turnInput * turnIntensity * Input.GetAxis("Vertical") * Time.deltaTime, 0f));

        transform.position = rbSphere.transform.position;

        //print(magnesisOn);

        //if magnesis gets turned on
        //spawn an object right in front of our car 
        //have it shoot projectiles when pressed space 
        //that projectile should follow the path curve

        if (magnesisOn)
        {
            magnet.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(theBullet, magnet.transform.position, Quaternion.identity);

            }
        }
        else if (!magnesisOn)
        {
            magnet.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(accInput) > 0)
        {
            rbSphere.AddForce(transform.forward * accInput);
        }

    }

}
