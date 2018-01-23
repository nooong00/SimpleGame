using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
    float speed = 2.0f;

    public BoxCollider col;
    Rigidbody rigid;
    GameObject manager;

    public void Init()
    {
        col = GetComponent<BoxCollider>();
        rigid = GetComponent<Rigidbody>();
        col.enabled = false;
        rigid.useGravity = false;
        manager = GameObject.Find("GameManager");
    }

	public void Play()
    {
        //작동
        col.enabled = true;
        rigid.useGravity = true;
        StartCoroutine("CoMove");
        StartCoroutine("CoLiveCheck");
    }

    public void Stop()
    {
        //        StopAllCoroutines();
        StopCoroutine("CoMove");
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }


    void OnCollisionEnter(Collision col)
    {
        if(col.transform.CompareTag("Player"))
        {
            Debug.Log("Damaged");
            Stop();
            Vector3 tmp = new Vector3(0.5f, 1, 0.0f);
            rigid.AddForce(tmp * 500.0f);
        }
    }

    void Dead()
    {
        col.enabled = false;
        rigid.useGravity = false;
        rigid.velocity = Vector3.zero;

        StopAllCoroutines();


    }

    IEnumerator CoLiveCheck()
    {
        while(true)
        {
            if(transform.position.y < -20.0f)
            {
                Dead();
            }
            yield return new WaitForSeconds(2.0f);
        }
    }

    IEnumerator CoMove()
    {
        while(true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            yield return null;
        }
    }
}
