using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Namer : MonoBehaviour
{
	public string theName = "travis";

    // Start is called before the first frame update
    void Start()
    {
    	Debug.LogFormat("Hello World {0}", theName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
