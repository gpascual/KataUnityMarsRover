using DG.Tweening;
using UnityEngine;

namespace Infrastructure
{
    public class DotTweenAnimator : IAnimator
    {
        private readonly Transform transform;

        public DotTweenAnimator(Transform transform)
        {
            this.transform = transform;
        }

        public void Move(Vector3 destination, float duration)
        {
            transform.DOMove(destination, duration);
        }

        public void Rotate(Vector3 rotation, float duration)
        {
            transform.DORotate(rotation, duration, RotateMode.LocalAxisAdd);
        }
    }
}