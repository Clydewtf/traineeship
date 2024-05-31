using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSystem
{
    private readonly Transform transform;
    private readonly float speed;

    public MovementSystem(Transform transform, float speed)
    {
        this.transform = transform;
        this.speed = speed;
    }

    public void Move(Vector2 movementDirection)
    {
        float multiplayer = Time.deltaTime * speed;
        Vector2 direction = movementDirection.normalized * multiplayer;
        transform.Translate(direction, Space.World);
    }


}