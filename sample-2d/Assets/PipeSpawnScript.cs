using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    public float heightOffset = 0;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
            return;
        }

        spawnPipe();
        timer = 0;

    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        float xAxisDiff = Mathf.Min(Time.realtimeSinceStartup, 3);

        Instantiate(pipe, new Vector3(
            transform.position.x + Random.Range(-xAxisDiff, xAxisDiff),
            Random.Range(lowestPoint, highestPoint), 0),
            transform.rotation
        );
    }
}
