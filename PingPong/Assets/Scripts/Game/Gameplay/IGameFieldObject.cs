using System.Collections;
using System.Collections.Generic;
using Game.Gameplay;
using UnityEngine;

public interface IGameFieldObject : IBouncable, IBoundedObject
{
   
    void OnOut();
    void OnGameFieldReset();

}
