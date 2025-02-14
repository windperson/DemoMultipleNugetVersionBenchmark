using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace ClassLibBeta;

// ReSharper disable once UnusedType.Global
public class SerializeTool
{
    private static readonly JsonSerializerSettings Settings = new()
    {
        Formatting = Formatting.Indented
    };

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
        return JsonConvert.SerializeObject(obj, Settings);
    }
}