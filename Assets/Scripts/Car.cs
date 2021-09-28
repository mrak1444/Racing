using Tools;

namespace Profile
{
    internal class Car
    {
        private string _resourcePath;
        private float _speed;

        public Car(float speed)
        {
            _speed = speed;
        }

        public float Speed 
        { 
            get => _speed;
            set => _speed = value;
        }
        

        public string ResourcePath
        {
            get => _resourcePath;
            set => _resourcePath = value;
        }
    }
}