
using UnityEngine;

[DisallowMultipleComponent]
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
    private GameController m_GameController;
    private PlayerController m_PlayerController;

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(settings != null, "settings not set");

        m_GameController = FindObjectOfType<GameController>();
        if (m_GameController != null) {
            m_GameController.PlayerDefeatedEvent += OnPlayerDefeatedEvent;
            m_GameController.BossDefeatedEvent += OnBossDefeatedEvent;
        }
        m_BossController = FindObjectOfType<BossController>();
        if (m_BossController != null) {
            m_BossController.AttackEvent += OnBossAttack;
        }
    }

    protected void OnDestroy()
    {
        if (m_BossController != null) {
            m_BossController.AttackEvent -= OnBossAttack;
        }
        if (m_GameController != null) {
            m_GameController.PlayerDefeatedEvent -= OnPlayerDefeatedEvent;
            m_GameController.BossDefeatedEvent -= OnBossDefeatedEvent;
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void OnBossAttack(BossController.AttackPattern attackPattern)
    {
        if (attackPattern == BossController.AttackPattern.Melee) {
            PlayAudio(settings.bossAttackMelee);
        } else if(attackPattern == BossController.AttackPattern.Projectile) {
            PlayAudio(settings.bossAttackProjectile);
        }
    }

    private void OnBossDefeatedEvent()
    {
        PlayAudio(settings.bossLose);
    }

    private void OnPlayerDefeatedEvent()
    {
        PlayAudio(settings.bossWins);
    }

    private void PlayAudio(AudioClip audioClip)
    {
        if (AudioPlayer.TryGetInstance(out AudioPlayer audioPlayer)) {
            audioPlayer.PlaySound(audioClip);
        }
    }

    #endregion
}