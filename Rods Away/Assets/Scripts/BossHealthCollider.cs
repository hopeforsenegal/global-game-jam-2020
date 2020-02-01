using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
public class BossHealthCollider : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("BossHealthCollider OnTriggerEnter");

        if (other.CompareTag("PlayerProjectile")) {
            Debug.LogFormat("OnTriggerEnter player projectile");
            HitEvent?.Invoke();
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
