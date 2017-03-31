using UnityEngine;
using System.Collections;

public class GameRoot : MonoBehaviour {

	void Start ()
    {
        #region//创建永恒物体
        DontDestroyOnLoad(this.gameObject);
        #endregion
        StartCoroutine("configStart");
    }
    //配置文件初始化
    void configStart()
    {
        FileReader.Instance.FileReaderFromName("listConfig");
        foreach (listConfig l in FileReader.Instance.listConfigData)
        {
            FileReader.Instance.FileReaderFromName(l.configName);
        }
    }

    public void alarm(string message,string fatherPointName)
    {
        //todo
    }

}
