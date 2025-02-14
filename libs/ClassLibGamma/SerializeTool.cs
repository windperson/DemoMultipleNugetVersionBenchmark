using System.Text.Json;

namespace ClassLibGamma;

// ReSharper disable once UnusedType.Global
public static class SerializeTool
{
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };

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
        return JsonSerializer.Serialize(obj, Options);
    }
}