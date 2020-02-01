using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
public class Checkpoint : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

    public Action<Vector3> OnSet;

    #endregion

    #region Properties

    #endregion

    #region Inspectables

    #endregion

    #region Private Member Variables

    private BoxCollider2D m_BoxCollider;

    #endregion

    #region Monobehaviours

    private void Awake()
    {
        m_BoxCollider = GetComponent<BoxCollider2D>();

        Debug.Assert(m_BoxCollider != null);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("OnTriggerEnter");

        if (other.CompareTag("Player")) {
            Debug.LogFormat("OnTriggerEnter player");
            OnSet?.Invoke(transform.position);
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
