
using System;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemyRenderer : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

    #endregion

    #region Properties

    #endregion

    #region Inspectables

    [SerializeField]
    private float idleTimer = 0.5f;

    [SerializeField]
    private EnemyController m_EnemyController = default;

    [SerializeField]
    private EnemyAnimator m_EnemyAnimator = default;

    #endregion

    #region Private Member Variables

    private float m_CurrentTimer;
    private bool m_LastDirection;
    private bool m_Dead;

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(m_EnemyController != null, "m_EnemyController not set");
        Debug.Assert(m_EnemyAnimator != null, "m_EnemyAnimator not set");

        m_EnemyAnimator.Idle(m_EnemyController.attackType == EnemyController.AttackPattern.Projectile);

        m_CurrentTimer = Time.time;

        m_EnemyController.AttackEvent += OnAttack;
        m_EnemyController.DieEvent += OnDie;
    }

    protected void OnDestroy()
    {
        m_EnemyController.AttackEvent -= OnAttack;
        m_EnemyController.DieEvent -= OnDie;
    }

    protected void Update()
    {
        if (m_Dead)
            return;

        if (m_CurrentTimer + idleTimer <= Time.time) {
            m_CurrentTimer = Time.time;
            m_EnemyAnimator.Idle(m_EnemyController.attackType == EnemyController.AttackPattern.Projectile);
            return;
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void OnAttack(EnemyController.AttackPattern attackPattern)
    {
        if (m_Dead)
            return;

        if (attackPattern == EnemyController.AttackPattern.Melee) {
            m_EnemyAnimator.Melee();
            m_CurrentTimer = Time.time;
        } else if (attackPattern == EnemyController.AttackPattern.Projectile) {
            m_EnemyAnimator.Range();
            m_CurrentTimer = Time.time;
        }
    }

    private void OnDie()
    {
        m_Dead = true;
        OnDieAction();
    }

    private void OnDieAction()
    {
        m_EnemyAnimator.Die(m_EnemyController.attackType == EnemyController.AttackPattern.Projectile);
        m_CurrentTimer = Time.time;
    }

    #endregion
}
