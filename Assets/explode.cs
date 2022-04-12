using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class explode : MonoBehaviour
{
    public float radius = 25;
    public float power = 250;
    public float upForce = 3;

    public AnimationCurve curve;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I exist!");
    }

    void OnCollisionEnter(Collision col) {
        Debug.Log("Boom!");
         Vector3 explosionPosition = transform.position;
         Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
         foreach(Collider hit in colliders) {
             Rigidbody rb = hit.GetComponent<Rigidbody>();

             if(rb != null) {
                 rb.AddExplosionForce(power, explosionPosition, radius, upForce);
             }
         }

         Destroy(this.gameObject);
    }
}
