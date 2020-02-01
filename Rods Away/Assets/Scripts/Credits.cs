
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Credits : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

    #endregion

    #region Properties

    #endregion

    #region Inspectables

    public Button mainMenuButton;
    public Button exitButton;

    #endregion

    #region Private Member Variables

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(mainMenuButton != null, "mainMenuButton not set");
        Debug.Assert(exitButton != null, "exitButton not set");

        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        exitButton.onClick.AddListener(ExitGame);
    }

    protected void OnDestroy()
    {
        mainMenuButton.onClick.RemoveListener(ReturnToMainMenu);
        exitButton.onClick.RemoveListener(ExitGame);
    }

    protected void Update()
    {
        var hitEnterKey = Input.GetKey(KeyCode.KeypadEnter)
            || Input.GetKey(KeyCode.Return);

        var hitEscKey = Input.GetKey(KeyCode.Escape);

        if (hitEnterKey) {
            ReturnToMainMenu();
        } else if (hitEscKey) {
            ExitGame();
        }
    }


    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("_main_menu");
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }

    #endregion
}
