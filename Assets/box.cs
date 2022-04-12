using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class box : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().mass = Random.Range(1,10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
