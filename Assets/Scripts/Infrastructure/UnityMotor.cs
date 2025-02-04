using System.Collections;
using Domain;
using UnityEngine;

namespace Infrastructure
{
    public class UnityMotor : IMotor
    {
        private readonly CharacterController characterController;
        private float moveSpeed = 5f;

        public UnityMotor(CharacterController characterController)
        {
            this.characterController = characterController;
        }

        public void Forward(int distanceInMeters)
        {
            Vector3 targetPosition = characterController.transform.position + characterController.transform.forward * distanceInMeters;
            CoroutineRunner.Instance.RunCoroutine(MoveToTarget(targetPosition));
        }

        private IEnumerator MoveToTarget(Vector3 targetPosition)
        {
            while (Vector3.Distance(characterController.transform.position, targetPosition) > 0.01f)
            {
                Vector3 nextPosition =  Vector3.MoveTowards(characterController.transform.position, targetPosition, moveSpeed * Time.deltaTime);
                
                Vector3 direction = nextPosition - characterController.transform.position;
                characterController.Move(direction);

                yield return null;
            }
            
            characterController.transform.position = targetPosition;
        }
    }
}