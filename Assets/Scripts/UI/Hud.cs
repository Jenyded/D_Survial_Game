using System;
using _Project.Scripts.Infrastructure.Services.WindowsService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.UI
{
    public class Hud : MonoBehaviour
    {
        private IWindowsService _windowsService;
        private Button _button;
        
        [Inject]
        public void Construct(IWindowsService windowsService)
        {
            _windowsService = windowsService;
        }

        private void Awake()
        {
            
        }
    }
}