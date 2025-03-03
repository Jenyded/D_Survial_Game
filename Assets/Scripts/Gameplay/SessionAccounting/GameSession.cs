using _Project.Scripts.Infrastructure.Services.PersistentData;
using TMPro;
using UnityEngine;
using Zenject;
using UniRx;

public class GameSession : MonoBehaviour
{
    private float elapsedTime = 0f; // Время, прошедшее с начала сессии
    private int hours, minutes, seconds;
    
    private int killCount = 0; // Счётчик убийств
    private int coinCount = 0; // Счётчик монет
    
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI killCountText;
    [SerializeField] private TextMeshProUGUI coinCountText;

    private IPersistentDataService _persistentDataService;
    private CompositeDisposable _disposable = new CompositeDisposable();
    
    private bool isPaused = false;

    [Inject]
    private void Construct(IPersistentDataService persistentDataService)
    {
        _persistentDataService = persistentDataService;
    }

    private void Start()
    {
        SubscribeToEnemyKilled();
        StartCoroutine(UpdateGameSession());
    }
    
    private void SubscribeToEnemyKilled() 
    { 
        _persistentDataService.Progress.BattleData.EnemyKilled.Subscribe(OnEnemyKilled).AddTo(_disposable);
    }

    private void OnEnemyKilled(int count)
    {
        killCount = count;
        killCountText.text = $"kills: {killCount}";
    }
    
    public void AddCoin(int coin)
    {
        coinCount = coin;
        coinCountText.text = $"Coins: {coinCount}";
    }

    public void TogglePause(bool pause)
    {
        isPaused = pause;
    }
    
    private void OnDestroy() 
    {
        _disposable.Clear();
    }

    private System.Collections.IEnumerator UpdateGameSession()
    {
        while (true)
        {
            if (!isPaused) 
            {
                elapsedTime += Time.unscaledDeltaTime; // unscaledDeltaTime - время идет независимо от Time.timeScale
                hours = Mathf.FloorToInt(elapsedTime / 3600);
                minutes = Mathf.FloorToInt((elapsedTime % 3600) / 60);
                seconds = Mathf.FloorToInt(elapsedTime % 60);
            
                timerText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
            }
            yield return null;
        }
    }
}