using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static CustomInput;
using System;

[CreateAssetMenu(fileName = "Input Channel", menuName = "Channels/Input Channel", order = 0)]

public class InputChannel : ScriptableObject, IPlayerActions
{

  CustomInput _customInput;

  private void OnEnable()
  {
    if (_customInput == null)
    {
        _customInput = new CustomInput();
        _customInput.Player.SetCallbacks(this);
        _customInput.Enable();
    }
  }

  public  Action<Vector2> MoveEvent; // we add using System; not working without it

  public void OnMove(InputAction.CallbackContext context)
  {
    MoveEvent?.Invoke(context.ReadValue<Vector2>());
  }
}
