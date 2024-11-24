using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BasicSaveSystem
{
    public static void SaveIntData(int amount, string fileName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{fileName}.hh";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        int data = amount;

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static int LoadIntData(string fileName)
    {
        string path = Application.persistentDataPath + $"/{fileName}.hh";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            int data = (int)formatter.Deserialize(fileStream);
            fileStream.Close();

            return data;
        }
        else
        {
            return 0;
        }
    }
    
    public static void SaveBoolData(bool amount, string fileName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + $"/{fileName}.hh";
        FileStream fileStream = new FileStream(path, FileMode.Create);

        bool data = amount;

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static bool LoadBoolData(string fileName)
    {
        string path = Application.persistentDataPath + $"/{fileName}.hh";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            bool data = (bool)formatter.Deserialize(fileStream);
            fileStream.Close();

            return data;
        }
        else
        {
            return false;
        }
    }
}
