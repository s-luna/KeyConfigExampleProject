using UnityEngine;
using KeyConfig;    //キーコンフィグを利用する場合必ず記述してください。

public class InputTest : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

        if (ConfigInput.GetKeyDown(KeyData.Circle))
        {
            Debug.Log("hoge");
        }

        if (ConfigInput.GetKeyDown(KeyData.Circle))
        {
            Debug.Log("fuga");
        }

        if (ConfigInput.GetKey(KeyData.Circle))
        {
            Debug.Log("piyo");
        }        

	}
}
