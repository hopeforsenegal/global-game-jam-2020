﻿
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjectData/Settings", order = 1)]
public class Settings : ScriptableObject
{
    [Header("Music")]
    public AudioClip playerWonScreenMusicTrack;
    public AudioClip mainMenuMusicTrack;
    public AudioClip backgroundMusicTrack;

    [Header("Player SFX")]
    public AudioClip playerWallBlock;
    public AudioClip playerThroughWall;
    public AudioClip playerAttackMelee;
    public AudioClip playerAttackProjectile;
    public AudioClip playerPowerUp;
    public AudioClip playerDash;
    public AudioClip playerJump;
    public AudioClip playerMove;
    public AudioClip playerDie;
    public AudioClip playerRespawn;

    [Header("Enemy SFX")]
    public AudioClip enemyAttackMelee;
    public AudioClip enemyAttackProjectile;
    public AudioClip enemyHurt;

    [Header("Boss SFX")]
    public AudioClip bossAttackMelee;
    public AudioClip bossAttackProjectile;
    public AudioClip bossHurt;
    public AudioClip bossLose;

    [Header("Instructions")]
    public Sprite doubleJumpImage;
    public Sprite dashJumpImage;
    public Sprite shootJumpImage;
}
