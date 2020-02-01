using System;
using UnityEngine;

[DisallowMultipleComponent]
public class BossController : MonoBehaviour
{
    #region Enums and Constants

    public enum Attack
    {
        Melee,
        Projectile
    }

    #endregion

    #region Events

    public Action OnDead;

    #endregion

    #region Properties

    #endregion

    #region Inspectables

    [SerializeField]
    private float attackTimer = 2.0f;

    [SerializeField]
    private EnemyMelee m_EnemyMelee = default;

    [SerializeField]
    private EnemyProjectile m_EnemyProjectile = default;

    #endregion

    #region Private Member Variables

    private float m_CurrentTimer;

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(m_EnemyMelee != null, "m_EnemyMelee not set");
        Debug.Assert(m_EnemyProjectile != null, "m_EnemyProjectile not set");

        m_CurrentTimer = Time.time;

        m_EnemyMelee.Enabled = false;
        m_EnemyProjectile.Enabled = false;
    }

    protected void Update()
    {
        if (m_CurrentTimer + attackTimer <= Time.time) {
            m_CurrentTimer = Time.time;
            Debug.LogFormat("Interval");
            m_EnemyMelee.Enabled = true;
            m_EnemyProjectile.Enabled = true;
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
