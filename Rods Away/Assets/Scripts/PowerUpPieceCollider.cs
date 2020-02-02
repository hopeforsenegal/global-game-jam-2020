
using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
public class PowerUpPieceCollider : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

    public Action<Vector3> PowerUpHitEvent;

    #endregion

    #region Properties

    public bool Enabled
    {
        set
        {
            enabled = value;
            m_BoxCollider.enabled = value;
        }
    }

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

        m_BoxCollider.isTrigger = true;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.LogFormat("PowerUpPieceCollider OnTriggerEnter2D tag:{0}", other.gameObject.tag);

        if (other.gameObject.CompareTag("Player")) {
            //Debug.LogFormat("PowerUpPieceCollider OnTriggerEnter2D player");
            PowerUpHitEvent?.Invoke(transform.position);
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
