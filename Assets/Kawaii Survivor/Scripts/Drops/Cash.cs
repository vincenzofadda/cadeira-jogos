using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cash : MonoBehaviour
{

    private bool collected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collect(Transform playerTransform)
    {
        if(collected)
        {
            return;
        }

        Debug.Log("Collect chamado com playerTransform: " + playerTransform.position);
        collected = true;

        StartCoroutine(MoveTowardsPlayer(playerTransform));


    }
    IEnumerator MoveTowardsPlayer(Transform playerTransform)
    {

        float timer = 0;
        Vector2 initialPosition = transform.position;

        while(timer < 1)
        {
            transform.position = Vector2.Lerp(initialPosition, playerTransform.position, timer);
            timer += Time.deltaTime;
            yield return null;
        }
        Debug.Log("coletou esta merda");
        Collected();
    }

    private void Collected()
    {
        gameObject.SetActive(false);
    }
}
