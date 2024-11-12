using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{

    [SerializeField]
    private Joystick joystick;
    public Joystick Joystick { get { return joystick; } }

    public static UiManager instance { get { return _instance; } }
    private static UiManager _instance = null;


    private void Awake()
    {
        if (_instance == null)
        {

            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
