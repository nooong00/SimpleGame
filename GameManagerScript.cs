using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
    public GameObject playerObj;
    public GameObject zombieObj;

    Vector3[] pos;

    Stack<Transform> zombiePool;

	// Use this for initialization
	void Start () {
        playerObj = GameObject.Find("Player");

        pos = new Vector3[3];
        for (int i = 0; i < 3; ++i)
        {
            pos[i] = new Vector3(-2.5f + 2.5f * i, 0.5f, -12.0f);
        }
        zombiePool = new Stack<Transform>();
        GameObject tmpObj;
        for(int i = 0; i < 30; ++i)
        {
            tmpObj = Instantiate<GameObject>(zombieObj);
            tmpObj.GetComponent<EnemyScript>().Init();
            zombiePool.Push(tmpObj.transform);
        }
        StartCoroutine("CoZombieSpawn");
	}

    IEnumerator CoZombieSpawn()
    {
        while(true)
        {
            zombiePool.Pop().GetComponent<EnemyScript>().Play();
            yield return new WaitForSeconds(Random.Range(2.0f, 4.0f));
        }
    }

    public void PushZombie(Transform zombie)
    {
        zombiePool.Push(zombie);
    }

	
	// Update is called once per frame
	void Update () {
        //키 입력
		if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerObj.GetComponent<PlayerScript>().Move(-1);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerObj.GetComponent<PlayerScript>().Move(1);
        }
        if(Input.GetKey(KeyCode.Z))
        {
            //폭탄
        }
	}
}
