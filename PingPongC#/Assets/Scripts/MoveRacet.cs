using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacet : MonoBehaviour
{
    public Transform racetTop;
    public Transform racetBottom;
    [SerializeField]
    private float speed = 10f;

    void OnMouseDrag ()
    {
        if(!Ball.lose)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.x = mousePos.x > 2.249603f ? 2.249603f : mousePos.x;
            mousePos.x = mousePos.x < -2.249603f ? -2.249603f : mousePos.x;
            racetBottom.position = Vector2.MoveTowards(racetBottom.position,
                new Vector2(mousePos.x, racetBottom.position.y),
                speed * Time.deltaTime);
            racetTop.position = Vector2.MoveTowards(racetTop.position,
                new Vector2(mousePos.x, racetTop.position.y),
                speed * Time.deltaTime);
        }
    }
}
