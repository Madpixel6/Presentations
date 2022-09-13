using System;
using System.Collections.Generic;
using System.IO;

namespace MemLeakEvents.Xml;

public class XmlWithCache
{
    public void Run(int iterations = 10000)
    {
        var key = Guid.NewGuid();
        for (var i = 0; i < iterations; i++)
        {
            var s = XmlSerializerCache.Create(typeof(object), key.ToString());
            s.Serialize(Stream.Null, new object());
        }
    }
    
    internal class XmlSerializerCache 
    {
        private static readonly object Lock = new();
        private static readonly Dictionary<string, System.Xml.Serialization.XmlSerializer> Cache = new();

        public static System.Xml.Serialization.XmlSerializer Create(Type type, string key)
        {
            lock (Lock)
            {
                if (!Cache.ContainsKey(key))
                {
                    Cache.Add(key, new System.Xml.Serialization.XmlSerializer(type, new Type[] { }));
                }

                return Cache[key];
            }
        }
    }
}