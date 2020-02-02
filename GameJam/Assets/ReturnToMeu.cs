using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMeu : MonoBehaviour
{
    public LayerMask whatIsPlayer;
    RaycastHit2D hit;
    [SerializeField] GameObject displayText;
    [SerializeField] bool value;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 rayVector = new Vector2(1, -0.5f * transform.localScale.x);
        hit = Physics2D.Raycast(transform.position, rayVector * transform.localScale.x, 0.001f, whatIsPlayer);
   
        if (hit.collider != null)
        {
            displayText.SetActive(value);
        }
    }
}
