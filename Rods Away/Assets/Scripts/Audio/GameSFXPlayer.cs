
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

    private BossController bossController;

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(settings != null, "settings not set");

        if (AudioPlayer.TryGetInstance(out AudioPlayer audioPlayer)) {
            bossController = FindObjectOfType<BossController>();
            if (bossController != null) {
                bossController.OnDead += OnBossDead;
            }
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