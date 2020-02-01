
using UnityEngine;

[DisallowMultipleComponent]
public class GameMusicPlayer : MonoBehaviour
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

	private GameController m_GameController;

    #endregion

    #region Monobehaviours

    protected void Start()
    {
		var gameController = FindObjectOfType<GameController>();
        if(gameController != null) {
			gameController.InitializedEvent += OnGameInitialized;
			gameController.BossDefeatedEvent += OnGameOver;
		}
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void OnGameInitialized()
    {
		Debug.LogFormat("OnGameInitialized");
		PlayAudio(settings.backgroundMusicTrack);
    }

    private void OnGameOver()
	{
		PlayAudio(settings.playerWonScreenMusicTrack);
	}

	private void PlayAudio(AudioClip audioClip)
	{
		if (AudioPlayer.TryGetInstance(out AudioPlayer audioPlayer)) {
			audioPlayer.PlayMusic(audioClip);
		}
	}

	#endregion
}