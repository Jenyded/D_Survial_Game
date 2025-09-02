using System;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Services.Input
{
    public class MobileInputService : IInputService
    {
        public event Action JoystickClicked;

        public MobileInputService()
        {
            Joystick.Clicked += OnJoystickClick;
        }

        ~MobileInputService()
        {
            Joystick.Clicked -= OnJoystickClick;
        }

        private void OnJoystickClick() => JoystickClicked?.Invoke();

        public Vector2 GetAxis() => new Vector2(Joystick.Horizontal, Joystick.Vertical);
    }
}