using UnityEngine;
using System.Collections;

public class EnemyUD : MonoBehaviour
{
    private Rigidbody2D enemyRB;
    float startPos;
    float endPos;
    public int distance;
    public int speed;
    bool moveUp = true;

    void Start()
    {
        enemyRB = gameObject.GetComponent<Rigidbody2D>();
        startPos = transform.position.y;
        endPos = startPos + distance;
    }

    void Update()
    {
        if (moveUp)
        //moves enemy up
        {
            enemyRB.velocity = new Vector2(enemyRB.velocity.x, speed * Time.deltaTime);
            // turns enemy around
            if (enemyRB.position.y >= endPos)
            {
                moveUp = false;
            }
        }

        if (!moveUp)
        {
            enemyRB.velocity = new Vector2(enemyRB.velocity.x, -speed * Time.deltaTime);
            if (enemyRB.position.y <= startPos)
            {
                moveUp = true;
            }
        }

    }


}