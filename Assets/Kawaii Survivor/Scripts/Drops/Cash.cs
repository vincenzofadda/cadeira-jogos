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

    public void Collect(Player playerTransform)
    {
        if(collected)
        {
            return;
        }

        collected = true;

        StartCoroutine(MoveTowardsPlayer(playerTransform));


    }
    IEnumerator MoveTowardsPlayer(Player player)
    {

        float timer = 0;
        Vector2 initialPosition = transform.position;
        

        while(timer < 1)
        {
            Vector2 targetPosition = player.GetCenter();
            transform.position = Vector2.Lerp(initialPosition, targetPosition, timer);
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
