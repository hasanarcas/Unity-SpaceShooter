﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public float min_Y, max_Y;
    [SerializeField]
    private GameObject player_Bullet;
    [SerializeField]
    private Transform attack_Point;
    public float attack_Timer= 0.35f;
    private float current_Attack_Timer;
    private bool canAttack; 
    void Start()
    {
        current_Attack_Timer = attack_Timer;
    }

    void Update()
    {
        MovePLayer();
        Attack();
    }
    void MovePLayer()
    {
        if(Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            if(temp.y > max_Y)
            {
                temp.y = max_Y;
            }
            transform.position = temp;
        }
        if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            if (temp.y < min_Y)
            {
                temp.y = min_Y;
            }
            transform.position = temp;
        }
    }
    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if(attack_Timer > current_Attack_Timer)
        {
            canAttack = true;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (canAttack)
            {
                canAttack = false;
                attack_Timer = 0f;
                Instantiate(player_Bullet, attack_Point.position, Quaternion.identity);
            }
        }
    }
    
}
