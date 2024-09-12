using UnityEngine;
using Fusion;

public struct NetworkInputData : INetworkInput
{
    public const byte MOUSEBUTTON0 = 1;

    public NetworkButtons buttons;

    public Vector2 move;
    public Vector2 look;

    public bool jump;
    public bool sprint;
}
