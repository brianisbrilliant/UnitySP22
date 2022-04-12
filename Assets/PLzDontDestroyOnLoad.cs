// tag this object as 'GameManager' and anything that is a child of it will not get destroyed.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLzDontDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
