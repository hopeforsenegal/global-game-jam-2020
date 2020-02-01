
using UnityEngine;

[DisallowMultipleComponent]
public class EnemyMelee : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

    #endregion

    #region Properties

    public bool Enabled
    {
        set
        {
            enabled = value;
            m_Collider.enabled = value;
            m_Renderer.enabled = value;
        }
    }

    #endregion

    #region Inspectables

    [SerializeField]
    private BoxCollider2D m_Collider = default;

    [SerializeField]
    private Renderer m_Renderer = default;

    #endregion

    #region Private Member Variables


    #endregion

    #region Monobehaviours

    protected void Start()
    {
        Debug.Assert(m_Collider != null, "m_Collider not set");
        Debug.Assert(m_Renderer != null, "m_Renderer not set");
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
