
using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerProjectileCollider : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

    public Action HitWallEvent;

    #endregion

    #region Properties

    public bool Enabled
    {
        set
        {
            enabled = value;
            m_BoxCollider.enabled = value;
        }
    }

    #endregion

    #region Inspectables

    #endregion

    #region Private Member Variables

    private BoxCollider2D m_BoxCollider;

    #endregion

    #region Monobehaviours

    private void Awake()
    {
        m_BoxCollider = GetComponent<BoxCollider2D>();

        Debug.Assert(m_BoxCollider != null);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("EnemyWall")) {
            Debug.LogFormat("PlayerProjectileCollider OnCollisionEnter2D wall");
            HitWallEvent?.Invoke();
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
