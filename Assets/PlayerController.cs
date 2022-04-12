using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;      // for changing scenes

public class PlayerController : MonoBehaviour
{
    public GameObject lastTouchedItem;
    public Text text;
    public int totalKeys = 0;
    public float speed = 10;

    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = speed * Time.deltaTime;
        float y = speed * Time.deltaTime;
        rb.AddForce(Input.GetAxis("Horizontal") * x, 0, Input.GetAxis("Vertical") * y);
        
        if(Input.GetKeyDown(KeyCode.Alpha9)){
            // put this in your "interact with door" code
            SceneManager.LoadScene(1);          // use the name of the scene or the build index in File > Build Settings...
        }

        if(lastTouchedItem != null) {
            if(Input.GetKeyDown(KeyCode.E)) {
                Interact();
            }
        }
    }

    bool shelf2InOrder = false;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("item")) {
            lastTouchedItem = other.gameObject;
        }

        if(other.gameObject.CompareTag("shelf1")) {
            lastTouchedItem = other.gameObject;
        }

        if(other.gameObject.CompareTag("shelf2")) {
            if(lastTouchedItem.CompareTag("shelf1")) {
                lastTouchedItem = other.gameObject;
                shelf2InOrder = true;
            }
            else {
                Debug.Log("Wrong order!");
            }
        }

        if(other.gameObject.CompareTag("shelf3")) {
            if(lastTouchedItem.CompareTag("shelf2")) {
                if(shelf2InOrder) {
                    lastTouchedItem = other.gameObject;
                    // the combination is correct!
                }
                else {
                    Debug.Log("Wrong order!");
                }
            }
            else {
                Debug.Log("Wrong order!");
            }
        }

        
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Item")) {
            lastTouchedItem = null;
        }
    }

    void Interact() {
        // add holding item code here.

        if(lastTouchedItem.CompareTag("Key")) {
            Destroy(lastTouchedItem);
            lastTouchedItem = null;
            totalKeys += 1;
        }
        if(lastTouchedItem.CompareTag("Door")) {
            if(totalKeys > 0) {
                totalKeys -= 1;
                // open door
                Destroy(lastTouchedItem);
                lastTouchedItem = null;
            }
        }   
    }
}
