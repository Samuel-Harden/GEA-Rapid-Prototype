using UnityEngine;
using System.Collections;

public class EnemyLR : MonoBehaviour

{
    private Rigidbody2D enemyRB;
    float startPos;
    float endPos;
    public int distance;
    public int speed;
    bool moveRight = true;

    void Start()
    {
        enemyRB = gameObject.GetComponent<Rigidbody2D>();
        startPos = transform.position.x;
        endPos = startPos - distance;
    }

    void Update()
    {
        if (moveRight)
        //moves enemy Right
        {
            enemyRB.velocity = new Vector2(-speed * Time.deltaTime, enemyRB.velocity.y);
            // turns enemy around
            if (enemyRB.position.x <= endPos)
            {
                moveRight = false;
            }
        }

        if (!moveRight)
        {
            enemyRB.velocity = new Vector2(speed * Time.deltaTime, enemyRB.velocity.y);
            if (enemyRB.position.x >= startPos)
            {
                moveRight = true;
            }
        }

    }


}