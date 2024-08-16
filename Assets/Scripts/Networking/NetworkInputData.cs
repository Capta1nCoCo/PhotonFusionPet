using UnityEngine;
using Fusion;

public struct NetworkInputData : INetworkInput
{
    public Vector2 move;
    public Vector2 look;
    public bool jump;
    public bool sprint;
}
