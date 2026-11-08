using DiGi.VoTT.Classes;
using System.IO;
using System.Text.Json;

namespace DiGi.VoTT
{
    public static partial class Modify
    {
        /// <summary>Reads a <see cref="VoTTModel"/> from the specified file path.</summary>
        /// <param name="path">The path to the JSON file containing the model data.</param>
        /// <returns>A <see cref="VoTTModel"/> instance if the file is successfully read and deserialized; otherwise, null.</returns>
        public static VoTTModel? Read(string? path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return null;
            }

            string json = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }

            VoTTModel? result = JsonSerializer.Deserialize<VoTTModel>(json);

            return result;
        }
    }
}
