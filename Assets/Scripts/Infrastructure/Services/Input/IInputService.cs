using System;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.Services.Input
{
    public interface IInputService
    {
        event Action JoystickClicked;
        
        Vector2 GetAxis();
    }
}