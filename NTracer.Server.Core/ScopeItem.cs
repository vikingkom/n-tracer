using System;
using System.Collections.Generic;
using System.Linq;

namespace NTracer.Server.Core
{
    public class ScopeItem
    {

        private Dictionary<object, object> _localProperties = new Dictionary<object, object>();
        private Dictionary<object, object> _globalProperties = new Dictionary<object, object>();

        public DateTimeOffset CreationDate { get; set; }
        public string Id { get; set; }
        public ScopeItem ParentScope { get; set; }
        public void SetLocalProperties(IDictionary<object, object> properties)
        {
            _localProperties = properties.Union(_localProperties.Where(w => !properties.ContainsKey(w.Key))).Where(w => w.Value != null).ToDictionary(k => k.Key, v => v.Value);
        }

        public void SetLocalProperty(object key, object value)
        {
            if (value == null)
                _localProperties.Remove(key);
            else
                _localProperties[key] = value;
        }

        public void SetGlobalProperties(IDictionary<object, object> properties)
        {
            _globalProperties = properties.Union(_globalProperties.Where(w => !properties.ContainsKey(w.Key))).Where(w => w.Value != null).ToDictionary(k => k.Key, v => v.Value);
            SetLocalProperties(properties);
        }

        public void SetGlobalProperty(object key, object value)
        {
            if (value == null)
                _globalProperties.Remove(key);
            else
                _globalProperties[key] = value;
            SetLocalProperty(key, value);
        }
    }
}