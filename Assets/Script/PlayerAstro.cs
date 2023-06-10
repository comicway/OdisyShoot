using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAstro : MonoBehaviour
{

    //Player Data
    [SerializeField] private PlayerData playerData;

    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.visible = !hasFocus;
        Cursor.lockState = hasFocus ? CursorLockMode.None : CursorLockMode.Confined;
    }
    private void Rotate(Vector2 scrollDelta)
    {
        transform.Rotate(Vector3.up, scrollDelta.x * playerData.rotationSpeed * Time.deltaTime, Space.Self);
    }

    private Vector2 GetRotationInput()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        return new Vector2(mouseX, mouseY);
    }
    private Vector3 GetMovementInput()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        return new Vector3(horizontal, 0, vertical).normalized;
    }
    private void Move(Vector3 inputMovement)
    {
        var transform1 = transform;
        transform1.position += (inputMovement.z * transform1.forward + inputMovement.x * transform1.right) *
                               (playerData.speed * Time.deltaTime);
        //harryAnimator.SetFloat(Speed, p_inputMovement.magnitude);
    }
    void Update()
    {
        //GameManager.Instance.Moving(playerData.speed);
        Move(GetMovementInput());
        Rotate(GetRotationInput());
    }
}
