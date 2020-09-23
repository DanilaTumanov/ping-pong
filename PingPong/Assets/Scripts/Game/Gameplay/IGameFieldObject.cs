using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameFieldObject : IBouncable
{

    Vector3 Position { get; }
    Bounds Bounds { get; }
    
    void OnOut();
    void OnGameFieldReset();

}
