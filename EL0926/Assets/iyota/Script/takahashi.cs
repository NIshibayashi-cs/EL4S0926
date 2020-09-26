using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takahashi : Sensei
{
    private readonly float moveSpeed = 0.03f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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
        if (base.counter % 300 == 0)
        {
            moveDir.x = Random.Range(-1.0f, 1.0f);
            moveDir.y = Random.Range(-1.0f, 1.0f);
            moveDir.Normalize();
            return;
        }

        transform.position += (Vector3)moveDir * moveSpeed;

        if (transform.position.x >= base.limmitPos.right
            || transform.position.x <= base.limmitPos.left)
            moveDir.x *= -1;

        if (transform.position.y >= base.limmitPos.up
            || transform.position.y <= base.limmitPos.down)
            moveDir.y *= -1;
    }
}
