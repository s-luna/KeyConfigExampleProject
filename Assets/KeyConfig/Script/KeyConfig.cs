using UnityEngine;
using System.Collections;
using System;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public struct KeyConfigData
{
    public KeyCode[] InputKey;
    public KeyCode[] InputButton;
}

namespace ConfigInput
{
    public class KeyConfig : MonoBehaviour
    {
        public KeyConfigData keyconfigdata;

        // Use this for initialization
        void Start()
        {
            ResetKey();
        }
        /// <summary>
        /// KeyConfigDataを./KeyConfigData.xmlからロードします。対象のファイルがなければ生成します。
        /// </summary>
        void Load()
        {
            var serializer = new XmlSerializer(typeof(KeyConfig));
            if (System.IO.File.Exists("KeyConfigData.xml"))
            {
                using (var stream = new FileStream("KeyConfigData.xml", FileMode.Open))
                {
                    keyconfigdata = (KeyConfigData)serializer.Deserialize(stream);
                }
            }
            else
            {
                ResetKey();
                Save();
            }
        }
        /// <summary>
        /// KeyConfigDataを./KeyConfigData.xmlに保存、もしくは上書きします。
        /// </summary>
        void Save()
        {
            var serializer = new XmlSerializer(typeof(KeyConfigData));
            using (var stream = new FileStream("KeyConfigData.xml", FileMode.Create))
            {
                serializer.Serialize(stream, keyconfigdata);
            }
        }

        /// <summary>
        /// InputDataに基づいてキーコンフィグデータをリセットします。
        /// </summary>
        void ResetKey()
        {
            foreach (string keycode in Enum.GetNames(typeof(DefaultKey)))
            {
                keyconfigdata.InputKey[(int)(DefaultKey)System.Enum.Parse(typeof(DefaultKey), keycode)] = (KeyCode)System.Enum.Parse(typeof(KeyCode), keycode);
            }
            foreach (string keycode in Enum.GetNames(typeof(DefaultButton)))
            {
                keyconfigdata.InputButton[(int)(DefaultButton)System.Enum.Parse(typeof(DefaultButton), keycode)] = (KeyCode)System.Enum.Parse(typeof(KeyCode), keycode);
            }
        }

        // Update is called once per frame
        void Update()
        {
            ConfigInput.KeyUpdate(keyconfigdata.InputKey,keyconfigdata.InputButton);
            //Debug.Log(ConfigInput.GetKeyUp(KeyData.Circle));
        }
    }
}
