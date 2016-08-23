本プログラムはUnity KeyCode拡張プログラムです。

	KeyCodeの取得、保存を行えます。
	また、キーボード、ゲームパッドの入力を一つのコードで簡単に取得することができます。

使い方

	このプログラムはInputData.csを基に動作します。
	キーパターンの拡張、デフォルトキーの変更はInputData.csを編集してください。(やり方は後述します。)

	呼び出すプログラムの最初に"using KeyConfig;"を追加してください。
	Unity標準のInputと同様に以下の様に入力を取得することができます。

		if(ConfigInput.GetKeyDown(KeyData.Circle)){
			Debug.Log("hoge");
		}

	KeyCodeで取得できるキーであれば何でも対応できるはずです(たぶん

キーパターンの拡張、デフォルトキーの設定

	InputData.csを編集します。

		public enum KeyData{

		}

	以上の中に追加、編集してください。
	また、項目数を増やした場合、デフォルトキーの変更をする場合は

		public enum DefaultKey{
			//キーボード用を想定
		}

		public enum DefaultButton{
			//ゲームパッド用を想定
		}

	以上の中に同様の数KeyCodeの値を文字列で追加、編集してください。

CnfigInput.cs

	Static 関数

	GetKey		KeyData によって識別されるキーを押している間、true を返します。
	GetKeyDown	KeyData によって識別されるキーを押したフレームの間だけ true を返します。
	GetKeyUp	KeyData によって識別されるキーを離したフレームの間だけ true を返します。
	ResetKey	InputDataに基づいてキーコンフィグデータを初期化します。
	SetKeyCode	キーコンフィグデータを更新します。キーボード用を想定。
	SetButtonCode	キーコンフィグデータを更新します。ゲームパッド用を想定。
	GetKeyCode	キーコンフィグデータを基にkeyDataに設定された値を返します。
	GetButtonCode	キーコンフィグデータを基にkeyDataに設定された値を返します。
	InputKeyCode	現在押されているKeyCodeを返します。

