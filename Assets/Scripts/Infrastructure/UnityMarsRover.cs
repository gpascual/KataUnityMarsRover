using System;
using Domain;
using IngameDebugConsole;
using UnityEngine;

namespace Infrastructure
{
    public class UnityMarsRover : MonoBehaviour
    {
        private MarsRover marsRover;

        private void Start()
        {
            UnityMotor unityMotor = new UnityMotor(gameObject.GetComponent<CharacterController>());
            marsRover = new MarsRover(unityMotor);
            DebugLogConsole.AddCommand( "forward", "Move rover forward ", MoveForward );
        }

        private void Update()
        {
            //marsRover.MoveForward();
        }
        
        public void MoveForward()
        {
            marsRover.MoveForward();
        }
    }
}