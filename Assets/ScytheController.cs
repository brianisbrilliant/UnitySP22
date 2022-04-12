using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheController : MonoBehaviour
{

    public Vector3 startPos;
    public Transform target;            // this is the player
    public float throwDuration;
    public AnimationCurve curveOut, curveIn;
    public bool debug = false;


    bool throwing = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {       // replace this with whatever you're using to start the throw.
            ThrowScythe();
        }
    }

    public void ThrowScythe() {
        if(!throwing) StartCoroutine(Throw());
    }

    IEnumerator Throw(){
        throwing = true;
        startPos = this.transform.position;
        float timeElapsed = 0;
        float distance = Vector3.Distance(transform.position, target.position);

        throwDuration = distance * .25f;
        if(throwDuration < 1) throwDuration = 1;

        if(debug) Debug.Log("Distance: " + distance + ", throw duration: " + throwDuration);

        while(timeElapsed < throwDuration) {
            this.transform.position = Vector3.Lerp(startPos, target.position, curveOut.Evaluate(timeElapsed));
            timeElapsed += Time.deltaTime;
            if(Vector3.Distance(transform.position, target.position) < 0.02f) break;
            yield return new WaitForEndOfFrame();
        }

        timeElapsed = 0;

        while(timeElapsed < throwDuration) {
            this.transform.position = Vector3.Lerp(target.position, startPos, curveIn.Evaluate(timeElapsed));
            timeElapsed += Time.deltaTime;
            if(Vector3.Distance(transform.position, startPos) < 0.1f) break;
            yield return new WaitForEndOfFrame();
        }

        throwing = false;
    }
}
