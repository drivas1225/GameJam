using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoose : MonoBehaviour
{
    public LayerMask whatIsLimit;
    RaycastHit2D hit;
    [SerializeField] GameObject rewindText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rayVector = new Vector2(1, -0.5f * transform.localScale.x);
        hit = Physics2D.Raycast(transform.position, rayVector * transform.localScale.x, 0.01f, whatIsLimit);
        if (hit.collider != null)
        {
            rewindText.SetActive(true);
        }
        else
        {
            rewindText.SetActive(false);
        }
    }
}
