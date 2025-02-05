using UnityEngine;

namespace Infrastructure
{
    public interface IAnimator
    {
        void Move(Vector3 destination, float duration);
        void Rotate(Vector3 rotation, float duration);
    }
}