using UnityEngine;

public class StageScroll : MonoBehaviour
{
    public float speed = 3f;

    public static bool isStop = false; // ←ここ重要

    void Start()
    {
        isStop = false;
    }

    void Update()
    {
        if (isStop) return;

        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}