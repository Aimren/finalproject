using System;
using System.Collections.Generic;
using System.Text;

namespace mypro
{
    public interface ISharPref
    {
        string getItem(string key);
        void setItem(string key, string item);
        int getIndex(string key);
        void setIndex(string key, int index);
        int getDersId(string key);
        void setDersId(string key, int id);
        string getElement(string key);
        void setElement(string key, string id);
        void clearShar();
    }
}
