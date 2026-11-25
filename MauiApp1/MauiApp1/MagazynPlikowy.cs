using KatalogProduktow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;


namespace MauiApp1
{
    internal class MagazynPlikowy
    {
        private static string sciezkaPliku =>
            Path.Combine(FileSystem.Current.AppDataDirectory, "bazaProdoktow.json");
    public static async Task ZapiszAsync(List<Produkt> produkty)
        {
            string json = JsonSerializer.Serialize(produkty,

                    new JsonSerializerOptions { WriteIndented = true });

            await File.WriteAllTextAsync(sciezkaPliku, json);
        }
        public static async Task<List<Produkt>> OdczytajAsync()
        {
            if (!File.Exists(sciezkaPliku))
                return new List<Produkt>();
            string json = await File.ReadAllTextAsync(sciezkaPliku);
            return JsonSerializer.Deserialize<List<Produkt>>(json) ?? new List<Produkt>();
        }
    }
}