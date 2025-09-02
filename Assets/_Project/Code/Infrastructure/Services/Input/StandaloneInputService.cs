using System;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Services.Input
{
    public class StandaloneInputService : IInputService
    {
        public event Action JoystickClicked;
        public Vector2 GetAxis() => new(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
    }
}