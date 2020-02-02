
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

	[SerializeField]
	private GameController m_GameController;

	#endregion

	#region Private Member Variables

	#endregion

	#region Monobehaviours

	protected void Start()
    {
        if(m_GameController == null) {
			m_GameController = FindObjectOfType<GameController>();
		}
		m_GameController.InitializedEvent += OnGameInitialized;
		m_GameController.BossDefeatedEvent += OnGameOver;
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