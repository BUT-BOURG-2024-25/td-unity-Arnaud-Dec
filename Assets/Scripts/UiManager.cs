using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager :  Singleton<UiManager>
{

    [SerializeField]
    private Joystick joystick;
    public Joystick Joystick { get { return joystick; } }

    
}
