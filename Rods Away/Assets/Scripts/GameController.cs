
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    public BossController bossController;
    public EnemyController[] enemyControllers;

    protected void Start()
    {
        Debug.Assert(playerController != null, "playerController not set");
        Debug.Assert(bossController != null, "bossController not set");
        Debug.Assert(enemyControllers != null && enemyControllers.Length > 0, "enemyControllers not set");

        bossController.OnDead += OnDeadBoss;
    }

    protected void OnDestroy()
    {
        bossController.OnDead -= OnDeadBoss;
    }

    private void OnDeadBoss()
    {
        Debug.LogFormat("You won!");
        SceneManager.LoadScene("_credits");
    }
}
