
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

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(m_PlayerController != null, "m_PlayerController not set");
        Debug.Assert(m_PlayerAnimator != null, "m_PlayerAnimator not set");

        m_PlayerAnimator.Idle();

        m_CurrentTimer = Time.time;

        m_PlayerController.AttackEvent += OnAttack;
        m_PlayerController.DashEvent += OnDash;
        m_PlayerController.DieEvent += OnDie;
        m_PlayerController.JumpEvent += OnJump;
        m_PlayerController.MoveEvent += OnMove;
        m_PlayerController.PowerUpEvent += OnPowerUp;
    }

    protected void OnDestroy()
    {
        m_PlayerController.AttackEvent -= OnAttack;
        m_PlayerController.DashEvent -= OnDash;
        m_PlayerController.DieEvent -= OnDie;
        m_PlayerController.JumpEvent -= OnJump;
        m_PlayerController.MoveEvent -= OnMove;
        m_PlayerController.PowerUpEvent -= OnPowerUp;
    }

    protected void Update()
    {
        if (m_CurrentTimer + idleTimer <= Time.time) {
            m_CurrentTimer = Time.time;
            m_PlayerAnimator.Idle();
            return;
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
        m_PlayerAnimator.Die();
        m_CurrentTimer = Time.time;
    }

    private void OnMove()
    {
        m_PlayerAnimator.Run();
        m_CurrentTimer = Time.time;
    }

    private void OnJump()
    {
        m_PlayerAnimator.Jump();
        m_CurrentTimer = Time.time;
    }

    private void OnPowerUp()
    {
    }

    private void OnDash()
    {
    }

    #endregion
}
