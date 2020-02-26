using System;
using SFML.Graphics;
using SFML.System;
using SimpleX.Interfaces;

namespace SimpleX.BasicGameObjects
{
    public class TextObject: IGameObject
    {

        private Text _text;
        public string Name { get; set; }
        public Transformable _parent;

        private Vector2f _localPosition;
        public Vector2f LocalPosition
        {
            get => _localPosition;
            set
            {
                _localPosition = value;
                _text.Position = _localPosition + _parent.Position;
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
        

        public TextObject(string name, string fontPath, string text = " ", uint textSize = 12, Text.Styles style = Text.Styles.Regular)
        {
            _text = new Text();
            _text.Font = new Font(fontPath);

            var bounds = _text.GetGlobalBounds();
            _text.Origin = new Vector2f(bounds.Width/2, bounds.Height/2);
            
            _parent = Core.GetInstance().World;
            LocalPosition = _text.Position;
            Scale = _text.Scale;
            
            Name = name;
            SetText(text);
            SetStyle(style);
            SetSize(textSize);
            SetColor(Color.Black);
        }

        public virtual void Start()
        {
            
        }

        private void UpdateOrigin()
        {
            var bounds = _text.GetGlobalBounds();
            _text.Origin = new Vector2f(bounds.Width/2, bounds.Height/2);
        }

        public void SetStyle(Text.Styles style)
        {
            _text.Style = style;
            UpdateOrigin();
        }

        public void SetText(string text)
        {
            _text.DisplayedString = text;
            UpdateOrigin();  
        }

        public void SetSize(uint size)
        {
            _text.CharacterSize = size;
            UpdateOrigin();
        }

        public virtual void Update()
        {
            
            _text.Position = LocalPosition + _parent.Position;
            _text.Rotation = LocalRotation;
            _text.Scale = Scale;
            
        }

        public void SetParent(GameObject parent)
        {
            _parent = parent._sprite;
            
        }

        public void SetColor(Color color)
        {
            _text.FillColor = color;
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


        public Vector2f GetGlobalPosition() => _text.Position;
        public void SetGlobalPosition(Vector2f newVec) => _text.Position = newVec; 
        
        public void Draw(RenderWindow rw)
            => rw.Draw(_text);
            
    
    }
}