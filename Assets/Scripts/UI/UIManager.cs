using System.Collections;
using System.Collections.Generic;
using Maze_Game.Core;
using UnityEngine;
using UnityEngine.UI;
using Maze_Game.Saving;
using UnityEngine.SceneManagement;

namespace Maze_Game.UI
{
    public class UIManager : MonoBehaviour
    {
    public Image _keyimage;
    public Image _redImage;
    public Image _greenImage;
    public Image _blueImage;
    public Image _purpleImage;
    public Image _pinkImage;

    public bool redKeyCollected;
    public bool greenKeyCollected;
    public bool blueKeyCollected;
    public bool purpleKeyCollected;
    public bool pinkKeyCollected;

    public bool imageCollected = false;

    void Start()
    {
        if(SaveManager.instance.hasLoaded)
            {
                redKeyCollected = SaveManager.instance.activeSave._hasRedKeyDataUI;
                greenKeyCollected = SaveManager.instance.activeSave._hasGreenKeyDataUI;
                blueKeyCollected = SaveManager.instance.activeSave._hasBlueKeyDataUI;
                purpleKeyCollected = SaveManager.instance.activeSave._hasPurpleKeyDataUI;
                pinkKeyCollected = SaveManager.instance.activeSave._hasPinkKeyDataUI;
            }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

        void Update()
        {      
            _redImage.gameObject.SetActive(redKeyCollected);
            _greenImage.gameObject.SetActive(greenKeyCollected);
            _blueImage.gameObject.SetActive(blueKeyCollected);
            _purpleImage.gameObject.SetActive(purpleKeyCollected); 
            _pinkImage.gameObject.SetActive(pinkKeyCollected);

            if(Input.GetKeyDown(KeyCode.Tab))
            {
                KeysButtonPressed();
            } 

            
            // pressing esc toggles between hide/show
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                LoadMainMenu();
            }   
        }

        public void KeysButtonPressed()
        {
                if(imageCollected == false)
                {   
                    imageCollected = true;
                    _keyimage.gameObject.SetActive(true);
                }
                else
                {
                    imageCollected = false;
                    _keyimage.gameObject.SetActive(false);
                }      
        }


    public void CollectedRedKey()
    {
        if(_redImage != null)
        {
            redKeyCollected = !redKeyCollected;
            if(!redKeyCollected)
            {
                _redImage.gameObject.SetActive(redKeyCollected);
            }
        }
        SaveManager.instance.activeSave._hasRedKeyDataUI = redKeyCollected;      
    }


        public void CollectedgreenKey()
    {
        if(_greenImage != null)
        {
            greenKeyCollected = !greenKeyCollected;
            if(!greenKeyCollected)
            {
                _greenImage.gameObject.SetActive(greenKeyCollected);
            }
        }
        SaveManager.instance.activeSave._hasGreenKeyDataUI = greenKeyCollected;      
    }

    public void CollectedblueKey()
    {
        if(_blueImage != null)
        {
            blueKeyCollected = !blueKeyCollected;
            if(!blueKeyCollected)
            {
                _blueImage.gameObject.SetActive(blueKeyCollected);
            }
        }
        SaveManager.instance.activeSave._hasBlueKeyDataUI = blueKeyCollected;      
    }

    public void CollectedpurpleKey()
    {
        if(_purpleImage != null)
        {
            purpleKeyCollected = !purpleKeyCollected;
            if(!purpleKeyCollected)
            {
                _purpleImage.gameObject.SetActive(purpleKeyCollected);
            }
        }
        SaveManager.instance.activeSave._hasPurpleKeyDataUI = purpleKeyCollected;      
    }

    public void CollectedpinkKey()
    {
        if(_pinkImage != null)
        {
            pinkKeyCollected = !pinkKeyCollected;
            if(!pinkKeyCollected)
            {
                _pinkImage.gameObject.SetActive(pinkKeyCollected);
            }
        }
        SaveManager.instance.activeSave._hasPinkKeyDataUI = pinkKeyCollected;      
    }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }

}