using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FileReader : NullMonoSingleton<FileReader> {
    //数据生成的对象字典
    public Dictionary<int,textConfig> textConfigData = new Dictionary<int,textConfig>();
    public List<listConfig> listConfigData = new List<listConfig>();
    public void FileReaderFromName(string name)
    {
        TextAsset textAt = Resources.Load("CSV/"+name, typeof(TextAsset)) as TextAsset;
        string[] lineArray = textAt.text.Split("\r"[0]);
        string[][] Array = new string[lineArray.Length-1][];
        for (int i = 1; i < lineArray.Length; i++)
        {
            Array[i-1] = lineArray[i].Split(',');
        }
        DataObjectCreator(name, Array);
    }
    public void DataObjectCreator(string name,params string[][] str)
    {
        switch(name){
            case "textConfig": //数据文件的处理方法
                    textConfigData.Clear();
                    for (int i = 0; i < str.GetLength(0); i++)
                    {
                        try
                        {
                            textConfigData.Add(i + 1, new textConfig(str[i]));
                        }
                        catch { }
                    }
                    break;
            case "listConfig":
                textConfigData.Clear();
                for(int i=0;i<str.GetLength(0);i++){
                    try
                    {
                        listConfigData.Add(new listConfig(str[i]));
                    }
                    catch { }
                }
                    break; 
        }
    }
    /*使用方法
     * FileReader.Instance.FileReaderFromName("name");
     */

}
