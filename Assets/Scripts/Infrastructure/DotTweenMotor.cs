using DG.Tweening;
using Domain;
using UnityEngine;

namespace Infrastructure
{
    public class DotTweenMotor : IMotor
    {
        private readonly Transform transform;
        private readonly float duration = 1.0f;

        public DotTweenMotor(Transform transform)
        {
            this.transform = transform;
        }
        
        public void Forward(int distanceInMeters)
        {
            Vector3 targetPosition = transform.position + transform.forward * distanceInMeters;
            transform.DOMove(targetPosition, duration);
        }

        public void Turn(float angleDegrees)
        {
            transform.DORotate(new Vector3(0, angleDegrees, 0), duration, RotateMode.LocalAxisAdd);
        }
    }
}