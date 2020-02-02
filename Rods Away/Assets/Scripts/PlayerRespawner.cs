
using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(PlayerController))]
public class PlayerRespawner : MonoBehaviour
{
    #region Enums and Constants

    #endregion

    #region Events

    #endregion

    #region Properties

    #endregion

    #region Inspectables

    [SerializeField]
    private GameController m_GameController = default;

    #endregion

    #region Private Member Variables

    private PlayerController m_PlayerController;
    private Vector3 m_LastSpawnLocation;

    #endregion

    #region Monobehaviours

    private void Awake()
    {
        m_PlayerController = GetComponent<PlayerController>();

        Debug.Assert(m_PlayerController != null);
    }

    protected void Start()
    {
        Debug.Assert(m_GameController != null, "m_GameController not set");

        m_LastSpawnLocation = m_PlayerController.transform.position;
        m_PlayerController.PowerUpEvent += UpdateCheckPoint;
        m_GameController.PlayerDefeatedEvent += OnPlayerDefeated;
    }

    protected void OnDestroy()
    {
        m_GameController.PlayerDefeatedEvent -= OnPlayerDefeated;
        m_PlayerController.PowerUpEvent -= UpdateCheckPoint;
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            Respawn();
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void OnPlayerDefeated()
    {
        Respawn();
    }

    private void Respawn()
    {
        m_PlayerController.Respawn(m_LastSpawnLocation);
    }

    private void UpdateCheckPoint(Vector3 location, PowerUpPiece.Ability __)
    {
        m_LastSpawnLocation = location;
    }

    #endregion
}
