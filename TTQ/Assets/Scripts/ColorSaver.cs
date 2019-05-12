using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSaver : MonoBehaviour
{
    MeshRenderer mesh;
    public Color orColor;
    public bool isHitted;

    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        orColor = mesh.material.color;
        isHitted = false;
    }

    void Update()
    {
        if (isHitted)
        {
            mesh.material.color = Color.red;

        }
        else
        {
            mesh.material.color = orColor;
        }
    }
}
