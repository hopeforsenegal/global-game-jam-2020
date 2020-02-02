
using System;
using MoonlitSystem.Animators;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(StandardAnimator))]
public class BossAnimator : MonoBehaviour
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

    public void Idle()
    {
        //Debug.LogFormat("Idle");
        m_StandardAnimator.Loop(string.Empty, "idle");
    }

    public void Run()
    {
        //Debug.LogFormat("Run");
        m_StandardAnimator.Loop(string.Empty, "run1");
    }

    public void Die(Action onDieAnimationComplete)
    {
        Debug.LogFormat("Die");
        m_StandardAnimator.Play(string.Empty, "die", string.Empty, ()=> {
            m_StandardAnimator.Clear();
            onDieAnimationComplete?.Invoke();
        });
    }

    public void Jump()
    {
        Debug.LogFormat("Jump");
        m_StandardAnimator.Play(string.Empty, "jump", "idle");
    }

    public void Melee()
    {
        Debug.LogFormat("Melee");
        m_StandardAnimator.Play(string.Empty, "blast", "idle");
    }

    public void Range()
    {
        Debug.LogFormat("Range");
        m_StandardAnimator.Play(string.Empty, "arms_shoot", "idle");
    }

    #endregion

    #region Private Methods

    #endregion
}
