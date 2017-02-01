using UnityEngine;
using System.Collections;

public class aArrowRight : MonoBehaviour
{

    private Rigidbody2D enemyRB;
    Vector3 startPos;
    float endPos;
    public int distance;
    public int speed;
    bool moveRight = true;

    void Start()
    {
        enemyRB = gameObject.GetComponent<Rigidbody2D>();
        startPos = transform.position;
        endPos = startPos.x + distance;
    }

    void Update()
    {
        if (moveRight)
        //moves enemy Right
        {
            enemyRB.velocity = new Vector2(speed * Time.deltaTime, enemyRB.velocity.y);
            // turns enemy around
            if (enemyRB.position.x >= endPos)
            {
                transform.position = startPos;
            }
        }

      

    }


}
