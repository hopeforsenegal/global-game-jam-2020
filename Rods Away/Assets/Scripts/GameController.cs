
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class GameController : MonoBehaviour
{
    #region Singleton

    public static GameController Instance
    {
        get;
        private set;
    }

    public static bool TryGetInstance(out GameController controller)
    {
        controller = Instance;
        return controller != null;
    }

    #endregion

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

    #endregion

    #region Private Member Variables

    #endregion

    #region Monobehaviours

    protected void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
            return;
        }
    }

    protected void Start()
    {
        StartCoroutine(Initialize());
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

    public void NotifyBossWasDefeated()
    {
        Debug.LogFormat("You won!");
        BossDefeatedEvent?.Invoke();
        StartCoroutine(LoadSceneDelayed(5, "_credits"));
    }

    #endregion

    #region Private Methods

    private IEnumerator Initialize()
    {
        Debug.Log("Initialize");
        yield return new WaitForSeconds(0.01f);
        InitializedEvent?.Invoke();
    }

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
