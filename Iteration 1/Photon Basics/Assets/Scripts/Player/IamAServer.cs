using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[System.Serializable]
public class IamAServer
{
    public bool IAmAServer;

    public System.DateTime StartedAt;

    public static byte[] SerializeIamAServer(object obj)
    {
        if(obj == null)
        {
            return null;
        }
        //так делать плохо, т.к. мы посылаем кучу ненужной информации но для примера сойдёт
        var json = JsonUtility.ToJson((IamAServer)obj);
        var array = Encoding.UTF8.GetBytes(json);

        return array;
    }

    public static object DeserializeIamAServer(byte[] bytes)
    {
        if(bytes != null && bytes.Length < 1)
        {
            return null;
        }

        var json = Encoding.UTF8.GetString(bytes);
        var obj = JsonUtility.FromJson<IamAServer>(json);

        return obj;
    }
}
