using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Limmit4
{
    public Limmit4(
        float _up,
        float _down,
        float _right,
        float _left)
    {
        up = _up;
        down = _down;
        right = _right;
        left = _left;
    }
    private Limmit4() { }

    public float up;
    public float down;
    public float right;
    public float left;
}

public abstract class Sensei : MonoBehaviour
{
    protected readonly Limmit4 limmitPos = new Limmit4(4.5f, -4.5f, 7.5f, -7.5f);

    protected Vector2 moveDir;
    protected int counter;
    public int Type { get { return type; } }
    protected int type;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        Application.targetFrameRate = 60;
        counter = 0;

        moveDir.x = Random.Range(-1.0f, 1.0f);
        moveDir.y = Random.Range(-1.0f, 1.0f);
        moveDir.Normalize();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        counter++;
    }

    protected abstract void Move();
}
