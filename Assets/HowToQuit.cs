// using platform directives to specify what code to compile.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToQuit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            // https://docs.unity3d.com/Manual/PlatformDependentCompilation.html
            #if UNITY_STANDALONE_WIN
                Application.Quit();
            #endif
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}
