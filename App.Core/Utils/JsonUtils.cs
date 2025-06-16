using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Core.Utils
{
    public static class JsonUtils
    {
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static async Task<List<T>> ReadDataAsync<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            try
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    if (stream.Length == 0)
                    {
                        return new List<T>();
                    }

                    var data = await JsonSerializer.DeserializeAsync<List<T>>(stream, _options);
                    return data ?? new List<T>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saat membaca file JSON: {filePath}. Error: {ex.Message}");
                return new List<T>();
            }
        }

        public static async Task WriteDataAsync<T>(string filePath, List<T> data)
        {
            try
            {
                string? directory = Path.GetDirectoryName(filePath);
                if (directory != null)
                {
                    Directory.CreateDirectory(directory);
                }

                using (FileStream stream = File.Create(filePath))
                {
                    await JsonSerializer.SerializeAsync(stream, data, _options);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saat menulis file JSON: {filePath}. Error: {ex.Message}");
                throw;
            }
        }
    }
}
