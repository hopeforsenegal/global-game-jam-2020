using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsUI : MonoBehaviour
{
    public Image image;
    public PlayerController playerController;
    public Settings settings;

    protected void Start()
    {
        image.enabled = false;
        playerController.PowerUpEvent += OnPlayerPowerUp;
    }

    protected void OnDestroy()
    {
        playerController.PowerUpEvent -= OnPlayerPowerUp;
    }

    private void OnPlayerPowerUp(Vector3 _, PowerUpPiece.Ability ability)
    {
        Sprite sprite = null;
        if (ability == PowerUpPiece.Ability.DoubleJump) {
            sprite = settings.doubleJumpImage;
        } else if (ability == PowerUpPiece.Ability.Dash) {
            sprite = settings.dashJumpImage;
        } else if (ability == PowerUpPiece.Ability.Shooting) {
            sprite = settings.shootJumpImage;
        }

        if (sprite != null) {
            image.enabled = true;
            image.sprite = sprite;
            StartCoroutine(RemoveImage());
        }
    }


    private IEnumerator RemoveImage()
    {
        yield return new WaitForSeconds(5f);
        image.enabled = false;
    }
}
