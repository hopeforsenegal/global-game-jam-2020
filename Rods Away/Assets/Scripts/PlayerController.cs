using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    public Action OnDead;

    private BoxCollider2D boxCollider;
    private bool attacking = false;
    private bool direction = true;
    private float attackTimer = 0.0f;
    public GameObject meleeCollider;
    public float speed = 5;

    private Checkpoint[] checkpoints;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        foreach (var checkpoint in checkpoints) {
            if (checkpoint != null) {
                checkpoint.OnSet += UpdateCheckPoint;
            }
        }
    }

    protected void OnDestroy()
    {
        foreach (var checkpoint in checkpoints) {
            if (checkpoint != null) {
                checkpoint.OnSet -= UpdateCheckPoint;
            }
        }
    }

    protected void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed;

        transform.Translate(Vector3.right * (Time.deltaTime * move), Space.World);

        if (attacking)
        {
            if (Time.time > (attackTimer + 0.3f))
            {
                meleeCollider.GetComponent<BoxCollider2D>().enabled = false;
                meleeCollider.GetComponent<Renderer>().enabled = false;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.LogFormat("Fire1");
            attackTimer = Time.time;
            attacking = true;
            meleeCollider.GetComponent<BoxCollider2D>().enabled = true;
            meleeCollider.GetComponent<Renderer>().enabled = true;
        }

        if (move > 0.1f)
        { 
            if (direction = false)
            {
                //Debug.LogFormat("Right");
                direction = true;
                meleeCollider.transform.localPosition = new Vector3(0.1f, 0.01f, 0.0f);
            }
        }
        if (move < 0.1f);
        {
            if (direction = true)
            {
                //Debug.LogFormat("Left");
                direction = false;
                meleeCollider.transform.localPosition = new Vector3(-0.1f, 0.01f, 0.0f);
            }
        }

        Debug.LogFormat("move:{0}", move);
    }

    private void UpdateCheckPoint(Vector3 location)
    {

    }
}
        