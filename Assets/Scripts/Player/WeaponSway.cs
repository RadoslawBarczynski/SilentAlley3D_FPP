using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class WeaponSway : MonoBehaviour
{
    [Header("Sway Settings")]
    [SerializeField] float rotateSpeed = 4f;
    [SerializeField] float maxTurn = 3f;
    //[SerializeField] private InputManager inputManager;
    public PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;


    private void OnEnable()
    {
        playerInput = new PlayerInput();
        playerInput.Enable();
    }
    void Update()
    {
        //Vector2 mouseInput = inputManager.onFoot.Look.ReadValue<Vector2>();
        Vector2 mouseInput = playerInput.OnFoot.MouseSway.ReadValue<Vector2>();

        ApplyRotation(GetRotation(mouseInput));
    }

    Quaternion GetRotation(Vector2 mouse)
    {
        mouse = Vector2.ClampMagnitude(mouse, maxTurn);

        Quaternion rotX = Quaternion.AngleAxis(-mouse.y, Vector3.right);
        Quaternion rotY = Quaternion.AngleAxis(mouse.x, Vector3.up);

        Quaternion targetRot = rotX * rotY;

        return targetRot;
    }

    void ApplyRotation(Quaternion targetRot)
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, rotateSpeed * Time.deltaTime);
    }



}
