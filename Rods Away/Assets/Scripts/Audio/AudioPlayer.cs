using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public class AudioPlayer : MonoBehaviour
{
	#region Singleton

	public static AudioPlayer Instance
	{
		get;
		private set;
	}

	public static bool TryGetInstance(out AudioPlayer controller)
	{
		controller = Instance;
		return controller != null;
	}

	#endregion

	#region Enums and Constants

	#endregion

	#region Events

	#endregion

	#region Properties

	#endregion

	#region Inspectables

	#endregion

	#region Private Member Variables

	private AudioSource[] m_AudioSources;

	#endregion

	#region Monobehaviours

	protected void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);
	}

	protected void Start()
	{
		m_AudioSources = GetComponents<AudioSource>();
	}

	protected void Update()
	{
	}

	protected void OnEnable()
	{
	}

	protected void OnDisable()
	{
	}

	protected void OnDestroy()
	{
		if (Instance != this)
			return;
		Instance = null;
	}

	#endregion

	#region Public Methods

	#endregion

	#region Private Methods

	public void PlayMusic(AudioClip audio)
	{
		if (m_AudioSources != null && m_AudioSources.Length > 0)
		{
			if (m_AudioSources[0].clip != audio)
			{
				m_AudioSources[0].clip = audio;
				m_AudioSources[0].Play();
            } else {
				Debug.LogFormat("No Audio");
			}
        } else {
			Debug.LogFormat("No Audio");
        }
	}

	public void PlaySound(AudioClip audio)
	{
		bool soundPlayed = false;
		foreach (AudioSource source in m_AudioSources)
		{
			if (!source.isPlaying)
			{
				source.clip = audio;
				source.Play();
				soundPlayed = true;
				break;
			}
		}
		if (!soundPlayed)
		{
			if (m_AudioSources != null && m_AudioSources.Length > 0)
			{
				m_AudioSources[1].clip = audio;
				m_AudioSources[1].Play();
			} else {
				Debug.LogFormat("No Audio");
			}
		}
	}

	public void PlaySoundDelay(AudioClip[] audio, float delay)
	{
		int n = Random.Range(0, audio.Length);
		PlaySoundDelay(audio[n], delay);
	}

	public void PlaySoundDelay(AudioClip audio, float delay)
	{
		StartCoroutine(SoundPlaying(audio, delay));
	}

	private IEnumerator SoundPlaying(AudioClip audio, float delay)
	{
		yield return new WaitForSeconds(delay);
		PlaySound(audio);
	}
	#endregion
}