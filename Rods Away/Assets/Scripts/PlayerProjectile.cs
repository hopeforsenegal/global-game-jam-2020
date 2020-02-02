﻿
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerProjectile : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

    #endregion

    #region Properties

    public bool Enabled
    {
        set
        {
            enabled = value;
            m_Collider.enabled = value;
            m_Renderer.enabled = value;
        }
    }

    #endregion

    #region Inspectables

    public float speed;
    public bool moveLeft;

    [SerializeField]
    private BoxCollider2D m_Collider;

    [SerializeField]
    private Renderer m_Renderer;

    #endregion

    #region Private Member Variables

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(m_Collider != null, "m_Collider not set");
        Debug.Assert(m_Renderer != null, "m_Renderer not set");
    }

    protected void FixedUpdate()
    {
        var direction = moveLeft ? Vector3.right : Vector3.left;
        transform.Translate(direction * (Time.deltaTime * speed), Space.World);
        if (!m_Renderer.isVisible)
        {
            Enabled = false;
        }
    }

    #endregion

    #region Public Methods

    public void Launch(Vector3 location, float speed, bool moveLeft)
    {
        Debug.LogFormat("Launch");
        Enabled = true;
        transform.position = location;
        this.speed = speed;
        this.moveLeft = moveLeft;
    }

    #endregion

    #region Private Methods

    #endregion
}
