using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 5f;
    public float rotate_Speed = 50f;
    public bool can_Shoot;
    public bool can_Rotate;
    private bool can_move = true;
    public float bound_X = -11f;
    public Transform attack_Point;
    public GameObject bullet_Prefab;
    private Animator anim;
    private AudioSource explosion_Sound;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        explosion_Sound = GetComponent<AudioSource>();
    }
    void Start()
    {
        if (can_Rotate)
        {
            if(Random.Range(0,2)> 0)
            {
                rotate_Speed = Random.Range(rotate_Speed, rotate_Speed + 20f);
                rotate_Speed *= -1f;
            }
            else
            {
                rotate_Speed = Random.Range(rotate_Speed, rotate_Speed + 20f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateEnemy();
    }
    void Move()
    {
        if (can_move)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp; 
            if(temp.x < bound_X)
            {
                gameObject.SetActive(false);
            }
        }
    }
    void RotateEnemy()
    {
        if (can_Rotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotate_Speed * Time.deltaTime),Space.World);
        }
    }
    void StartShooting()
    {
        GameObject bullet = Instantiate(bullet_Prefab, attack_Point.position, Quaternion.identity);
    }
}
