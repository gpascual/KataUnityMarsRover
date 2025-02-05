using System.Collections.Generic;
using DG.Tweening;
using Domain;
using IngameDebugConsole;
using UnityEngine;

namespace Infrastructure
{
    public class UnityMarsRover : MonoBehaviour
    {
        private MarsRover marsRover;
        public List<GameObject> roverWheels = new List<GameObject>();
        public new Transform transform;

        private void Start()
        {
            DotTweenMotor unityMotor = new DotTweenMotor(transform, new DotTweenAnimator(transform));
            marsRover = new MarsRover(unityMotor);
            DebugLogConsole.AddCommand( "forward", "Move rover forward ", MoveForward );
            DebugLogConsole.AddCommand( "left", "Turn rover left ", TurnLeft );
            DebugLogConsole.AddCommand( "right", "Turn rover right ", TurnRight );
        }
        
        public void MoveForward()
        {
            SpinWheels();
            marsRover.MoveForward();
            Debug.Log("1:0:E");
        }

        public void TurnLeft()
        {
            SpinWheels();
            marsRover.TurnLeft();
        }

        public void TurnRight()
        {
            SpinWheels();
            marsRover.TurnRight();
        }

        private void SpinWheels()
        {
            foreach (GameObject roverWheel in roverWheels)
            {
                roverWheel.transform.DOKill();
                
                roverWheel.transform.DOLocalRotate(new Vector3(360f, 0, 0), 0.8f, RotateMode.LocalAxisAdd)
                    .SetEase(Ease.InOutSine);
            }
        }
    }
}