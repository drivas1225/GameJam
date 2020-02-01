using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabObject : MonoBehaviour
{
    public bool grabbed = false;
    RaycastHit2D hit;
    public float distance = 0.5f;
    public Transform holdPoint;
    public float throwForce = 0.5f;
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Grab"))
        {
            if (!grabbed)
            {
                //grab
                Physics2D.queriesStartInColliders = false;
                Vector2  rayVector = new Vector2(1, -0.5f * transform.localScale.x);
                hit = Physics2D.Raycast(transform.position, rayVector * transform.localScale.x, distance);
                Debug.DrawRay(transform.position, rayVector * transform.localScale.x* distance,Color.green);
                Debug.Log(hit.collider);
                if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    Rigidbody2D grabbedObject = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                    grabbed = true;
                    grabbedObject.fixedAngle = true;
                }
            }   
            else
            {
                //release
                grabbed = false;
            }

        }
        if (Input.GetButtonDown("Throw") && grabbed)
        {   
            Rigidbody2D grabbedObject = hit.collider.gameObject.GetComponent<Rigidbody2D>();
            //throw 
            grabbed = false;
            if (grabbedObject != null)
            {
                grabbedObject.velocity = new Vector2(transform.localScale.x, 1)*throwForce;
            }
        }
        if (grabbed && m_CrouchDisableCollider.enabled)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
        }
        else
        {
            grabbed = false;
        }
        
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 horizontal = new Vector3(1, -0.5f*transform.localScale.x, 0);
        Gizmos.DrawLine(transform.position,(transform.position+ horizontal * transform.localScale.x* distance));
    }*/
}
