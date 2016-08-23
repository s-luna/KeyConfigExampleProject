using UnityEngine;
using System.Collections;
using System;

using System.IO;
using System.Xml.Serialization;

namespace KeyConfig
{
    [System.Serializable]
    public struct KeyConfigData
    {
        public KeyCode[] inputKey;
        public KeyCode[] inputButton;
    }

    public static class ConfigInput {

        private static KeyConfigData keyConfigData;
        private static bool keyLoadFlag;
        private static long frameCache = 0;

        private static Hashtable getKeyTable = new Hashtable();
        private static Hashtable getKeyDownTable = new Hashtable();
        private static Hashtable getKeyUpTable = new Hashtable();

        /// <summary>
        /// KeyConfigDataを./KeyConfigData.xmlからロードします。対象のファイルがなければ生成します。
        /// </summary>
        private static void Load()
        {
            if (!keyLoadFlag) {
                int keyDataCount = Enum.GetNames(typeof(KeyData)).Length;
                keyConfigData.inputKey = new KeyCode[keyDataCount];
                keyConfigData.inputButton = new KeyCode[keyDataCount];
                var serializer = new XmlSerializer(typeof(KeyConfigData));
                if (File.Exists("KeyConfigData.xml"))
                {
                    using (var stream = new FileStream("KeyConfigData.xml", FileMode.Open))
                    {
                        keyConfigData = (KeyConfigData)serializer.Deserialize(stream);
                    }
                }
                else
                {
                    ResetKey();
                    Save();
                }
                keyLoadFlag = true;
            }
        }

        /// <summary>
        /// KeyConfigDataを./KeyConfigData.xmlに保存、もしくは上書きします。
        /// </summary>
        private static void Save()
        {
            var serializer = new XmlSerializer(typeof(KeyConfigData));
            using (var stream = new FileStream("KeyConfigData.xml", FileMode.Create))
            {
                serializer.Serialize(stream, keyConfigData);
            }
        }
        
        /// <summary>
        /// KeyDataが押されている時trueを返します。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetKey(KeyData key)
        {
            Load();
            if (frameCache != Time.frameCount)
            {
                frameCache = Time.frameCount;
                ResetCache();
                return GetKeyBool(key, 0);
            }
            else
            {
                if (getKeyTable.ContainsKey(key))
                {
                    return (bool)getKeyTable[key];
                }
                else
                {
                    return GetKeyBool(key, 0);
                }
            }
        }

        /// <summary>
        /// KeyDataを押したフレームのみtrueを返します。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetKeyDown(KeyData key)
        {
            Load();
            if (frameCache != Time.frameCount)
            {
                frameCache = Time.frameCount;
                ResetCache();
                return GetKeyBool(key, 1);
            }
            else
            {
                if (getKeyDownTable.ContainsKey(key))
                {
                    return (bool)getKeyDownTable[key];
                }
                else
                {
                    return GetKeyBool(key, 1);
                }
            }
        }

        /// <summary>
        /// KeyDataを離したフレームのみtrueを返します。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetKeyUp(KeyData key)
        {
            Load();
            if (frameCache != Time.frameCount)
            {
                frameCache = Time.frameCount;
                ResetCache();
                return GetKeyBool(key, 2);
            }
            else
            {
                if (getKeyUpTable.ContainsKey(key))
                {
                    return (bool)getKeyUpTable[key];
                }
                else
                {
                    return GetKeyBool(key, 2);
                }
            }
        }

        /// <summary>
        /// KeyDataに基づきInput.Getkey、GetkeyDown、GetKeyUpを返し、結果をキーテーブルにキャッシュとして保存します。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        private static bool GetKeyBool(KeyData key,int mode)
        {
            KeyCode keyCodeValue = keyConfigData.inputKey[(int)key];
            KeyCode buttonCodeValue = keyConfigData.inputButton[(int)key];
            switch (mode)
            {
                case 0:
                    if (Input.GetKey(keyCodeValue) || Input.GetKey(buttonCodeValue))
                    {
                        getKeyTable.Add(Enum.ToObject(typeof(KeyData), key), true);
                        return true;
                    }
                    else
                    {
                        getKeyTable.Add(Enum.ToObject(typeof(KeyData), key), false);
                        return false;
                    }
                case 1:
                    if (Input.GetKeyDown(keyCodeValue) || Input.GetKeyDown(buttonCodeValue))
                    {
                        getKeyDownTable.Add(Enum.ToObject(typeof(KeyData), key), true);
                        return true;
                    }
                    else
                    {
                        getKeyDownTable.Add(Enum.ToObject(typeof(KeyData), key), false);
                        return false;
                    }
                case 2:
                    if (Input.GetKeyUp(keyCodeValue) || Input.GetKeyUp(buttonCodeValue))
                    {
                        getKeyUpTable.Add(Enum.ToObject(typeof(KeyData), key), true);
                        return true;
                    }
                    else
                    {
                        getKeyUpTable.Add(Enum.ToObject(typeof(KeyData), key), false);
                        return false;
                    }
                default:
                    return false;
            }
        }

        /// <summary>
        /// キーテーブルキャッシュを初期化します。
        /// </summary>
        private static void ResetCache()
        {
            getKeyTable = new Hashtable();
            getKeyDownTable = new Hashtable();
            getKeyUpTable = new Hashtable();
        }

        /// <summary>
        /// InputDataに基づいてキーコンフィグデータを初期化します。
        /// </summary>
        public static void ResetKey()
        {
            foreach (string keycode in Enum.GetNames(typeof(DefaultKey)))
            {
                keyConfigData.inputKey[(int)(DefaultKey)Enum.Parse(typeof(DefaultKey), keycode)] = (KeyCode)Enum.Parse(typeof(KeyCode), keycode);
                Debug.Log((int)(DefaultKey)Enum.Parse(typeof(DefaultKey), keycode));
            }
            foreach (string keycode in Enum.GetNames(typeof(DefaultButton)))
            {
                keyConfigData.inputButton[(int)(DefaultButton)Enum.Parse(typeof(DefaultButton), keycode)] = (KeyCode)Enum.Parse(typeof(KeyCode), keycode);
            }
            Save();
        }

        /// <summary>
        /// KeyDataに対応するKeyCode(keyConfigData.inputKey)を引数keyCodeに更新、保存します。
        /// </summary>
        /// <param name="keyData"></param>
        /// <param name="keyCode"></param>
        public static void SetKeyCode(KeyData keyData, KeyCode keyCode)
        {
            keyConfigData.inputKey[(int)keyData] = keyCode;
            Save();
        }

        /// <summary>
        /// KeyDataに対応するKeyCode(keyConfigData.inputButton)を引数keyCodeに更新、保存します。
        /// </summary>
        /// <param name="keyData"></param>
        /// <param name="keyCode"></param>
        public static void SetButtonCode(KeyData keyData, KeyCode keyCode)
        {
            keyConfigData.inputButton[(int)keyData] = keyCode;
            Save();
        }

        /// <summary>
        /// 現在押されているKeyCodeを返します。
        /// </summary>
        /// <returns></returns>
        public static KeyCode InputKeyCode()
        {

            foreach (String key in Enum.GetNames(typeof(KeyCode)))
            {

                KeyCode KeyCodeValue = (KeyCode)System.Enum.Parse(typeof(KeyCode), key);

                if (Input.GetKey(KeyCodeValue))
                {
                    return KeyCodeValue;
                }

            }
            return KeyCode.None;
        }
    }
}
