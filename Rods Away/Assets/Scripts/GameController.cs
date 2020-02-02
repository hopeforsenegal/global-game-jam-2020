
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class GameController : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

    public Action InitializedEvent;
    public Action PlayerDefeatedEvent;
    public Action BossDefeatedEvent;
    public Action QuitEvent;

    #endregion

    #region Properties

    #endregion

    #region Inspectables

    public PlayerController playerController;
    public BossController bossController;
    public EnemyController[] enemyControllers;

    #endregion

    #region Private Member Variables

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(playerController != null, "playerController not set");
        Debug.Assert(bossController != null, "bossController not set");
        Debug.Assert(enemyControllers != null && enemyControllers.Length > 0, "enemyControllers not set");

        bossController.DieEvent += OnBossDead;

        InitializedEvent?.Invoke();
    }

    protected void OnDestroy()
    {
        bossController.DieEvent -= OnBossDead;
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            QuitGame();
        }
    }

    #endregion

    #region Public Methods

    public void NotifyPlayerWasDefeated()
    {
        Debug.LogFormat("You died!");
        PlayerDefeatedEvent?.Invoke();
    }

    public void OnBossDead()
    {
        Debug.LogFormat("You won!");
        BossDefeatedEvent?.Invoke();
        StartCoroutine(LoadSceneDelayed(5, "_credits"));
    }

    #endregion

    #region Private Methods

    private void QuitGame()
    {
        QuitEvent?.Invoke();
        SceneManager.LoadScene("_main_menu");
    }

    private IEnumerator LoadSceneDelayed(int delayed, string scenename)
    {
        yield return new WaitForSeconds(delayed);
        SceneManager.LoadScene(scenename);
    }

    #endregion
}
