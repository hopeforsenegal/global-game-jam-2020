using System;
using UnityEngine;

[DisallowMultipleComponent]
public class BossController : MonoBehaviour
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
    public Action HurtEvent;
    public Action DieEvent;

    #endregion

    #region Properties

    #endregion

    #region Inspectables

    [SerializeField]
    private int health = 100;

    [SerializeField]
    private float attackTimer = 3.0f;

    [SerializeField]
    private float meleeTimer = 0.5f;

    [SerializeField]
    private Health m_Health = default;

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
    private int m_CurrentHealth;
    private bool isDead;

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(m_EnemyHealthCollider != null, "m_EnemyHealthCollider not set");
        Debug.Assert(m_EnemyMelee != null, "m_EnemyMelee not set");
        Debug.Assert(m_EnemyProjectile != null, "m_EnemyProjectile not set");

        m_CurrentTimer = Time.time;
        m_ProjectileStartLocation = m_EnemyProjectile.transform.position;
        m_CurrentHealth = health;

        m_EnemyMelee.Enabled = false;
        m_EnemyProjectile.Enabled = false;

        m_Health.Viewable(false);

        m_EnemyHealthCollider.HitEvent += OnHit;
    }

    protected void Update()
    {
        if (isDead)
            return;

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
        var attackPattern = RandomAttackPattern();
        //Debug.LogFormat("Attacked: {0}", attackPattern);
        switch (attackPattern) {
            case AttackPattern.Melee:
                m_EnemyMelee.Enabled = true;
                break;
            case AttackPattern.Projectile:
                m_EnemyProjectile.Launch(m_ProjectileStartLocation, m_EnemyProjectile.speed, m_EnemyProjectile.moveLeft);
                break;
            default:
                break;
        }
        AttackEvent?.Invoke(attackPattern);
    }

    private AttackPattern RandomAttackPattern()
    {
        Array values = Enum.GetValues(typeof(AttackPattern));
        System.Random random = new System.Random();
        return (AttackPattern)values.GetValue(random.Next(values.Length));
    }

    private void OnHit()
    {
        Debug.LogFormat("Boss was hit when health was {0}", m_CurrentHealth);

        m_CurrentHealth -= 10;
        if (m_CurrentHealth <= 0) {
            if (isDead)
                return;
            isDead = true;
            m_Health.Viewable(false);
            DieEvent?.Invoke();
            m_EnemyHealthCollider.HitEvent -= OnHit;
        } else {
            m_Health.Viewable(true);
            m_Health.health = m_CurrentHealth;
            HurtEvent?.Invoke();
        }
    }

    #endregion
}
