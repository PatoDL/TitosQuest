using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject boxPF;
    [SerializeField] private float timer;
    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 5f)
        {
            SpawnBox();
            timer = 0f;
        }
    }

    void SpawnBox()
    {
        GameObject box = Instantiate(boxPF);
        box.transform.position = new Vector3(Random.Range(0, 450), 70, Random.Range(200, 450));
        box.AddComponent<ColorSaver>();
        box.transform.tag = "selectable";
    }
}
