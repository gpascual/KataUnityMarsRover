namespace Domain
{
    public interface IMotor
    {
        void Forward(int distanceInMeters);
        void Turn(float angleDegrees);
    }
}