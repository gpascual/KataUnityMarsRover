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
            DotTweenMotor unityMotor = new DotTweenMotor(gameObject.GetComponent<Transform>());
            marsRover = new MarsRover(unityMotor);
            DebugLogConsole.AddCommand( "forward", "Move rover forward ", MoveForward );
            DebugLogConsole.AddCommand( "left", "Turn rover left ", TurnLeft );
            DebugLogConsole.AddCommand( "right", "Turn rover right ", TurnRight );
        }
        
        public void MoveForward()
        {
            marsRover.MoveForward();
            Debug.Log("1:0:E");
        }

        public void TurnLeft()
        {
            marsRover.TurnLeft();
        }
        
        public void TurnRight()
        {
            marsRover.TurnRight();
        }
    }
}