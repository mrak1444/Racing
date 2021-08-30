namespace Profile
{
    internal class Car : IUpgradableCar
    {
        private float _defaultSpeed;
        public float Speed 
        { 
            get => _defaultSpeed; 
            set => _defaultSpeed = value; 
        }

        public Car(float speed)
        {
            _defaultSpeed = speed;
        }
    }
}