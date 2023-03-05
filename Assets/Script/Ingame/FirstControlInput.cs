using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class FirstControlInput : BYSingleton<FirstControlInput>
{
    public static bool isJump;
    public static bool isFire;
    public event Action<bool> OnFireEvent;
    public static bool isRun;
    public static bool isCrouch;
    public static Vector2 look;
    public static Vector2 move;
    public bool isUIControl;
    public PlayerInput playerInput;
    public bool IsCurrentDeviceMouse
    {
        get
        {
#if ENABLE_INPUT_SYSTEM

            return playerInput.currentControlScheme == "Keyboardmouse";
#else
            return false;
#endif
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerInput.enabled = !isUIControl;
    }

    // Update is called once per frame
    void Update()
    {

    }
    #region Input
    public void OnJump(InputValue inputValue)
    {

        OnJumpInput(inputValue.isPressed);
    }
    public void OnRun(InputValue inputValue)
    {

        OnRunInput(inputValue.isPressed);
    }
    public void OnCrouch(InputValue inputValue)
    {

        OnCrouchInput(inputValue.isPressed);
    }
    public void OnFire(InputValue inputValue)
    {

        OnFireInput(inputValue.isPressed);
    }
    public void OnMove(InputValue inputValue)
    {
        Vector2 val = inputValue.Get<Vector2>();
        OnMoveInput(val);
    }
    public void OnLook(InputValue inputValue)
    {
        Vector2 val = inputValue.Get<Vector2>();
        OnLookInput(val);
    }
    #endregion
    public void OnJumpInput(bool isNewJump)
    {
        isJump = isNewJump;
    }
    public void OnRunInput(bool isNewRun)
    {
        isRun = isNewRun;
    }
    public void OnCrouchInput(bool isNewCrouch)
    {
        isCrouch = isNewCrouch;
    }
    public void OnFireInput(bool isNewfire)
    {
        if (isFire != isNewfire)
        {
            OnFireEvent?.Invoke(isNewfire);
            isFire = isNewfire;

        }
    }
    public void OnLookInput(Vector2 val)
    {
        look = val;
    }
    public void OnMoveInput(Vector2 val)
    {
        move = val;
    }
    private void OnApplicationFocus(bool focus)
    {
        if (!isUIControl)
            Cursor.lockState = focus ? CursorLockMode.Locked : CursorLockMode.None;
    }

}
