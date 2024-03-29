﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        // take current position to user
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 7.4f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit " + other.transform.name);

        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null) {
                player.Damage();
            }
            Destroy(this.gameObject);
        } else if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        } else if (other.tag == "Enemy")
        {
            Debug.Log("Enemy collision");
            //other.transform.position = new Vector3(Random.Range(-9.0f, 9.0f), 7.4f, 0);
        }
    }
}
