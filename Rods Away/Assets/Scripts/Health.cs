using System;
using System.Collections;
using UnityEngine;
using UnityEngine .UI;

public class Health : MonoBehaviour
{
    public Slider healthBar;
    public float health
    {
        get
        {
            return healthBar.value;
        }
        set
        {
            Debug.LogFormat("value:{0}", value);
            healthBar.value = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            health += 1;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            health -= 1;
        }
    }

    public void Viewable(bool v)
    {
        gameObject.SetActive(v);
    }
}
