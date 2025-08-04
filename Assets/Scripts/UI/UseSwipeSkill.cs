using _Project.Scripts.Configs;
using _Project.Scripts.Gameplay.Skills;
using _Project.Scripts.Gameplay.Skills.Interfaces;
using UnityEngine;

public class UseSwipeSkill : MonoBehaviour
{
    [SerializeField] private Cooldown _cooldown;
    
    private SkillExecutor _skillExecutor;
    private Vector2 _startPosition;
    private SkillConfig _skill;
    private GameObject _character;
    private bool _swipeUsed;
    private Vector2 _prevPosition;
    private float _prevTime;
    private readonly float _minSwipeSpeed = 7000f;

    public void Construct(SkillExecutor skillExecutor, SkillConfig skill, GameObject character)
    {
        _skillExecutor = skillExecutor;
        _skill = skill;
        _character = character;
    }
    
    private void Update()
    {
#if UNITY_EDITOR
        HandleSwipe(Input.GetMouseButtonDown(0),Input.GetMouseButton(0),Input.GetMouseButtonUp(0),Input.mousePosition);
#else
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            HandleSwipe(
                touch.phase == TouchPhase.Began,
                touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary,
                touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled,
                touch.position
            );
        }
#endif
    }

    private void HandleSwipe(bool isDown, bool isHold, bool isUp, Vector2 currentPosition)
    {
        if (_swipeUsed && _cooldown.CurrentTime <= 0f)
            _swipeUsed = false;

        if (_cooldown.CurrentTime > 0f)
            return;

        if (isDown)
        {
            _startPosition = currentPosition;
            _prevPosition = currentPosition;
            _prevTime = Time.time;
            _swipeUsed = false;
        }

        if (isHold && !_swipeUsed)
        {
            float deltaTime = Time.time - _prevTime;
            float distance = Vector2.Distance(currentPosition, _prevPosition);
            float speed = deltaTime > 0f ? distance / deltaTime : 0f;
            if (speed >= _minSwipeSpeed)
            {
                UseSkill(_prevPosition, currentPosition);
            }
            _prevPosition = currentPosition;
            _prevTime = Time.time;
        }

        if (isUp)
        {
            ResetSwipe();
        }
    }

    private void UseSkill(Vector2 startPosition, Vector2 endPosition)
    {
        Vector2 direction = (endPosition - startPosition).normalized;
        _skillExecutor.Execute(_skill, direction);
        _cooldown.Launch();
        _swipeUsed = true;
        _startPosition = Vector2.zero;
    }

    private void ResetSwipe()
    {
        _startPosition = Vector2.zero;
        _swipeUsed = false;
    }
}
