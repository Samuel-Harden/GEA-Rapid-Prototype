using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {


    //falling platfrom variables
    private Rigidbody2D rb2d;
    public float fallDelay;

    //player check
    private BoxCollider2D coll;

    // Use this for initialization
    void Start ()
    {
        //rigidbody fall platfrom
        rb2d = GetComponent<Rigidbody2D>();
        //player check
        coll = GetComponent<BoxCollider2D>();
    }

    IEnumerator enableCollider()
    {
        yield return new WaitForSeconds(1);
        coll.enabled = !coll.enabled;
    }

    IEnumerator fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb2d.isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true;
        yield return 0;
    }


    //fall function
    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
            //Debug.Log ("Its the player");
            if (Input.GetKey(KeyCode.S))
            {
                //Debug.Log ("Disabling");
                coll.enabled = !coll.enabled;
                StartCoroutine(enableCollider());

            }

        }
    }


    /*player stay function
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log ("Its the player");
            if (Input.GetKey(KeyCode.S))
            {
                //Debug.Log ("Disabling");
                coll.enabled = !coll.enabled;
                StartCoroutine(enableCollider());
            }
        }
    }
    */


}
