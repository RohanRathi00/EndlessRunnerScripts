using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTraps : Trap
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform[] movePoint;

    private int i;

    private void Start() => transform.position = movePoint[0].position;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint[i].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint[i].position) < 0.25f)
        {
            i++;

            if (i >= movePoint.Length)
            {
                i = 0;
            }
        }

        if (transform.position.x > movePoint[i].position.x)
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime));
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
}
