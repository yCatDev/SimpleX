using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using SimpleX.Interfaces;


namespace SimpleX
{
    public abstract class GameObject
    {
        private Sprite _sprite;
        public Guid guid;
        public string name;
        public Transformable _parent;

        private Vector2f _localPosition;
        public Vector2f LocalPosition
        {
            get => _localPosition;
            set
            {
                _localPosition = value;
                _sprite.Position = _localPosition + _parent.Position;
            }
            
        }

        public Vector2f Scale
        {
            get => _scale;
            set
            {
                _scale = value;
               // _sprite.Scale = _scale;
            }
        }

        public float LocalRotation
        {
            get => _localRotation;
            set
            {
                _localRotation = value;
               // _sprite.Rotation = _localRotation;
            }
        }
        
        private float _localRotation;
        private Vector2f _scale;
        

        public GameObject(string name, Texture texture)
        {
            _sprite = new Sprite(texture);
            _sprite.Origin = new Vector2f(_sprite.TextureRect.Width/2, _sprite.TextureRect.Height/2);
            
            _parent = Core.GetInstance().World;
            LocalPosition = _sprite.Position;
            Scale = _sprite.Scale;
            
            this.name = name;
            guid = Guid.NewGuid();
        }

        public virtual void Start()
        {
            
        }
        
        public virtual void Update()
        {
            
            _sprite.Position = LocalPosition + _parent.Position;
            _sprite.Rotation = LocalRotation;
            _sprite.Scale = Scale;
            
        }

        public void SetParent(GameObject parent)
        {
            _parent = parent._sprite;
            
        }

        public void SetColor(Color color)
        {
            _sprite.Color = color;
        }
        
        
        
        public void Rotate(float angle)
        {
            angle = (float) (angle * (Math.PI / 180));
            float x1 = LocalPosition.X;
            float y1 = LocalPosition.Y;

            float x2 = (float) (x1 * Math.Cos(angle) - y1 * Math.Sin(angle));
            float y2 = (float) (x1 * Math.Sin(angle) + y1 * Math.Cos(angle));
            
            LocalPosition = new Vector2f(x2 , y2);
        }


        public Vector2f GetGlobalPosition() => _sprite.Position;
        public void SetGlobalPosition(Vector2f newVec) => _sprite.Position = newVec; 
        
        public void Draw(RenderWindow rw)
            => rw.Draw(_sprite);
            
    }
}