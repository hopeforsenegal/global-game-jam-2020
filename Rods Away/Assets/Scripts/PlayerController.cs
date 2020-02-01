using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    public Action OnDead;

    private BoxCollider2D boxCollider;
    public GameObject meleeCollider;
    public float speed = 5;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed;

        transform.Translate(Vector3.right * (Time.deltaTime * move), Space.World);

        meleeCollider.GetComponent<BoxCollider2D>().enabled = false;
        meleeCollider.GetComponent<Renderer>().enabled = false;

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.LogFormat("Fire1");
            meleeCollider.GetComponent<BoxCollider2D>().enabled = true;
            meleeCollider.GetComponent<Renderer>().enabled = true;
        }
        
        //Debug.LogFormat("move:{0}", move);
    }
}
        