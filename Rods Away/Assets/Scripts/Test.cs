
using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float speed = 5;

    protected void Update()
    {
    	float move = Input.GetAxis("Horizontal") * speed;
        
        transform.Translate(Vector3.right * (Time.deltaTime * move), Space.World);
        
        Debug.LogFormat("move:{0}", move);
    }
}

