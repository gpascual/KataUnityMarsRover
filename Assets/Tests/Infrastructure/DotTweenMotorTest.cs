using Infrastructure;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Infrastructure
{
    public class DotTweenMotorTest
    {
        private DotTweenMotor sut;
        private IAnimator animator;

        [SetUp]
        public void Setup()
        {
            GameObject dummyObject = new GameObject();
            animator = NSubstitute.Substitute.For<IAnimator>();
            sut = new DotTweenMotor(dummyObject.transform, animator);
        }

        [Test]
        public void given_a_distance_in_meters__should_move_forward()
        {
            sut.Forward(1);
            animator.Received(1).Move(Arg.Any<Vector3>(), Arg.Is(1f));
        }
        
        [Test]
        public void given_a_degress__should_rotate_on_z()
        {
            var angleDegrees = 90;
            Vector3 expectedRotation = new Vector3(0, angleDegrees, 0);
            sut.Turn(angleDegrees);
            animator.Received(1).Rotate(Arg.Is<Vector3>(expectedRotation), Arg.Is(1f));
        }
    }
}