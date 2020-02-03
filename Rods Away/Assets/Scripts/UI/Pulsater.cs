using System;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Pulsater : MonoBehaviour
{
	#region Enums and Constants

	#endregion

	#region Events

	#endregion

	#region Properties

	#endregion

	#region Inspectables

	public Color a;
	public Color b;

	#endregion

	#region Private Member Variables

	private Renderer m_Renderer;


	#endregion

	#region Monobehaviours

	protected void Awake()
	{
		m_Renderer = GetComponent<Renderer>();
		Debug.Assert(m_Renderer != null);
	}

	protected void Update()
	{
		m_Renderer.material.color = Color.Lerp(a, b, Mathf.PingPong(Time.time, 1));
	}

    protected void OnDisable()
	{
		m_Renderer.material.color = a;

	}

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}