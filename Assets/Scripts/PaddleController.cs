using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float batasAtas;
    public float batasBawah;
    public float kecepatan;
    public string axis;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(axis) * kecepatan * Time.deltaTime;
        float nextPos = transform.position.y + move;

        if (nextPos > batasAtas)
        {
            move = 0;
        }
        if (nextPos < batasBawah)
        {
            move = 0;
        }
        transform.Translate(move, 0, 0);
    }
}
