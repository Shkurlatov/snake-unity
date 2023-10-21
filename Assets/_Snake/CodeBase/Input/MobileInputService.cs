using UnityEngine;

namespace Snake.Input
{
    public class MobileInputService : IInputService
    {
        protected const string HORIZONTAL = "Horizontal";
        protected const string VERTICAL = "Vertical";

        public Vector2 Axis => InputAxis();

        private Vector2 InputAxis() =>
            new Vector2(SimpleInput.GetAxisRaw(VERTICAL), - SimpleInput.GetAxisRaw(HORIZONTAL));
    }
}
