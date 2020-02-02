
using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyController : MonoBehaviour
{
    #region Enums and Constants

    public enum AttackPattern
    {
        Melee,
        Projectile
    }

    #endregion

    #region Events

    public Action<AttackPattern> AttackEvent;
    public Action DieEvent;

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
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
