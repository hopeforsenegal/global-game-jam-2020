
using System;
using UnityEngine;

[DisallowMultipleComponent]
public class PowerUpPiece : MonoBehaviour
{
    #region Enums and Constants

    public enum Ability
    {
        DoubleJump,
        Dash,
        Shooting,
    }

    #endregion

    #region Events

    public Action<Vector3, Ability> PowerUpHitEvent;

    #endregion

    #region Properties

    public bool Enabled
    {
        set
        {
            enabled = value;
            m_PowerUpPieceCollider.Enabled = value;
            m_Renderer.enabled = value;
        }
    }

    #endregion

    #region Inspectables

    [SerializeField]
    private Ability m_Ability = default;

    [SerializeField]
    private PowerUpPieceCollider m_PowerUpPieceCollider = default;

    [SerializeField]
    private Renderer m_Renderer = default;

    #endregion

    #region Private Member Variables

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(m_PowerUpPieceCollider != null, "m_PowerUpPieceCollider not set");
        Debug.Assert(m_Renderer != null, "m_Renderer not set");

        m_PowerUpPieceCollider.PowerUpHitEvent += OnPowerUpHit;
    }

    protected void OnDestroy()
    {
        m_PowerUpPieceCollider.PowerUpHitEvent -= OnPowerUpHit;
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void OnPowerUpHit(Vector3 location)
    {
        //Debug.LogFormat("Piece of type collected: {0}", m_Ability);
        Enabled = false;
        PowerUpHitEvent?.Invoke(location, m_Ability);
    }

    #endregion
}
