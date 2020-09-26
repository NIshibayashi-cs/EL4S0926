using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murase : Sensei
{
    private readonly float moveSpeed = 0.02f;
    private Vector2 standardPos;
    private float originalNum;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        type = 1;
        originalNum = Random.Range(0.5f, 2.0f);

        standardPos = transform.position;
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
        if(base.counter % 500 == 0)
        {
            moveDir.x = Random.Range(-1.0f, 1.0f);
            moveDir.y = Random.Range(-1.0f, 1.0f);
            moveDir.Normalize();
            return;
        }

        standardPos += moveDir * moveSpeed;
        transform.position = standardPos
            + new Vector2(Mathf.Cos(3.14f / 180.0f * (float)counter * originalNum) * 1.5f, Mathf.Sin(3.14f / 180.0f * (float)counter * originalNum) * 0.5f);

        if (standardPos.x >= base.limmitPos.right - 0.5f
            || standardPos.x <= base.limmitPos.left + 0.5f)
            moveDir.x *= -1;

        if (standardPos.y >= base.limmitPos.up - 0.5f
            || standardPos.y <= base.limmitPos.down + 0.5f)
            moveDir.y *= -1;
    }
}
