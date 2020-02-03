
using System;
using UnityEngine;

[DisallowMultipleComponent]
public class BossRenderer : MonoBehaviour
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
    private BossController m_BossController = default;

    [SerializeField]
    private BossAnimator m_BossAnimator = default;

    #endregion

    #region Private Member Variables

    private float m_CurrentTimer;
    private bool m_LastDirection;
    private bool m_Dead;

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(m_BossController != null, "m_BossController not set");
        Debug.Assert(m_BossAnimator != null, "m_BossAnimator not set");

        m_BossAnimator.Idle();

        m_CurrentTimer = Time.time;

        m_BossController.AttackEvent += OnAttack;
        m_BossController.DieEvent += OnDie;
    }

    protected void OnDestroy()
    {
        m_BossController.AttackEvent -= OnAttack;
        m_BossController.DieEvent -= OnDie;
    }

    protected void Update()
    {
        if (m_Dead)
            return;

        if (m_CurrentTimer + idleTimer <= Time.time) {
            m_CurrentTimer = Time.time;
            m_BossAnimator.Idle();
            return;
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void OnAttack(BossController.AttackPattern attackPattern)
    {
        if (m_Dead)
            return;

        if (attackPattern == BossController.AttackPattern.Melee) {
            m_BossAnimator.Melee();
            m_CurrentTimer = Time.time;
        } else if (attackPattern == BossController.AttackPattern.Projectile) {
            m_BossAnimator.Range();
            m_CurrentTimer = Time.time;
        }
    }

    private void OnDie()
    {
        m_Dead = true;
        OnDieAction(NotifyGameControllerDeadDead);
    }

    private void NotifyGameControllerDeadDead()
    {
        if (GameController.TryGetInstance(out GameController gameController)) {
            gameController.NotifyBossWasDefeated();
        }
    }

    private void OnDieAction(Action onDieAnimationComplete)
    {
        m_BossAnimator.Die(onDieAnimationComplete);
        m_CurrentTimer = Time.time;
    }

    #endregion
}
