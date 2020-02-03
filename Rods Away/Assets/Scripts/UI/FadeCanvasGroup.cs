using System;
using UnityEngine;

[DisallowMultipleComponent]
public class FadeCanvasGroup : MonoBehaviour
{
	#region Enums and Constants

	#endregion

	#region Events

	public event Action FadeCompleteEvent;

	#endregion

	#region Properties

	#endregion

	#region Inspectables

	[Tooltip("The canvas group to deal with")]
	public CanvasGroup canvasGroup;

	#endregion

	#region Private Member Variables

	private float m_StartTime;
	private float m_Duration;
	private float m_StartAlpha;
	private float m_EndAlpha;
	private bool m_IsActive;

	#endregion

	#region Monobehaviours

	protected void Update()
	{
		if (!m_IsActive)
			return;

		var elapsedTime = Time.time - m_StartTime; // update the elapsed time
		if (elapsedTime <= m_Duration) {
			var percentage = 1 / (m_Duration / elapsedTime); // calculate how far along the timeline we are
			if (m_StartAlpha > m_EndAlpha) {
				canvasGroup.alpha = m_StartAlpha - percentage; // calculate the new alpha
			} else {
				canvasGroup.alpha = m_StartAlpha + percentage; // calculate the new alpha
			}
		} else {
			canvasGroup.alpha = m_EndAlpha;
			m_IsActive = false;
			var invokeEvent = FadeCompleteEvent;
			if (invokeEvent != null) {
				invokeEvent();
			}
		}
	}

	#endregion

	#region Public Methods

	public void Fade(float startAlpha, float endAlpha, float duration = 1f)
	{
		CheckCanvasGroup();
		FadeVisibilty(startAlpha, endAlpha, duration);
		m_IsActive = true;
	}

	public void UpdateInteractable(bool interactable)
	{
		CheckCanvasGroup();
		canvasGroup.interactable = interactable;
		canvasGroup.blocksRaycasts = interactable;
	}

	#endregion

	#region Private Methods

	private void CheckCanvasGroup()
	{
		if (canvasGroup == null) {
			canvasGroup = GetComponent<CanvasGroup>();
		}

		Debug.Assert(canvasGroup != null);
	}

	private void FadeVisibilty(float startAlpha, float endAlpha, float duration = 1f)
	{
		m_StartTime = Time.time;
		m_Duration = duration;
		m_StartAlpha = startAlpha;
		m_EndAlpha = endAlpha;
	}

	#endregion
}