using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takiyama : MonoBehaviour
{
    public int dist;
    int counter = 0;
    float plus = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 p = new Vector2(plus,0);
        transform.Translate(p);
        counter++;
        if(counter == dist)
        {
            counter = 0;
            plus *= -1;
        }

    }
}
