
using System;
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
    private EnemyController[] m_EnemyControllers;

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(settings != null, "settings not set");

        m_GameController = FindObjectOfType<GameController>();
        if (m_GameController != null) {
            m_GameController.PlayerDefeatedEvent += OnPlayerRespawn;
        }
        m_BossController = FindObjectOfType<BossController>();
        if (m_BossController != null) {
            m_BossController.AttackEvent += OnBossAttack;
            m_BossController.HurtEvent += OnBossHurt;
            m_BossController.DieEvent += OnBossDie;
        }
        m_EnemyControllers = FindObjectsOfType<EnemyController>();
        if (m_EnemyControllers != null) {
            foreach (var enemy in m_EnemyControllers) {
                if (enemy != null) {
                    enemy.AttackEvent += OnEnemyAttack;
                    enemy.DieEvent += OnEnemyDie;
                }
            }
        }
        m_PlayerController = FindObjectOfType<PlayerController>();
        if (m_PlayerController != null) {
            m_PlayerController.AttackEvent += OnPlayerAttack;
            m_PlayerController.PowerUpEvent += OnPlayerPowerUp;
            m_PlayerController.DieEvent += OnDie;
            m_PlayerController.DashEvent += OnPlayerDash;
            m_PlayerController.JumpEvent += OnPlayerJump;
        }
    }

    protected void OnDestroy()
    {
        if (m_EnemyControllers != null) {
            foreach (var enemy in m_EnemyControllers) {
                if (enemy != null) {
                    enemy.AttackEvent -= OnEnemyAttack;
                    enemy.DieEvent -= OnEnemyDie;
                }
            }
        }
        if (m_BossController != null) {
            m_BossController.AttackEvent -= OnBossAttack;
            m_BossController.HurtEvent -= OnBossHurt;
            m_BossController.DieEvent -= OnBossDie;
        }
        if (m_GameController != null) {
            m_GameController.PlayerDefeatedEvent -= OnPlayerRespawn;
        }
        if (m_PlayerController != null) {
            m_PlayerController.AttackEvent -= OnPlayerAttack;
            m_PlayerController.PowerUpEvent -= OnPlayerPowerUp;
            m_PlayerController.DashEvent -= OnPlayerDash;
            m_PlayerController.DieEvent -= OnDie;
            m_PlayerController.JumpEvent -= OnPlayerJump;
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
        } else if (attackPattern == BossController.AttackPattern.Projectile) {
            PlayAudio(settings.bossAttackProjectile);
        }
    }

    private void OnBossHurt()
    {
        PlayAudio(settings.bossHurt);
    }

    private void OnBossDie()
    {
        PlayAudio(settings.bossLose, true);
    }

    private void OnPlayerRespawn()
    {
        PlayAudio(settings.playerRespawn);
    }

    private void OnDie()
    {
        PlayAudio(settings.playerDie);
    }

    private void OnEnemyDie()
    {
        PlayAudio(settings.enemyHurt);
    }

    private void OnEnemyAttack(EnemyController.AttackPattern attackPattern)
    {
        if (attackPattern == EnemyController.AttackPattern.Melee) {
            PlayAudio(settings.enemyAttackMelee);
        } else if (attackPattern == EnemyController.AttackPattern.Projectile) {
            PlayAudio(settings.enemyAttackProjectile);
        }
    }

    private void OnPlayerAttack(PlayerController.AttackPattern attackPattern)
    {
        if (attackPattern == PlayerController.AttackPattern.Melee) {
            PlayAudio(settings.playerAttackMelee);
        } else if (attackPattern == PlayerController.AttackPattern.Projectile) {
            PlayAudio(settings.playerAttackProjectile);
        }
    }

    private void OnPlayerPowerUp(Vector3 location)
    {
        PlayAudio(settings.playerPowerUp);
    }

    private void OnPlayerDash()
    {
        PlayAudio(settings.playerDash);
    }

    private void OnPlayerJump()
    {
        PlayAudio(settings.playerJump);
    }


    private void PlayAudio(AudioClip audioClip, bool overrideAudio = false)
    {
        if (AudioPlayer.TryGetInstance(out AudioPlayer audioPlayer)) {
            audioPlayer.PlaySound(audioClip, overrideAudio);
        }
    }

    #endregion
}