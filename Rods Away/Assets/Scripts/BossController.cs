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

    #endregion

    #region Private Member Variables

    private float m_CurrentTimer;

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        m_CurrentTimer = Time.time;
    }

    protected void Update()
    {
        if (m_CurrentTimer + attackTimer <= Time.time) {
            m_CurrentTimer = Time.time;
            Debug.LogFormat("Interval");
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
