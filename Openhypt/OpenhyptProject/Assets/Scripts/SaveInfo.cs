using System.IO;
using System.Xml;
using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class SaveInfo : MonoBehaviour
{
    public static bool SaveDataXml(string path, XmlDocument xml_doc)
    {
        string _path = SaveInfo.GetGlobalPath(path);
        try
        {
            string _dirPath = _path.Substring(0, _path.LastIndexOf("/"));
            if (!Directory.Exists(_dirPath))
            {
                Directory.CreateDirectory(_dirPath);
            }
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.CloseOutput = true;
            XmlWriter writer = XmlWriter.Create(_path, settings);
            xml_doc.Save(writer);
            writer.Flush();
            writer.Close();
            System.IDisposable exit_writer = writer;
            exit_writer.Dispose();
            return true;
        }
        catch(System.Exception err)
        {
            Debug.LogError(string.Format("Couldnt save data to {0}! contact magii for help", _path));
            return false;
        }
    }

    public static bool SaveData(string path, string data)
    {
        string _path = SaveInfo.GetGlobalPath(path);
        try
        {
            string _dirPath = _path.Substring(0, _path.LastIndexOf("/"));
            if (!Directory.Exists(_dirPath))
            {
                Directory.CreateDirectory(_dirPath);
            }
            File.WriteAllText(_path, data);
            return true;
        }
        catch(System.Exception err)
        {
            Debug.LogError(string.Format("Couldnt save data to {0}! contact magii for help", _path));
            return false;
        }
    }

    public static string LoadData(string path)
    {
        string _path = SaveInfo.GetGlobalPath(path);
        try
        {
            if (File.Exists(_path))
            {
                return File.ReadAllText(_path);
            }
        }
        catch(System.Exception err)
        {
            Debug.LogError(string.Format("Couldnt load data at {0}! contact magii for help", _path));
            throw err;
        }
        return "";
    }

    public static bool HasData(string path)
    {
        string _path = SaveInfo.GetGlobalPath(path);
        if (System.IO.File.Exists(_path))
        {
            return true;
        }
        return false;
    }

    public static string GetGlobalPath(string path)
    {
        int i = 0;
        string _path = SaveInfo.GetAppData() + "/Zerahypt/Save";
        string[] _pathParts = path.Split(new char[] {"/"[0]});
        i = 0;
        while (i < _pathParts.Length)
        {
            _path = _path + ("/" + _pathParts[i]);
            i++;
        }
        return _path + ".dat";
    }

    public static string Encrypt(string data)//return DataToBytes(newString);
    {
        int i = 0;
        string newString = null;
        int maxValue = (int) char.MaxValue;
        i = 0;
        while (i < data.Length)
        {
            int _char = (int) data[i];
            char _newChar = (char) ((_char + 1) - (maxValue / 255));
            newString = newString + _newChar;
            i++;
        }
        return newString;
    }

    public static string Decrypt(string data)
    {
        int i = 0;
        //data = BytesToData(data);
        string newString = null;
        int maxValue = (int) char.MaxValue;
        i = 0;
        while (i < data.Length)
        {
            int _char = (int) data[i];
            char _newChar = (char) ((_char - 1) + (maxValue / 255));
            newString = newString + _newChar;
            i++;
        }
        return newString;
    }

    private static string DataToBytes(string data)
    {
        int i = 0;
        string _data = null;
        i = 0;
        while (i < data.Length)
        {
            int _byte = (int) data[i];
            _data = _data + (_byte + "_");
            i++;
        }
        return _data;
    }

    private static string BytesToData(string bytes)
    {
        int i = 0;
        string[] _data = bytes.Split(new char[] {"_"[0]});
        string _returnData = null;
        i = 0;
        while (i < (_data.Length - 1))
        {
            char _byte = (char) int.Parse(_data[i]);
            _returnData = _returnData + _byte;
            i++;
        }
        return _returnData;
    }

    public static string GetAppData()
    {
        return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
    }

}