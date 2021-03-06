﻿using System;
using System.ComponentModel;

namespace XamlTest.Transport
{
    public class DefaultSerializer : ISerializer
    {
        public virtual bool CanSerialize(Type _) => true;

        public virtual string Serialize(Type type, object? value)
        {
            if (value is null) return "";
            var converter = TypeDescriptor.GetConverter(type);
            return converter.ConvertToInvariantString(value) ?? "";
        }

        public virtual object? Deserialize(Type type, string value)
        {
            var converter = TypeDescriptor.GetConverter(type);
            if (converter.CanConvertFrom(typeof(string)))
            {
                return converter.ConvertFromInvariantString(value);
            }
            return value;
        }
    }
}
