using System.Collections;
using Domain;
using UnityEngine;

namespace Infrastructure
{
    public class UnityMotor : IMotor
    {
        private readonly CharacterController characterController;
        private float moveSpeed = 5f;
        private float turnSpeed = 90f;

        public UnityMotor(CharacterController characterController)
        {
            this.characterController = characterController;
        }

        public void Forward(int distanceInMeters)
        {
            Vector3 targetPosition = characterController.transform.position + characterController.transform.forward * distanceInMeters *10;
            CoroutineRunner.Instance.RunCoroutine(MoveToTarget(targetPosition));
        }
        
        public void Turn(float angleDegrees)
        {
            CoroutineRunner.Instance.RunCoroutine(TurnToAngle(angleDegrees));
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
        
        private IEnumerator TurnToAngle(float angleDegrees)
        {
            float currentRotation = 0f;

            while (Mathf.Abs(currentRotation) < Mathf.Abs(angleDegrees))
            {
                // Calcular el ángulo a rotar en este frame
                float rotationStep = Mathf.Sign(angleDegrees) * turnSpeed * Time.deltaTime;

                // Evitar sobrepasar el ángulo objetivo
                if (Mathf.Abs(currentRotation + rotationStep) > Mathf.Abs(angleDegrees))
                {
                    rotationStep = angleDegrees - currentRotation;
                }

                // Rotar el transform del CharacterController
                characterController.transform.Rotate(0, rotationStep, 0);

                // Acumular la rotación aplicada
                currentRotation += rotationStep;

                yield return null;
            }
        }
    }
}