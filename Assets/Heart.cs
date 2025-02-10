using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    GameObject[] circleObjects;
    Vector3[] positions;
    int num = 100;
    void Start()
    {
        circleObjects = new GameObject[num];
        positions = new Vector3[num];
        for (int i = 0; i < num; i++)
        {
            float t = i * Mathf.PI * 2 / num;
            print(t);
            float x = Mathf.Sqrt(2) * Mathf.Pow(Mathf.Sin(t), 3);
            float y = -Mathf.Pow(Mathf.Cos(t), 3) - Mathf.Pow(Mathf.Cos(t), 2) + (2 * Mathf.Cos(t));
            circleObjects[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            positions[i] = new Vector3(x, y, 0) * 2;
            circleObjects[i].GetComponent<Renderer>().material.color = Color.HSVToRGB(t / (Mathf.PI * 2), 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 100; i++)
        {
            var random = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
            circleObjects[i].transform.position = positions[i] + (random * Mathf.Lerp(1,0,Time.time / 2f));
        }
    }
}
