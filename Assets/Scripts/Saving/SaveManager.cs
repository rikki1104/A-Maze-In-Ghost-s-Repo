using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

namespace Maze_Game.Saving
{
    public class SaveManager : MonoBehaviour
    {
        public static SaveManager instance;

        public SaveData activeSave;

        public bool hasLoaded;

        private void Awake()
        {
            instance = this;
            Load();        
        }


        public void Save()
        {
            string dataPath = Application.persistentDataPath;

            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Create);
            serializer.Serialize(stream, activeSave);
            stream.Close();

            Debug.Log("Saved");
        }

        public void Load()
        {
            string dataPath = Application.persistentDataPath;

            if(System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
            {
                var serializer = new XmlSerializer(typeof(SaveData));
                var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open);
                activeSave = serializer.Deserialize(stream) as SaveData;
                stream.Close();

                Debug.Log("Loaded");

                hasLoaded = true;
            }
        }

        public void DeleteSaveData()
        {
            string dataPath = Application.persistentDataPath;

            if(System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
            {
                File.Delete(dataPath + "/" + activeSave.saveName + ".save");

                Debug.Log("Save Deleted!");
            }
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public string saveName;

        public Vector3 respawnPosition;

        [Header("Doors")]
        public bool redDoorOpen;
        public bool greenDoorOpen;
        public bool blueDoorOpen;       
        public bool purpleDoorOpen;
        public bool pinkDoorOpen;

        [Header("Keys")]
        public bool _redKeyData;
        public bool _greenKeyData;
        public bool _blueKeyData;
        public bool _purpleKeyData;
        public bool _pinkKeyData;

        [Header("UI")]
        public bool _hasRedKeyDataUI;
        public bool _hasGreenKeyDataUI;
        public bool _hasBlueKeyDataUI;
        public bool _hasPurpleKeyDataUI;
        public bool _hasPinkKeyDataUI;
    }  
}