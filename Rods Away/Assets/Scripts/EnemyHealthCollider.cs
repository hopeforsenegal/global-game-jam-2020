using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyHealthCollider : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

    public Action HitEvent;

    #endregion

    #region Properties

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

    protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.rigidbody.CompareTag("PlayerProjectile")) {
            other.gameObject.GetComponentInParent<PlayerProjectile>().Enabled = false;
            HitEvent?.Invoke();
        }
    }
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
