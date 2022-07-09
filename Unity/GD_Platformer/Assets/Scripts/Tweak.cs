using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tweak : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator cameraAnimation;
    [SerializeField] TextMeshProUGUI playerSpeedValue;
    [SerializeField] TextMeshProUGUI playerStrengthValue;
    [SerializeField] TextMeshProUGUI playerWeightValue;
    [SerializeField] TextMeshProUGUI cameraSpeedValue;


    [SerializeField] private float f;

    private Rigidbody playerRigidbody;


    void Start() {
        playerRigidbody = player.GetComponent<Rigidbody>();
        playerSpeedValue.text = player.GetComponent<PlayerMovement>().playerSpeed.ToString();
        playerStrengthValue.text = player.GetComponent<PlayerMovement>().playerStrength.ToString();
        playerWeightValue.text = playerRigidbody.mass.ToString();
        cameraSpeedValue.text = cameraAnimation.speed.ToString();
    }

    public void PlusMinus(string t) {
        switch(t) {
            case "playerSpeedPlus":
                player.GetComponent<PlayerMovement>().playerSpeed += f;
                playerSpeedValue.text = player.GetComponent<PlayerMovement>().playerSpeed.ToString();
                break;
            case "playerSpeedMinus":
                player.GetComponent<PlayerMovement>().playerSpeed -= f;
                playerSpeedValue.text = player.GetComponent<PlayerMovement>().playerSpeed.ToString();
                break;
            case "playerStrengthPlus":
                player.GetComponent<PlayerMovement>().playerStrength += f;
                playerStrengthValue.text = player.GetComponent<PlayerMovement>().playerStrength.ToString();
                break;
            case "playerStrengthMinus":
                player.GetComponent<PlayerMovement>().playerStrength -= f;
                playerStrengthValue.text = player.GetComponent<PlayerMovement>().playerStrength.ToString();
                break;
            case "playerWeightPlus":
                playerRigidbody.mass += f;
                playerWeightValue.text = playerRigidbody.mass.ToString();
                break;
            case "playerWeightMinus":
                playerRigidbody.mass -= f;
                playerWeightValue.text = playerRigidbody.mass.ToString();
                break;
            case "cameraSpeedPlus":
                cameraAnimation.speed += f;
                cameraSpeedValue.text = cameraAnimation.speed.ToString();
                break;
            case "cameraSpeedMinus":
                cameraAnimation.speed -= f;
                cameraSpeedValue.text = cameraAnimation.speed.ToString();
                break;
        }
    }
}
