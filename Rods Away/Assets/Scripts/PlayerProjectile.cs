
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerProjectile : MonoBehaviour
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
            m_Collider.Enabled = value;
            m_Renderer.enabled = value;
        }
    }

    #endregion

    #region Inspectables

    public float speed;
    public bool moveLeft;

    [SerializeField]
    private PlayerProjectileCollider m_Collider = default;

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

        m_Collider.HitWallEvent += OnHitWall;
    }

    protected void OnDestroy()
    {
        m_Collider.HitWallEvent -= OnHitWall;
    }

    protected void FixedUpdate()
    {
        var direction = moveLeft ? Vector3.right : Vector3.left;
        transform.Translate(direction * (Time.deltaTime * speed), Space.World);
        if (!m_Renderer.isVisible) {
            Enabled = false;
        }
    }

    #endregion

    #region Public Methods

    public void Launch(Vector3 location, float speed, bool moveLeft)
    {
      //  Debug.LogFormat("Launch");
        Enabled = true;
        transform.position = location;
        this.speed = speed;
        this.moveLeft = moveLeft;
    }

    #endregion

    #region Private Methods

    private void OnHitWall()
    {
        Enabled = false;
    }

    #endregion
}
