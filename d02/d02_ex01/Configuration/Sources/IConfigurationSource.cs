using System.Collections;

namespace d02_ex01.Sources
{
    public interface IConfigurationSource
    {
        Hashtable ReadHashtable();
        int Priority { get; }
    }
}