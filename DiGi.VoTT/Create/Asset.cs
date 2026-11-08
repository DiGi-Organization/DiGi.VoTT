using DiGi.VoTT.Classes;
using System.Globalization;

namespace DiGi.VoTT
{
    public static partial class Create
    {
        /// <summary>Creates an <see cref="Asset"/> instance using the specified identifier.</summary>
        /// <param name="id">The unique identifier of the asset.</param>
        /// <returns>An <see cref="Asset"/> object if a valid identifier is provided; otherwise, <c>null</c>.</returns>
        public static Asset? Asset_ById(string? id)
        {
            if (id == null)
            {
                return null;
            }

            Asset result = new()
            {
                id = id,
            };

            return result;
        }

        /// <summary>Creates an <see cref="Asset"/> instance from the specified file path.</summary>
        /// <param name="path">The system path to the asset file.</param>
        /// <returns>An <see cref="Asset"/> object if the file exists at the given path; otherwise, <c>null</c>.</returns>
        public static Asset? Asset(string? path)
        {
            if (string.IsNullOrWhiteSpace(path) || !System.IO.File.Exists(path))
            {
                return null;
            }

            Asset result = new()
            {
                format = System.IO.Path.GetExtension(path).Substring(1),
                name = System.IO.Path.GetFileName(path),
                path = string.Format(CultureInfo.CurrentCulture, "file:{0}", path!.Replace(" ", "%20").Replace(@"\", "/")),
                size = Size(path),
                state = (short)Enums.AssetState.NotVisited,
                type = (short)Enums.AssetType.Image,
            };

            return result;
        }
    }
}
