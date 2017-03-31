using System;
using System.Collections.Generic;
using System.Text;

    public class textConfig
    {
        public textConfig(params string[] str)
        {
            this.id = int.Parse(str[0]);
            this.text = str[1];
        }
        public int id;
        public string text;
    }
