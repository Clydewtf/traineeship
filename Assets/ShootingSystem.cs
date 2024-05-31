using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem
{
    private readonly Projectile projectilePrefab;
    private readonly Transform shootingPoint;

    public ShootingSystem(Projectile projectilePrefab, Transform shootingPoint)
    {
        this.projectilePrefab = projectilePrefab;
        this.shootingPoint = shootingPoint;
    }

    public void Shot()
    {
        var projectile = Object.Instantiate(projectilePrefab);
        projectile.transform.position = shootingPoint.position;
        projectile.transform.rotation = shootingPoint.rotation;
    }
}
