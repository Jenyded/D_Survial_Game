using Cinemachine;
using UnityEngine;

public class BattleCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;

    public void FollowTo(Transform target)
    {
        _camera.Follow = target;
    }
}