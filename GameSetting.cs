using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSetting : MonoBehaviour {
	
	public GameObject InitSubPanel;		//开始界面的初始面板
	public GameObject StartSubPanel;	//点击“开始”按钮后的面板
	public GameObject OptionSubPanel;	//点击“选项”按钮后的面板
    public GameObject GameMessagePanel;
    public GameObject NextGameMessagePanel;

	public InputField usernameInputField;	//用户名输入框组件
	public Toggle soundToggle;				//声音开关

	//“开战”按钮调用的函数
	public void StartGame(){
		PlayerPrefs.SetString ("Username", usernameInputField.text);	//将用户输入的用户名保存在本地，标识名为“Username”
		SceneManager.LoadScene("level1");								//加载游戏场景
	}

	//声音开关
	public void SwitchSound(){
		if (soundToggle.isOn) PlayerPrefs.SetInt ("SoundOff", 0);	//当声音开关开启时，将声音开关设置保存在本地，标识名为“SoundOff”，值为0
		else PlayerPrefs.SetInt ("SoundOff", 1);					//当声音开关开启时，将声音开关设置保存在本地，标识名为“SoundOff”，值为1
	}

	//“退出”按钮调用的函数
	public void ExitGame(){
		Application.Quit ();	//退出游戏
	}

	//初始化函数
	void Start () {
		ActiveInitPanel ();	//调用ActiveInitPanel函数，启用初始面板，禁用其他面板
	}

	//启用初始面板，禁用其他面板
	public void ActiveInitPanel(){
        NextGameMessagePanel.SetActive(false);
        GameMessagePanel.SetActive(false);
		InitSubPanel.SetActive (true);
		StartSubPanel.SetActive (false);
		OptionSubPanel.SetActive (false);
	}

	//启用开始面板，禁用其他面板
	public void ActiveStartPanel(){
        NextGameMessagePanel.SetActive(false);
        GameMessagePanel.SetActive(false);
        InitSubPanel.SetActive (false);
		StartSubPanel.SetActive (true);
		OptionSubPanel.SetActive (false);
	}

	//启用选项面板，禁用其他面板
	public void ActiveOptionPanel(){
        NextGameMessagePanel.SetActive(false);
        GameMessagePanel.SetActive(false);
        InitSubPanel.SetActive (false);
		StartSubPanel.SetActive (false);
		OptionSubPanel.SetActive (true);
	}

    public void ActiveGameMessagePanel() {
        NextGameMessagePanel.SetActive(false);
        GameMessagePanel.SetActive(true);
        InitSubPanel.SetActive(false);
        StartSubPanel.SetActive(false);
        OptionSubPanel.SetActive(false);
    }

    public void ActiveNextGameMessagePanel() {
        NextGameMessagePanel.SetActive(true);
        GameMessagePanel.SetActive(false);
        InitSubPanel.SetActive(false);
        StartSubPanel.SetActive(false);
        OptionSubPanel.SetActive(false);
    }
}
