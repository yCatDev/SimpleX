using System;
using SFML.System;
using SFML.Graphics;
using SFML.Graphics.Glsl;
using SFML.Window;
using SimpleX.Interfaces;


namespace SimpleX
{
    public abstract class GameObject: IGameObject
    {
        public Sprite _sprite;
        public string Name { get; set; }
        public Transformable _parent;
        public Shader shader;
        public BlendMode BlendMode;
        
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
            }
        }

        public float LocalRotation
        {
            get => _localRotation;
            set
            {
                _localRotation = value;
            }
        }
        
        private float _localRotation;
        private Vector2f _scale;
        

        public GameObject(string name, Texture texture)
        {
            _sprite = new Sprite(texture);
            
            var bounds = _sprite.GetGlobalBounds();
            _sprite.Origin = new Vector2f(bounds.Width/2, bounds.Height/2);
            _sprite.Texture.Smooth = true;
            _parent = Engine.GetInstance().World;
            LocalPosition = _sprite.Position;
            Scale = _sprite.Scale;
            shader = Shader.FromString(vertexShader: Engine.basic_vert_shader, null, Engine.basic_frag_shader);
            
            BlendMode = BlendMode.None;
            Name = name;
        }

        public virtual void Start()
        {
            
        }

        public void SetShader(string vertPath, string fragPath) 
            => shader = new Shader(vertPath, null, fragPath);

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
        {
            shader.SetUniform("texture", Shader.CurrentTexture);
            
            var state = new RenderStates()
            {
                Transform = Transform.Identity,
                BlendMode = BlendMode,
                Shader = this.shader
            };

            rw.Draw(_sprite, state);
        }

    }
}