
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class GameController : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

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

        playerController.OnDead += OnDeadPlayer;
        bossController.OnDead += OnDeadBoss;
    }

    protected void OnDestroy()
    {
        playerController.OnDead -= OnDeadPlayer;
        bossController.OnDead -= OnDeadBoss;
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("_main_menu");
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void OnDeadBoss()
    {
        Debug.LogFormat("You won!");
        SceneManager.LoadScene("_credits");
    }

    private void OnDeadPlayer()
    {
        Debug.LogFormat("You died!");
        SceneManager.LoadScene("_credits");
    }

    #endregion
}
