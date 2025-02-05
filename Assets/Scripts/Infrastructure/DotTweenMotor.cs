using DG.Tweening;
using Domain;
using UnityEngine;

namespace Infrastructure
{
    public class DotTweenMotor : IMotor
    {
        private readonly Transform transform;
        private readonly IAnimator animator;
        private readonly float duration = 1.0f;

        public DotTweenMotor(Transform transform, IAnimator animator)
        {
            this.transform = transform;
            this.animator = animator;
        }
        
        public void Forward(int distanceInMeters)
        {
            Vector3 targetPosition = transform.position + transform.forward * distanceInMeters;
            animator.Move(targetPosition, duration);
        }

        public void Turn(float angleDegrees)
        {
            animator.Rotate(new Vector3(0,angleDegrees, 0), duration);
        }
    }
}