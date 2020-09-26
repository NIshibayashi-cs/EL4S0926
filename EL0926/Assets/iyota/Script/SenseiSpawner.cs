using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Collections;

public class EachSpawnCount
{
    public EachSpawnCount(
        int num0, int num1, int num2, int num3, int num4)
    {
        spawnCount.Add(num0);
        spawnCount.Add(num1);
        spawnCount.Add(num2);
        spawnCount.Add(num3);
        spawnCount.Add(num4);
    }

    public void Shuffle()
    {
        // リストをランダムに並べ替える
        spawnCount = spawnCount.OrderBy(a => Guid.NewGuid()).ToList();
    }

    public List<int> spawnCount = new List<int>();
}

public class SenseiSpawner : MonoBehaviour
{
    // 0:akiyama  1.murase  2.sakaguchi  3.takahashi  4.tsuru
    [SerializeField] private List<GameObject> senseiObj = new List<GameObject>();
    private List<EachSpawnCount> eachCount = new List<EachSpawnCount>();
    private readonly int spawnCount = 50;

    // Start is called before the first frame update
    void Start()
    {
        eachCount.Add(new EachSpawnCount(15, 13, 10, 7, 5));
        eachCount.Add(new EachSpawnCount(17, 12, 11, 6, 4));
        int index = UnityEngine.Random.Range(0, eachCount.Count);

        EachSpawnCount currentSpawnCount = eachCount[index];
        currentSpawnCount.Shuffle();

        // オブジェクト毎に生成していく
        for(int i = 0; i < currentSpawnCount.spawnCount.Count; i++)
        {
            // 決められた個数生成
            for(int j = 0; j < currentSpawnCount.spawnCount[i]; j++)
            {
                Vector3 pos;
                pos.x = UnityEngine.Random.Range(-7.0f, 7.0f);
                pos.y = UnityEngine.Random.Range(-4.0f, 4.0f);
                pos.z = 0.0f;
                Instantiate(senseiObj[i], pos, new Quaternion());
            }
        }
    }
}
