using System.Collections;
using System.Collections.Generic;
using Maze_Game.Core;
using UnityEngine;

namespace Maze_Game.Core
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform startPos;
        [SerializeField] float speed = 1f;
        [SerializeField] float howClose;

        [SerializeField] Animator anim;

        private Transform target;
        private Player player;
        private float dist;       
        private Rigidbody rb;

        // Start is called before the first frame update
        void Start()
        {
            player = GetComponent<Player>();
            rb = GetComponent<Rigidbody>();
            target = GameObject.FindGameObjectWithTag("Player").transform;        
        }

        // Update is called once per frame
        void Update()
        {
        dist = Vector3.Distance(target.position, transform.position);

            if(this != null)
            {
                if(dist <= howClose)
                {
                    anim.Play("GhostMoveAnim");
                    transform.LookAt(target);
                    GetComponent<Rigidbody>().AddForce(transform.forward * speed);
                }
                else if(dist > howClose && startPos)
                {
                    anim.Play("Ghost Idle");
                    GetComponent<Rigidbody>().AddForce(transform.forward * speed);
                    transform.LookAt(startPos);
                }
            }      
        }
    }
}
