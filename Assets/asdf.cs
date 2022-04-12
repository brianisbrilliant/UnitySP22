using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdf : MonoBehaviour
{
    public float moveDelay = 5f;
    bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToMove());
    }

    IEnumerator WaitToMove() {
        canMove = false;
        yield return new WaitForSeconds(moveDelay);
        canMove = true;
    }
}
