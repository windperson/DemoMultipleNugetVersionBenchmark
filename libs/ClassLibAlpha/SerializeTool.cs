using Newtonsoft.Json;

namespace ClassLibAlpha;

// ReSharper disable once UnusedType.Global
public static class SerializeTool
{
    /**
     * Serializes an object to a JSON string.
     * 
     * @param obj The object to serialize.
     * @return The JSON string.
     */
    // ReSharper disable once InconsistentNaming
    // ReSharper disable once UnusedMember.Global
    public static string ToJSON(object obj)
    {
        return JsonConvert.SerializeObject(obj, Formatting.Indented);
    }
}