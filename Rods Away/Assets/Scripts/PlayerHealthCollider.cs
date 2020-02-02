using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerHealthCollider : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

    public Action PlayerHitEvent;

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
        //Debug.LogFormat("PlayerHealthCollider OnCollisionEnter2D tag:{0}", other.gameObject.tag);

        if (other.gameObject.CompareTag("EnemyProjectile")) {
            other.gameObject.GetComponentInParent<EnemyProjectile>().Enabled = false;
            //Debug.LogFormat("PlayerHealthCollider OnCollisionEnter2D enemy projectile");
            PlayerHitEvent?.Invoke();
        } else if (other.gameObject.CompareTag("Enemy")) {
            //Debug.LogFormat("PlayerHealthCollider OnCollisionEnter2D enemy");
            PlayerHitEvent?.Invoke();
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
