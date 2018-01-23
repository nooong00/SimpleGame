using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    Vector3[] pos = new Vector3[3];
    int playerPos;
    float speed = 2.0f;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 3; ++i)
        {
            pos[i] = new Vector3(-2.5f + 2.5f * i, 0.5f, -5.0f);            
        }
        playerPos = 1;
        transform.position = pos[playerPos];
	}

    public void Move(int n)
    {
        if(n == -1)
        {
            if (playerPos < 1) return;
            playerPos--;
            transform.position = Vector3.Lerp(transform.position, pos[playerPos], speed);
        }
        else if(n == 1)
        {
            if (playerPos > 1) return;
            playerPos++;
            transform.position = Vector3.Lerp(transform.position, pos[playerPos], speed);
        }
    }

    IEnumerator CoMove()
    {
        
        yield return null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
