﻿using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    #region Enums and Constants

    public enum AttackPattern
    {
        Melee,
        Projectile
    }

    #endregion

    #region Events

    public Action<AttackPattern> AttackEvent;
    public Action DieEvent;
    public Action RespawnEvent;

    public Action<Vector3> PowerUpEvent;
    public Action DashEvent;
    public Action JumpEvent;

    #endregion

    #region Properties

    #endregion

    #region Inspectables

    [SerializeField]
    private bool unlockDoubleJump = true;
    [SerializeField]
    private bool unlockDash = true;
    [SerializeField]
    private bool unlockShooting = true;



    [SerializeField]
    float jumpVelocity = 30f;

    [SerializeField]
    private float shootTimer = 20.0f;

    [SerializeField]
    private PlayerProjectile m_PlayerProjectile = default;

    [SerializeField]
    private PlayerHealthCollider m_PlayerHealthCollider = default;

    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private LayerMask wallsLayerMask;

    private bool attacking = false;
    private bool dashing = false;
    private bool shooting = false;
    public bool direction = true;
    private bool canDoubleJump;
    public bool isMoving;

    private float attackTimer = 0.0f;
    private float dashTimer = 0.0f;
    private float moveSpeed = 10;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private bool isDead;


    public GameObject meleeCollider;

    #endregion

    #region Private Member Variables

    private int m_DoubleJumpCount;
    private int m_DashCount;
    private PowerUpPiece[] m_PowerUpPieces;

    #endregion

    #region Monobehaviours

    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    protected void Start()
    {
        m_PowerUpPieces = FindObjectsOfType<PowerUpPiece>();

        foreach (var powerUp in m_PowerUpPieces) {
            if (powerUp != null) {
                powerUp.PowerUpHitEvent += OnPowerUpHit;
            }
        }

        m_PlayerHealthCollider.PlayerHitEvent += OnHit;
    }

    protected void OnDestroy()
    {
        foreach (var powerUp in m_PowerUpPieces) {
            if (powerUp != null) {
                powerUp.PowerUpHitEvent -= OnPowerUpHit;
            }
        }

        m_PlayerHealthCollider.PlayerHitEvent -= OnHit;
    }

    protected void Update()
    {
        if (isDead)
            return;

        float move = Input.GetAxis("Horizontal") * moveSpeed;

        transform.Translate(Vector3.right * (Time.deltaTime * move), Space.World);

        if (IsGrounded()) {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump")) {
            if (IsGrounded()) {
                rigidbody2d.velocity = Vector2.up * jumpVelocity;
                JumpEvent?.Invoke();
            } else if (canDoubleJump && unlockDoubleJump) {
                rigidbody2d.velocity = Vector2.up * jumpVelocity;
                canDoubleJump = false;
            }
        }

        if (attacking) {
            if (Time.time > (attackTimer + 0.3f)) {
                meleeCollider.GetComponent<BoxCollider2D>().enabled = false;
                meleeCollider.GetComponent<Renderer>().enabled = false;
                attacking = false;
            }
        }

        if (Input.GetButtonDown("Fire1") && !attacking) {
            //Debug.LogFormat("Fire1");
            attackTimer = Time.time;
            attacking = true;
            meleeCollider.GetComponent<BoxCollider2D>().enabled = true;
            meleeCollider.GetComponent<Renderer>().enabled = true;
            AttackEvent?.Invoke(AttackPattern.Melee);
        }

        if (dashing) {
            if (Time.time > (dashTimer + 1.0f)) {
                dashing = false;
            }
        }

        if (Input.GetButtonDown("Fire2") && unlockDash && !dashing && !attacking) {
            Debug.LogFormat("Fire2");
            dashTimer = Time.time;
            dashing = true;

            if (direction) {
                RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, Vector2.right, 6f, wallsLayerMask);
                if (raycastHit2d) {
                    float dashDistance = raycastHit2d.distance;
                    transform.position += new Vector3(dashDistance, 0.0f, 0.0f);
                } else {
                    transform.position += new Vector3(5.0f, 0.0f, 0.0f);
                }
            } else {
                RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, Vector2.left, 6f, wallsLayerMask);
                if (raycastHit2d) {
                    float dashDistance = raycastHit2d.distance;
                    transform.position += new Vector3(-dashDistance, 0.0f, 0.0f);
                } else {
                    transform.position += new Vector3(-5.0f, 0.0f, 0.0f);
                }
            }

            DashEvent?.Invoke();
        }

        if (shooting) {
            if (Time.time > (shootTimer + 1.0f)) {
                shooting = false;
            }
        }

        if (Input.GetButtonDown("Fire3") && unlockShooting && !shooting) {
            m_PlayerProjectile.Launch(transform.position, m_PlayerProjectile.speed, direction);
            shootTimer = Time.time;
            shooting = true;
            AttackEvent?.Invoke(AttackPattern.Projectile);
        }

        if (Input.GetKeyDown(KeyCode.D) && !direction) {
            //Debug.Log("D key was pressed.");
            direction = true;
            meleeCollider.transform.localPosition = new Vector3(0.1f, 0.01f, 0.0f);

            return;
        }

        if (Input.GetKeyDown(KeyCode.A) && direction) {
            //Debug.Log("A key was pressed.");
            direction = false;
            meleeCollider.transform.localPosition = new Vector3(-0.1f, 0.01f, 0.0f);

            return;
        }

        isMoving = Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1;
    }

    #endregion

    #region Public Methods

    public void Respawn(Vector3 location)
    {
        transform.SetPositionAndRotation(location, Quaternion.identity);
        isDead = false;
        RespawnEvent?.Invoke();
    }

    #endregion

    #region Private Methods

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.min, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        //Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }

    private void OnHit()
    {
        Debug.LogFormat("Player Hit");
        isDead = true;
        DieEvent?.Invoke();
    }

    private void OnPowerUpHit(Vector3 location, PowerUpPiece.Ability ability)
    {
        Debug.LogFormat("OnPowerUpHit:{0}", ability);
        if (ability == PowerUpPiece.Ability.DoubleJump) {
            m_DoubleJumpCount++;
            if (m_DoubleJumpCount == 4) {
                unlockDoubleJump = true;
                Debug.LogFormat("You can now double jump");
                PowerUpEvent?.Invoke(location);
            }
        }
    }

    #endregion
}
