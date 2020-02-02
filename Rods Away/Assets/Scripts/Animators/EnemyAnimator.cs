
using System;
using MoonlitSystem.Animators;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(StandardAnimator))]
public class EnemyAnimator : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

    #endregion

    #region Properties

    #endregion

    #region Inspectables

    #endregion

    #region Private Member Variables

    private StandardAnimator m_StandardAnimator;

    #endregion

    #region Monobehaviours

    private void Awake()
    {
        m_StandardAnimator = GetComponent<StandardAnimator>();

        Debug.Assert(m_StandardAnimator != null);
    }

    #endregion

    #region Public Methods

    public void Idle(bool hasGun)
    {
        //Debug.LogFormat("Idle");
        m_StandardAnimator.Loop(string.Empty, hasGun ? "idle_gun" : "idle_nogun");
    }

    public void Run()
    {
        //Debug.LogFormat("Run");
        m_StandardAnimator.Loop(string.Empty, "run1");
    }

    public void Die(bool hasGun, Action onDieAnimationComplete = null)
    {
        Debug.LogFormat("Enemy Die");
        m_StandardAnimator.Play(string.Empty, hasGun ? "death_gun" : "death_nogun", string.Empty, () =>
        {
            m_StandardAnimator.Clear();
            onDieAnimationComplete?.Invoke();
        });
    }

    public void Jump()
    {
        Debug.LogFormat("Boss Jump");
        m_StandardAnimator.Play(string.Empty, "jump", "idle");
    }

    public void Melee()
    {
        //Debug.LogFormat("Boss Melee");
        m_StandardAnimator.Play(string.Empty, "wave", "idle_nogun");
    }

    public void Range()
    {
        //Debug.LogFormat("Boss Range");
        m_StandardAnimator.Play(string.Empty, "shoot", "idle_gun");
    }

    #endregion

    #region Private Methods

    #endregion
}
