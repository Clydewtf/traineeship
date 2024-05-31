using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTargetSystem
{
    private readonly Transform transform;

    public LookAtTargetSystem(Transform transform)
    {
        this.transform = transform;
    }

    public void LookAt(Vector3 target)
    {
        float angleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        float angleDeg = angleRad * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.Euler(0, 0, angleDeg);
    }
}
