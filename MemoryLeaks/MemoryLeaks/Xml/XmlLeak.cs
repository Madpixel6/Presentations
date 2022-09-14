using System;
using System.IO;
using System.Xml.Serialization;

namespace MemLeakEvents.Xml;

public class XmlLeak
{
    public void Run(int iterations = 10000)
    {
        for (var i = 0; i < iterations; i++)
        {
            var s = new XmlSerializer(typeof(object), new Type[] { });
            s.Serialize(Stream.Null, new object { });
        }
    }
}