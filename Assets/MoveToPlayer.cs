using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 20;

    public Transform[] points;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player);
        rb.AddForce(transform.forward * speed);
    }

    void LateUpdate() {
        // make the enemy not look up or down.
        this.transform.rotation = Quaternion.Euler(0, transform.localEulerAngles.y, 0);
    }

    void OnTriggerEnter(Collider other) {
        // if death
        SpawnEnemies.currentEnemies -= 1;
        SpawnEnemies.enemiesKilled += 1;
    }
}
