�{�v���O������Unity KeyCode�g���v���O�����ł��B

	KeyCode�̎擾�A�ۑ����s���܂��B
	�܂��A�L�[�{�[�h�A�Q�[���p�b�h�̓��͂���̃R�[�h�ŊȒP�Ɏ擾���邱�Ƃ��ł��܂��B

�g����

	���̃v���O������InputData.cs����ɓ��삵�܂��B
	�L�[�p�^�[���̊g���A�f�t�H���g�L�[�̕ύX��InputData.cs��ҏW���Ă��������B(�����͌�q���܂��B)

	�Ăяo���v���O�����̍ŏ���"using KeyConfig;"��ǉ����Ă��������B
	Unity�W����Input�Ɠ��l�Ɉȉ��̗l�ɓ��͂��擾���邱�Ƃ��ł��܂��B

		if(ConfigInput.GetKeyDown(KeyData.Circle)){
			Debug.Log("hoge");
		}

	KeyCode�Ŏ擾�ł���L�[�ł���Ή��ł��Ή��ł���͂��ł�(���Ԃ�

�L�[�p�^�[���̊g���A�f�t�H���g�L�[�̐ݒ�

	InputData.cs��ҏW���܂��B

		public enum KeyData{

		}

	�ȏ�̒��ɒǉ��A�ҏW���Ă��������B
	�܂��A���ڐ��𑝂₵���ꍇ�A�f�t�H���g�L�[�̕ύX������ꍇ��

		public enum DefaultKey{
			//�L�[�{�[�h�p��z��
		}

		public enum DefaultButton{
			//�Q�[���p�b�h�p��z��
		}

	�ȏ�̒��ɓ��l�̐�KeyCode�̒l�𕶎���Œǉ��A�ҏW���Ă��������B

CnfigInput.cs

	Static �֐�

	GetKey		KeyData �ɂ���Ď��ʂ����L�[�������Ă���ԁAtrue ��Ԃ��܂��B
	GetKeyDown	KeyData �ɂ���Ď��ʂ����L�[���������t���[���̊Ԃ��� true ��Ԃ��܂��B
	GetKeyUp	KeyData �ɂ���Ď��ʂ����L�[�𗣂����t���[���̊Ԃ��� true ��Ԃ��܂��B
	ResetKey	InputData�Ɋ�Â��ăL�[�R���t�B�O�f�[�^�����������܂��B
	SetKeyCode	�L�[�R���t�B�O�f�[�^���X�V���܂��B�L�[�{�[�h�p��z��B
	SetButtonCode	�L�[�R���t�B�O�f�[�^���X�V���܂��B�Q�[���p�b�h�p��z��B
	GetKeyCode	�L�[�R���t�B�O�f�[�^�����keyData�ɐݒ肳�ꂽ�l��Ԃ��܂��B
	GetButtonCode	�L�[�R���t�B�O�f�[�^�����keyData�ɐݒ肳�ꂽ�l��Ԃ��܂��B
	InputKeyCode	���݉�����Ă���KeyCode��Ԃ��܂��B

