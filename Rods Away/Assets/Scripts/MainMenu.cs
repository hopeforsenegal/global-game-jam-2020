
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class MainMenu : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

    #endregion

    #region Properties

    #endregion

    #region Inspectables

    public Button playButton;
    public Button exitButton;

    #endregion

    #region Private Member Variables

    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(playButton != null, "playButton not set");
        Debug.Assert(exitButton != null, "exitButton not set");

        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    protected void OnDestroy()
    {
        playButton.onClick.RemoveListener(PlayGame);
        exitButton.onClick.RemoveListener(ExitGame);
    }

    protected void Update()
    {
        var hitEnterKey = Input.GetKey(KeyCode.KeypadEnter)
            || Input.GetKey(KeyCode.Return);

        var hitEscKey = Input.GetKey(KeyCode.Escape);

        if (hitEnterKey) {
            PlayGame();
        } else if (hitEscKey) {
            ExitGame();
        }
    }


    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void PlayGame()
    {
        SceneManager.LoadScene("_game");
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
