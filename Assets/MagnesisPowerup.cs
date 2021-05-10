using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnesisPowerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(transform.rotation.x, 5f, transform.rotation.y));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //print("detected");
            other.gameObject.GetComponent<KartControl>().magnesisOn = true;
            Destroy(this.gameObject);
        }
    }
}
