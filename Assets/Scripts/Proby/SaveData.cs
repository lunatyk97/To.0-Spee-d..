using UnityEngine;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Runtime.Serialization;
using System.Reflection;

[Serializable()]
public class SaveData : ISerializable
{
    public bool zmienna1 = false;
    public float zmienna2 = 42;
    public int zmienna3 = 3;

    public SaveData() { }

    public SaveData(SerializationInfo info, StreamingContext ctxt)
    {
        zmienna1 = (bool)info.GetValue("zmienna1", typeof(bool));
        zmienna2 = (float)info.GetValue("zmienna2", typeof(float));
        zmienna3 = (int)info.GetValue("zmienna3", typeof(int));
    }

    public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
    {
        info.AddValue("zmienna1", (zmienna1));
        info.AddValue("zmienna2", (zmienna2));
        info.AddValue("zmienna3", (zmienna3));
    }
}
