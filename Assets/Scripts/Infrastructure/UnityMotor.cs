using Domain;
using UnityEngine;

namespace Infrastructure
{
    public class UnityMotor : IMotor
    {
        public CharacterController CharacterController { get; set; }

        public UnityMotor(CharacterController characterController)
        {
            CharacterController = characterController;
        }

        public void Forward(int distanceInMeters)
        {
            CharacterController.Move(CharacterController.transform.forward * distanceInMeters);
        }
    }
}