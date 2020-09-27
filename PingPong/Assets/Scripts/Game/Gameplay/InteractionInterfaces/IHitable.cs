using UnityEngine;

namespace Game.Gameplay
{
    public interface IHitable
    {

        void Hit(Vector3 point, Vector3 normal);

    }
}
