using System;
using System.Collections.Generic;
using _Project.Scripts.Infrastructure.Services.Input;
using Spine;
using Spine.Unity;
using UniRx;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace _Project.Scripts.Gameplay.Character
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private SkeletonAnimation _animator;
        [SerializeField] private CharacterMovement _movement;
        
        private IInputService _inputService;
        
        private readonly string Move = "step";
        private readonly string Death = "Death";
        private readonly string Idle = "idle";
        private bool _customClipPlaying;
        
        
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        private void Update()
        {
            if (_inputService == null)
                return;

            if (_inputService.GetAxis().magnitude >= 0.1f)
                PlayMove(_inputService.GetAxis().magnitude);
            else
                PlayIdle();
            //_animator.SetFloat(Move, _inputService.GetAxis().magnitude);
        }

        private void PlayMove(float speed)
        {
            if (_animator.AnimationState.GetCurrent(0).Animation.Name != Move && !_customClipPlaying)
                _animator.AnimationState.SetAnimation(0, Move, true);

            _animator.AnimationState.TimeScale = speed;
        }
        
        public void PlayIdle()
        {
            if (_customClipPlaying)
                return;
            
            if (_animator.AnimationState.GetCurrent(0).Animation.Name != Idle)
                _animator.AnimationState.SetAnimation(0, Idle, true);
        }

        public void PlayDeath()
        {
            //_animator.SetBool(Death, true);
        }

        public void SwitchHands(bool isActive)
        {
            float colorA = isActive ? 1f : 0f;
            _animator.Skeleton.FindSlotThatContains("Hand").ForEach(x => x.A = colorA);
            _animator.Skeleton.UpdateCache();
        }

        public void ResetAll()
        {
            //_animator.Rebind();
        }

        public void PlayCustomOneShot(string clipName)
        {
            _customClipPlaying = true;
            var trackEntry = _animator.AnimationState.SetAnimation(0, clipName, false);
            
            UniTask.WaitForSeconds(trackEntry.AnimationEnd - 0.1f).ContinueWith(() =>
            {
                _customClipPlaying = false;
            }).Forget();
        }
    }
}