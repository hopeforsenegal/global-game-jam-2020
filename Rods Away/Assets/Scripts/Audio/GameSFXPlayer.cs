
using UnityEngine;

public class GameSFXPlayer : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

    #endregion

    #region Properties

    #endregion

    #region Inspectables

    public Settings settings;

    #endregion

    #region Private Member Variables

    private BossController m_BossController;

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(settings != null, "settings not set");

        m_BossController = FindObjectOfType<BossController>();
        if (m_BossController != null) {
            m_BossController.OnDead += OnBossDead;
        }
    }

    protected void OnDestroy()
    {
        if (m_BossController != null) {
            m_BossController.OnDead -= OnBossDead;
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void OnBossDead()
    {
        PlayAudio(settings.bossLose);
    }

    private void PlayAudio(AudioClip audioClip)
    {
        if (AudioPlayer.TryGetInstance(out AudioPlayer audioPlayer)) {
            audioPlayer.PlaySound(audioClip);
        }
    }

    #endregion
}