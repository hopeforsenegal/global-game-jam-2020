﻿
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjectData/Settings", order = 1)]
public class Settings : ScriptableObject
{
    [Header("Music")]
    public AudioClip gameOver;
    public AudioClip playerWonScreen;
    public AudioClip mainMenu;
    public AudioClip backgroundMusic;

    [Header("Player SFX")]
    public AudioClip playerWallBlock;
    public AudioClip playerThroughWall;
    public AudioClip playerAttackMelee;
    public AudioClip playerAttackRanged;
    public AudioClip playerPowerUp;
    public AudioClip playerDash;
    public AudioClip playerJump;
    public AudioClip playerMove;

    [Header("Enemy SFX")]
    public AudioClip enemyAttackMelee;
    public AudioClip enemyAttackRanged;

    [Header("Boss SFX")]
    public AudioClip bossAttackMelee;
    public AudioClip bossAttackRanged;
    public AudioClip bossHurt;
    public AudioClip bossWins;
    public AudioClip bossLose;
}