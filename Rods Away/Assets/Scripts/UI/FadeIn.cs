
using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(FadeCanvasGroup))]
public class FadeIn : MonoBehaviour
{
	#region Enums and Constants

	#endregion

	#region Events

	public event Action FadeCompleteEvent
	{
		add
		{
			lock (m_EventLock) {
				m_FadeCanvasGroup.FadeCompleteEvent += value;
			}
		}
		remove
		{
			lock (m_EventLock) {
				m_FadeCanvasGroup.FadeCompleteEvent -= value;
			}
		}
	}

	#endregion

	#region Properties

	#endregion

	#region Inspectables

	public Settings settings;

	#endregion

	#region Private Member Variables

	private readonly object m_EventLock = new object();

	private FadeCanvasGroup m_FadeCanvasGroup;

	#endregion

	#region Monobehaviours

	protected void Awake()
	{
		m_FadeCanvasGroup = GetComponent<FadeCanvasGroup>();

		Debug.Assert(m_FadeCanvasGroup != null);
	}

	protected void Start()
	{
		m_FadeCanvasGroup.Fade(1f, 0f, 1);
	}

	#endregion

	#region Public Methods

	#endregion

	#region Private Methods

	#endregion
}