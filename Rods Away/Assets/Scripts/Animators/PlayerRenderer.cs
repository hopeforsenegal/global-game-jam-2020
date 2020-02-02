
using System;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerRenderer : MonoBehaviour
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
    private PlayerController m_PlayerController = default;

    [SerializeField]
    private PlayerAnimator m_PlayerAnimator = default;

    #endregion

    #region Private Member Variables

    private float m_CurrentTimer;
    private bool m_LastDirection;

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(m_PlayerController != null, "m_PlayerController not set");
        Debug.Assert(m_PlayerAnimator != null, "m_PlayerAnimator not set");

        m_PlayerAnimator.Idle();
        m_LastDirection = m_PlayerController.direction;

        m_CurrentTimer = Time.time;

        m_PlayerController.AttackEvent += OnAttack;
        m_PlayerController.DashEvent += OnDash;
        m_PlayerController.DieEvent += OnDie;
        m_PlayerController.JumpEvent += OnJump;
        m_PlayerController.PowerUpEvent += OnPowerUp;
        m_PlayerController.RespawnEvent += OnRespawn;
    }

    protected void OnDestroy()
    {
        m_PlayerController.RespawnEvent -= OnRespawn;
        m_PlayerController.AttackEvent -= OnAttack;
        m_PlayerController.DashEvent -= OnDash;
        m_PlayerController.DieEvent -= OnDie;
        m_PlayerController.JumpEvent -= OnJump;
        m_PlayerController.PowerUpEvent -= OnPowerUp;
    }

    protected void Update()
    {
        if (m_CurrentTimer + idleTimer <= Time.time && !m_PlayerController.isMoving) {
            m_CurrentTimer = Time.time;
            m_PlayerAnimator.Idle();
            return;
        }

        if (m_PlayerController.isMoving) {
            m_PlayerAnimator.Run();
        }

        if (m_PlayerController.direction != m_LastDirection) {
            m_LastDirection = m_PlayerController.direction;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y);
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void OnAttack(PlayerController.AttackPattern attackPattern)
    {
        if (attackPattern == PlayerController.AttackPattern.Melee) {
            m_PlayerAnimator.Melee();
            m_CurrentTimer = Time.time;
        } else if (attackPattern == PlayerController.AttackPattern.Projectile) {

        }
    }

    private void OnDie()
    {
        OnDieAction(NotifyGameControllerDeadDead);
    }

    private void OnRespawn()
    {
        m_PlayerAnimator.Idle();
    }

    private void NotifyGameControllerDeadDead()
    {
        if (GameController.TryGetInstance(out GameController gameController)) {
            gameController.NotifyPlayerWasDefeated();
        }
    }

    private void OnDieAction(Action onDieAnimationComplete)
    {
        m_PlayerAnimator.Die(onDieAnimationComplete);
        m_CurrentTimer = Time.time;
    }

    private void OnJump()
    {
        m_PlayerAnimator.Jump();
        m_CurrentTimer = Time.time;
    }

    private void OnPowerUp(Vector3 location)
    {
    }

    private void OnDash()
    {
    }

    #endregion
}
