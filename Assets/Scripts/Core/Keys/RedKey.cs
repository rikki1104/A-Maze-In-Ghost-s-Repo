using System.Collections;
using System.Collections.Generic;
using Maze_Game.UI;
using Maze_Game.Saving;
using UnityEngine;

namespace Maze_Game.Core
{
    public class RedKey : MonoBehaviour
    {
        [SerializeField] AudioSource _pickupAudio;
        
        public bool isCollected;

        void Start()
        {
            if(SaveManager.instance.hasLoaded)
            {
                isCollected = SaveManager.instance.activeSave._redKeyData;
                
            }
        }

        void Update()
        {
              this.gameObject.SetActive(!isCollected);         
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                
                if(!isCollected)
                {
                    Player player = other.GetComponent<Player>();
                    if(player !=null)
                    {  
                       _pickupAudio.Play();
                       StartCoroutine(KeyPickup());                                                                                                        
                    } 
                                                           
                }                                                             
            }
        }

        IEnumerator KeyPickup()
        {           
            yield return new WaitForSeconds(1);
            isCollected = !isCollected;
                if(isCollected)
                {
                    UIManager _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

                    if(_uiManager != null)
                    {
                        _uiManager.CollectedRedKey();
                    }

                    this.gameObject.SetActive(!isCollected);
                  
                    SaveManager.instance.activeSave._redKeyData = isCollected; 
                                                                                                         
            }                             
        }
    }
}

