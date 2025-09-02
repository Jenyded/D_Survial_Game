using _Project.Scripts.Configs;
using _Project.Scripts.Gameplay.Skills;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UseSkillButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _skillText;
    [SerializeField] private Cooldown _cooldown;
    private Button _button;
    private SkillExecutor _skillExecutor;
    private SkillConfig _skillConfig;

    public void Construct(SkillExecutor skillExecutor, SkillConfig skillConfig)
    {
        _skillExecutor = skillExecutor;
        _skillConfig = skillConfig;
        _cooldown.Construct(skillConfig.Cooldown);
    }

    public void Init()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() =>
        {
            if (_cooldown.CurrentTime <= 0f)
            {
                _cooldown.Launch();
                _skillExecutor.Execute(_skillConfig, null);
            }
        });
    }

    public void Clear()
    {
        _button.onClick.RemoveAllListeners();
    }
}