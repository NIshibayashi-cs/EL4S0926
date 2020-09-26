using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Akiyama : Sensei
{
    private Vector2 moveDir;
    private readonly float moveSpeed = 0.06f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        moveDir = new Vector2(-1.0f, 1.0f).normalized;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        // 移動処理
        Move();
    }

    protected override void Move()
    {
        transform.position += (Vector3)moveDir * moveSpeed;

        if (transform.position.x >= 6.5f
            || transform.position.x <= -6.5f)
            moveDir.x *= -1;

        if(transform.position.y >= 5.5f
            || transform.position.y <= -5.5f)
            moveDir.y *= -1;
    }
}
