using Domain;
using UnityEngine;

namespace Infrastructure
{
    public class UnityMotor : IMotor
    {
        public float speed = 0.02f;
        public CharacterController CharacterController { get; set; }

        public UnityMotor(CharacterController characterController)
        {
            CharacterController = characterController;
        }

        public void Forward(int distanceInMeters)
        {
            Vector3 targetPosition = CharacterController.transform.position + CharacterController.transform.forward * distanceInMeters;

            // Mueve el personaje suavemente hacia la nueva posición
            float elapsedTime = 0f;
            Vector3 startPosition = CharacterController.transform.position;

            while (elapsedTime < 5f)
            {
                elapsedTime += Time.deltaTime * speed;
                Vector3 newPosition = Vector3.Lerp(startPosition, targetPosition, elapsedTime);
        
                // Mueve el personaje usando CharacterController
                CharacterController.Move(newPosition - CharacterController.transform.position);

                // Aquí en una implementación real podrías controlar el flujo con un sistema de comandos sincronizados
            }
        }
    }
}