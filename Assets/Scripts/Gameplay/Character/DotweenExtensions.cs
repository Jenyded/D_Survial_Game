using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public static class DotweenExtensions
{
    public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveInTargetLocalSpace(this Transform transform, Transform target, Vector3 targetLocalEndPosition, float duration)
    {
        var t = DOTween.To(
            () => transform.position - target.position, // Value getter
            x => transform.position = x + target.position, // Value setter
            targetLocalEndPosition, 
            duration);
        t.SetTarget(transform);
        return t;
    }
    
    public static TweenerCore<Vector3, Vector3, VectorOptions> DOMoveInPositionLocalSpace(this Transform transform, Transform target, Vector3 targetLocalEndPosition, float duration)
    {
        var t = DOTween.To(
            () => transform.position - target.position, // Value getter
            x => transform.position = x + target.position, // Value setter
            targetLocalEndPosition, 
            duration);
        t.SetTarget(transform);
        return t;
    }
    
    public static TweenerCore<Quaternion, Quaternion, NoOptions> DoRotateToward(this Transform transform, Transform target, float duration, bool invert)
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (invert)
            angle -= 180;
        
        return transform.DORotateQuaternion(Quaternion.Euler(0, 0, angle), duration);
    }
}