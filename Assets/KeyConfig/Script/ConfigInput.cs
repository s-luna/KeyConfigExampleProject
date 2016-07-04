using UnityEngine;
using System.Collections;
using System;

namespace ConfigInput{
    public static class ConfigInput {

        private static Hashtable GetKeyTable = new Hashtable();
        private static Hashtable GetKeyDownTable = new Hashtable();
        private static Hashtable GetKeyUpTable = new Hashtable();

        /// <summary>
        /// KeyDataが押されている時trueを返します。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetKey(KeyData key)
        {
            return (bool)GetKeyTable[key];
        }
        /// <summary>
        /// KeyDataを押したフレームのみtrueを返します。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetKeyDown(KeyData key)
        {
            return (bool)GetKeyDownTable[key];
        }
        /// <summary>
        /// KeyDataを離したフレームのみtrueを返します。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetKeyUp(KeyData key)
        {
            return (bool)GetKeyUpTable[key];
        }

        /// <summary>
        /// キーテーブルを更新します。
        /// </summary>
        /// <param name="InputKey"></param>
        /// <param name="InputButton"></param>
        public static void KeyUpdate(KeyCode[] InputKey, KeyCode[] InputButton)
        {
            GetKeyTable = new Hashtable();
            GetKeyDownTable = new Hashtable();
            GetKeyUpTable = new Hashtable();

            foreach(int key in Enum.GetValues(typeof(KeyData)))
            {
                KeyCode KeyCodeValue = InputKey[key];
                KeyCode ButtonCodeValue = InputButton[key];

                if (Input.GetKey(KeyCodeValue) || Input.GetKey(ButtonCodeValue))
                {
                    GetKeyTable.Add(Enum.ToObject(typeof(KeyData), key), true);
                }
                else
                {
                    GetKeyTable.Add(Enum.ToObject(typeof(KeyData), key), false);
                }
                if (Input.GetKeyDown(KeyCodeValue) || Input.GetKeyDown(ButtonCodeValue))
                {
                    GetKeyDownTable.Add(Enum.ToObject(typeof(KeyData), key), true);
                }
                else
                {
                    GetKeyDownTable.Add(Enum.ToObject(typeof(KeyData), key), false);
                }
                if (Input.GetKeyUp(KeyCodeValue) || Input.GetKeyUp(ButtonCodeValue))
                {
                    GetKeyUpTable.Add(Enum.ToObject(typeof(KeyData), key), true);
                }
                else
                {
                    GetKeyUpTable.Add(Enum.ToObject(typeof(KeyData), key), false);
                }

            }

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
