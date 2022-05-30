using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Maze_Game.UI;
using Maze_Game.Saving;
using UnityStandardAssets.CrossPlatformInput;

namespace Maze_Game.Core
{
        public class PurpleLock : MonoBehaviour
    {
        [SerializeField] GameObject _showUI;
        [SerializeField] AudioSource _openAudio;
        [SerializeField] Animator _anim;
        
        public bool isOpen;

        void Start()
        {
            if(SaveManager.instance.hasLoaded)
            {
               isOpen = SaveManager.instance.activeSave.purpleDoorOpen;
            }

            _anim = GetComponent<Animator>();
        }

        void Update()
        {
            this.gameObject.SetActive(!isOpen);
        }

        void OnTriggerStay(Collider other)
        {
            if(other.tag == "Player")
            {
                if(CrossPlatformInputManager.GetButton("Fire1") || Input.GetKeyDown(KeyCode.E) && SaveManager.instance.activeSave._purpleKeyData)
                {
                    
                    Player player = other.GetComponent<Player>();
                        if(player !=null)
                        { 
                            _openAudio.Play();
                            _anim.Play("LockAnim");
                            StartCoroutine(OpenBlueLockAnim());
                        } 
                } 
                            
            }
        }

            void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player" && SaveManager.instance.activeSave._purpleKeyData)
            {
                _showUI.SetActive(true);              
            }
        }

        void OnTriggerExit(Collider other)
        {
            if(other.tag == "Player")
            {
                _showUI.SetActive(false);              
            }
        }              

            

            IEnumerator OpenBlueLockAnim()
            {
                yield return new WaitForSeconds(1.2f);

                isOpen = !isOpen;
                    if(isOpen)
                    {                       
                        UIManager _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();  
                        if(_uiManager != null && !isOpen)
                        {
                            _showUI.SetActive(false);
                        }                                                 
                        SaveManager.instance.Save();                                                                                                                                               
                        this.gameObject.SetActive(!isOpen);
                        SaveManager.instance.activeSave.purpleDoorOpen = isOpen;
                    }              
               
            }
        }
    }
