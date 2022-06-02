using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace Maze_Game.Core
{
        public class Player : MonoBehaviour
    {
        public static Player instance;
        
        private CharacterController _controller;

        [Header("Movement")]
        [SerializeField] public float _speed = 3.5f;
        [SerializeField] float _sensitivity = 1f;

        private float _gravity = 9.81f;       

        [Header("PowerUps")]   
        [SerializeField] public float _boostTimer = 2f;
        [SerializeField] float maxBoostTime = 3f;

        public bool isActivePowerUp = false;
        
        void Awake()
        {
            instance = this;          
        }

        // Start is called before the first frame update
        void Start()
        {
            _controller = GetComponent<CharacterController>();
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;         
        }

        // Update is called once per frame
        void Update()
        {
            CalculateMovement();
            LookX();
            Interact();
            SpeedPowerUp();
            SlowTrap();
        }

        void CalculateMovement()
        {
            float _horizontalInput = Input.GetAxis("Horizontal");
            float _verticalInput = Input.GetAxis("Vertical");

            Vector3 _direction = new Vector3(_horizontalInput, 0, _verticalInput);
            Vector3 _velocity = _direction * _speed;
            _velocity.y -= _gravity;

            _velocity = transform.transform.TransformDirection(_velocity);
            _controller.Move(_velocity * Time.deltaTime);
        }

        void LookX()
        {
            float _mouseX = Input.GetAxis("Mouse X");

            Vector3 newRotation = transform.localEulerAngles;
            newRotation.y += _mouseX * _sensitivity;
            transform.localEulerAngles = newRotation;
        }

        public void Interact()
        {
            if(Input.GetButton("Fire"))
            {
                Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hitInfo;

                if(Physics.Raycast(rayOrigin, out hitInfo))
                {
                    Debug.Log("Hit " + hitInfo.transform.name);
                }
            }
        }

        public void SpeedPowerUp()
        {
            if(isActivePowerUp)
            {
                _boostTimer += Time.deltaTime;
                if(_boostTimer >= maxBoostTime)
                {
                    isActivePowerUp = false;        
                    _speed = 3.5f;
                    _boostTimer = 0f;
                }                        
            }
        }

        public void SlowTrap()
        {
            if(isActivePowerUp)
            {
                _boostTimer += Time.deltaTime;
                if(_boostTimer >= maxBoostTime)
                {
                    isActivePowerUp = false;        
                    _speed = 3.5f;
                    _boostTimer = 0f;
                }               
            }
        }
    }
}