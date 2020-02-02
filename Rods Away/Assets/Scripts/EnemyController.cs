
using System;
using UnityEngine;

[DisallowMultipleComponent]
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

    public AttackPattern attackType = default;

    [SerializeField]
    private float attackTimer = 3.0f;

    [SerializeField]
    private float meleeTimer = 0.5f;

    [SerializeField]
    private EnemyHealthCollider m_EnemyHealthCollider = default;

    [SerializeField]
    private EnemyMelee m_EnemyMelee = default;

    [SerializeField]
    private EnemyProjectile m_EnemyProjectile = default;

    #endregion

    #region Private Member Variables

    private float m_CurrentTimer;
    private Vector3 m_ProjectileStartLocation;

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(m_EnemyHealthCollider != null, "m_EnemyHealthCollider not set");
        Debug.Assert(m_EnemyMelee != null, "m_EnemyMelee not set");
        Debug.Assert(m_EnemyProjectile != null, "m_EnemyProjectile not set");

        m_CurrentTimer = Time.time;
        m_ProjectileStartLocation = m_EnemyProjectile.transform.position;

        m_EnemyMelee.Enabled = false;
        m_EnemyProjectile.Enabled = false;

        m_EnemyHealthCollider.HitEvent += OnHit;
    }

    protected void Update()
    {
        if (m_CurrentTimer + attackTimer <= Time.time) {
            m_CurrentTimer = Time.time;
            Attack();
            return;
        }

        if (m_CurrentTimer + meleeTimer <= Time.time && m_EnemyMelee.enabled) {
            m_CurrentTimer = Time.time;
            m_EnemyMelee.Enabled = false;
            return;
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void Attack()
    {
        switch (attackType) {
            case AttackPattern.Melee:
                m_EnemyMelee.Launch(m_ProjectileStartLocation, m_EnemyMelee.speed, m_EnemyMelee.moveLeft);
                break;
            case AttackPattern.Projectile:
                m_EnemyProjectile.Launch(m_ProjectileStartLocation, m_EnemyProjectile.speed, m_EnemyProjectile.moveLeft);
                break;
            default:
                break;
        }
        AttackEvent?.Invoke(attackType);
    }

    private void OnHit()
    {
        gameObject.SetActive(false);
        DieEvent?.Invoke();
    }

    #endregion
}
