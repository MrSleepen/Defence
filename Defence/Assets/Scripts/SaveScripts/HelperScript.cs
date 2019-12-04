﻿
using System.IO;
using System.Xml.Serialization;
public static class HelperScript
{
    //Serialize
    public static string Serialize<T>(this T toSerialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringWriter writer = new StringWriter();
        xml.Serialize(writer, toSerialize);
        return writer.ToString();
    }

    //Deserialize

    public static T Deserialize<T>(this string toDesialize)
    {
        XmlSerializer xml = new XmlSerializer(typeof(T));
        StringReader reader = new StringReader(toDesialize);
        return (T)xml.Deserialize(reader);
    }

}



