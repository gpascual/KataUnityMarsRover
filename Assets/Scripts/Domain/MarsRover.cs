namespace Domain
{
    public class MarsRover
    {
        private readonly IMotor motor;

        public MarsRover(IMotor motor)
        {
            this.motor = motor;
        }

        public void MoveForward()
        {
            motor.Forward(1);
        }
    }
}