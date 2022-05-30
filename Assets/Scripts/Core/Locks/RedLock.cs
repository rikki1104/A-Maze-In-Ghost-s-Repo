using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Maze_Game.UI;
using Maze_Game.Saving;
using UnityStandardAssets.CrossPlatformInput;

namespace Maze_Game.Core
{
        public class RedLock : MonoBehaviour
    {
        [SerializeField] GameObject _showUI;
        [SerializeField] AudioSource _openAudio;
        [SerializeField] Animator _anim;
        
        public bool isOpen;

        void Start()
        {
            if(SaveManager.instance.hasLoaded)
            {
               isOpen = SaveManager.instance.activeSave.redDoorOpen;
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
                #if UNITY_ANDROID
                if(Input.GetKeyDown(KeyCode.E) || CrossPlatformInputManager.GetButtonDown("Fire1") && SaveManager.instance.activeSave._redKeyData)
                {                
                        Player player = other.GetComponent<Player>();
                        if(player !=null)
                        {  
                            _openAudio.Play();                             
                            _anim.Play("LockAnim");                                                                                                 
                            StartCoroutine(OpenRedLockAnim());
                        }
                }
                #elif UNITY_IOS
                if(Input.GetKeyDown(KeyCode.E) || CrossPlatformInputManager.GetButtonDown("Fire1") && SaveManager.instance.activeSave._redKeyData)
                {                
                        Player player = other.GetComponent<Player>();
                        if(player !=null)
                        {  
                            _openAudio.Play();                             
                            _anim.Play("LockAnim");                                                                                                 
                            StartCoroutine(OpenRedLockAnim());
                        }
                }
                #else
                if(Input.GetKeyDown(KeyCode.E) && SaveManager.instance.activeSave._redKeyData)
                {                
                        Player player = other.GetComponent<Player>();
                        if(player !=null)
                        {  
                            _openAudio.Play();                             
                            _anim.Play("LockAnim");                                                                                                 
                            StartCoroutine(OpenRedLockAnim());
                        }
                }
                #endif                                                            
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player" && SaveManager.instance.activeSave._redKeyData)
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
        
        IEnumerator OpenRedLockAnim()
        {          
            yield return new WaitForSeconds(2f);
            isOpen = !isOpen;
                if(isOpen)
                {                       
                    UIManager _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();  
                    if(_uiManager != null && isOpen)
                    {
                        SaveManager.instance.Save();
                        
                        _showUI.SetActive(false);
                    }                                                                                                    
                                                         
                    this.gameObject.SetActive(!isOpen);
                    SaveManager.instance.activeSave.redDoorOpen = isOpen; 
                }                                       
                                                           
        }
    }
}
