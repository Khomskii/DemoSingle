using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameProtocol;
using GameProtocol.dto;

public class LoginView : MonoBehaviour {

    GameObject regView;
    InputField inputAccount;
    InputField inputPassword;
    InputField regAccount;
    InputField regPassword;
    InputField regPasswordAgain;
    GameRoot gt;
        
	// Use this for initialization
	void Start () {
        regView = GameObject.Find("RegView");
        inputAccount = GameObject.Find("InputAccount").GetComponent<InputField>();
        inputPassword = GameObject.Find("InputPassWord").GetComponent<InputField>();
        regAccount = GameObject.Find("RegAccount").GetComponent<InputField>();
        regPassword = GameObject.Find("RegPassword").GetComponent<InputField>();
        regPasswordAgain = GameObject.Find("RegPasswordAgain").GetComponent<InputField>();
        GameObject.Find("ButtonOnput").GetComponent<Button>().onClick.AddListener(Onput);
        GameObject.Find("ButtonReg").GetComponent<Button>().onClick.AddListener(Onreg);
        GameObject.Find("ButtonRegYes").GetComponent<Button>().onClick.AddListener(reg);
        GameObject.Find("ButtonRegNo").GetComponent<Button>().onClick.AddListener(regCancel);
        regView.SetActive(false);
        gt = GameObject.Find("GameRoot").GetComponent<GameRoot>();
	}

    void Onput() {
        //正式代码
        if (inputAccount.text == string.Empty || inputPassword.text == string.Empty)
        {
            return;
        }
        if (inputAccount.text.Length >= 6 && inputPassword.text.Length >= 6)
        {
            //发送登录申请
            AccountInfoDTO dto=new AccountInfoDTO();
            dto.account=inputAccount.text;
            dto.password=inputPassword.text;
            NetIO.Instance.write(Protocol.TYPE_LOGIN, 0, LoginProtocol.LOGIN_CREQ, dto);
            reFresh();
            return;
        }
        else if (inputAccount.text.Length < 6)
        {
            //警告登录名不合法
            gt.alarm("登录名不合法", "Canvas");
            reFresh();
            return;
        }
        else if (inputPassword.text.Length < 6)
        {
            //警告密码不合法
            gt.alarm("密码不合法", "Canvas");
            reFresh();
            return;
        }
    }

    void Onreg() {
        if (regView == null)
        {
            regView = GameObject.Find("RegView");
        }
        regView.SetActive(true);
    }

    void reFresh()
    {
        inputAccount.text = string.Empty;
        inputPassword.text = string.Empty;
        regAccount.text = string.Empty;
        regPassword.text = string.Empty;
        regPasswordAgain.text = string.Empty;
    }
    //注册函数
    void reg()
    {
        if (regAccount.text == string.Empty)
        {
            //弹窗提示注册用户名不能为空
            gt.alarm("注册用户名不能为空", "Canvas");
            reFresh();
            return;
        }
        if (regAccount.text.Length < 6)
        {
            //弹窗提示用户名不合法
            gt.alarm("用户名不合法", "Canvas");
            reFresh();
            return;
        }
        if (regPassword.text == string.Empty)
        {
            //提示请输入密码
            gt.alarm("请输入密码", "Canvas");
            reFresh();
            return;
        }
        if (regPasswordAgain.text == string.Empty)
        {
            //提示请再次输入密码
            gt.alarm("请再次输入密码", "Canvas");
            reFresh();
            return;
        }
        if (regPassword.text != regPasswordAgain.text)
        {
            //两次输入密码不同
            gt.alarm("两次输入密码不同", "Canvas");
            reFresh();
            return;
        }
        if (regPassword.text.Length < 6)
        {
            //密码长度太短
            gt.alarm("密码长度太短", "Canvas");
            reFresh();
            return;
        }
        //发送注册消息
        AccountInfoDTO dto=new AccountInfoDTO();
        dto.account=inputAccount.text;
        dto.password=inputPassword.text;
        NetIO.Instance.write(Protocol.TYPE_LOGIN, 0, LoginProtocol.LOGIN_CREQ, dto);
    }

    void regCancel() {
        reFresh();
        regView.SetActive(false);
    }
}
