using UnityEngine;
using Zenject;

public class BackgroundPositionChanger : MonoBehaviour
{
    [SerializeField] private Transform _background;
    [SerializeField] private float _offset = 20.48f;
    
    private BattleCamera _battleCamera;

    [Inject]
    private void Construct(BattleCamera battleCamera)
    {
        _battleCamera = battleCamera;
    }

    private void Update()
    {
        Vector3 cameraPosition = _battleCamera.transform.position;

        int extraX = Mathf.Abs(cameraPosition.x % _offset) > _offset / 2 ? (int)Mathf.Sign(cameraPosition.x) : 0;
        int x = (int)(cameraPosition.x / _offset) + extraX;
        
        int extraY = Mathf.Abs(cameraPosition.y % _offset) > _offset / 2 ? (int)Mathf.Sign(cameraPosition.y) : 0;
        int y = (int)(cameraPosition.y / _offset) + extraY;

        _background.transform.position = new Vector2(x * _offset, y * _offset);
    }
}