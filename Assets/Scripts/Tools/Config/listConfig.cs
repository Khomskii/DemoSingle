using UnityEngine;
using System.Collections;

public class listConfig {
    public listConfig(params string[] str)
        {
            this.id = int.Parse(str[0]);
            this.configName = str[1];
        }
        public int id;
        public string configName;

}
