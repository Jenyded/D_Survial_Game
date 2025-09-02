using Unity.Cinemachine;
using UnityEngine;

public class BattleCamera : MonoBehaviour
{
    [SerializeField] private CinemachineCamera _camera;

    public void FollowTo(Transform target)
    {
        _camera.Follow = target;
    }
}