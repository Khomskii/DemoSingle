using UnityEngine;
using System.Collections;
using GameProtocol;

public class LoginHandler : MonoBehaviour, IHandler
{
    public void MessageReceive(SocketModel model)
    {
        switch (model.command)
        {
            case LoginProtocol.LOGIN_SRES:
                //登录成功
                Application.LoadLevel(1);
                break;
            case LoginProtocol.REG_SRES:
                break;
        }
    }
}
