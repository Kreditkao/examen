using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class DictionaryApp
{
    private Dictionary<string, Dictionary<string, List<string>>> dictionaries = new Dictionary<string, Dictionary<string, List<string>>>();
    private string dataFilePath = "dictionaries.txt";

    public void Run()
    {
        LoadDictionaries();
        MainMenu();
    }

    private void MainMenu()
    {
        while (true)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("\n--- Головне меню ---");
            Console.WriteLine("1. Створити словник");
            Console.WriteLine("2. Додати слово");
            Console.WriteLine("3. Редагувати слово");
            Console.WriteLine("4. Видалити слово");
            Console.WriteLine("5. Знайти переклад");
            Console.WriteLine("6. Експорт слова");
            Console.WriteLine("7. Вийти");

            Console.Write("Виберіть опцію: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateDictionary();
                    break;
                case "2":
                    AddWord();
                    break;
                case "3":
                    EditWord();
                    break;
                case "4":
                    DeleteWord();
                    break;
                case "5":
                    FindTranslation();
                    break;
                case "6":
                    ExportWord();
                    break;
                case "7":
                    SaveDictionaries();
                    return;
                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    private void CreateDictionary()
    {
        Console.Write("Введіть назву словника (наприклад, англо-український): ");
        string dictionaryName = Console.ReadLine();
        if (!dictionaries.ContainsKey(dictionaryName))
        {
            dictionaries[dictionaryName] = new Dictionary<string, List<string>>();
            Console.WriteLine($"Словник '{dictionaryName}' створено.");
        }
        else
        {
            Console.WriteLine($"Словник '{dictionaryName}' вже існує.");
        }
    }

    private void AddWord()
    {
        Console.Write("Введіть назву словника: ");
        string dictionaryName = Console.ReadLine();
        if (dictionaries.ContainsKey(dictionaryName))
        {
            Console.Write("Введіть слово: ");
            string word = Console.ReadLine();
            Console.Write("Введіть переклад (розділіть комами, якщо є декілька): ");
            string translationsInput = Console.ReadLine();
            List<string> translations = translationsInput.Split(',').Select(t => t.Trim()).ToList();

            if (dictionaries[dictionaryName].ContainsKey(word))
            {
                dictionaries[dictionaryName][word].AddRange(translations);
            }
            else
            {
                dictionaries[dictionaryName][word] = translations;
            }
            Console.WriteLine("Слово та переклад додано.");
        }
        else
        {
            Console.WriteLine($"Словник '{dictionaryName}' не знайдено.");
        }
    }

    private void EditWord()
    {
        Console.Write("Введіть назву словника: ");
        string dictionaryName = Console.ReadLine();
        if (dictionaries.ContainsKey(dictionaryName))
        {
            Console.Write("Введіть слово для редагування: ");
            string word = Console.ReadLine();
            if (dictionaries[dictionaryName].ContainsKey(word))
            {
                Console.Write("Введіть новий переклад (розділіть комами, якщо є декілька): ");
                string translationsInput = Console.ReadLine();
                List<string> translations = translationsInput.Split(',').Select(t => t.Trim()).ToList();
                dictionaries[dictionaryName][word] = translations;
                Console.WriteLine("Слово та переклад оновлено.");
            }
            else
            {
                Console.WriteLine("Слово не знайдено.");
            }
        }
        else
        {
            Console.WriteLine($"Словник '{dictionaryName}' не знайдено.");
        }
    }

    private void DeleteWord()
    {
        Console.Write("Введіть назву словника: ");
        string dictionaryName = Console.ReadLine();
        if (dictionaries.ContainsKey(dictionaryName))
        {
            Console.Write("Введіть слово для видалення: ");
            string word = Console.ReadLine();
            if (dictionaries[dictionaryName].ContainsKey(word))
            {
                dictionaries[dictionaryName].Remove(word);
                Console.WriteLine("Слово та переклади видалено.");
            }
            else
            {
                Console.WriteLine("Слово не знайдено.");
            }
        }
        else
        {
            Console.WriteLine($"Словник '{dictionaryName}' не знайдено.");
        }
    }

    private void FindTranslation()
    {
        Console.Write("Введіть назву словника: ");
        string dictionaryName = Console.ReadLine();
        if (dictionaries.ContainsKey(dictionaryName))
        {
            Console.Write("Введіть слово для пошуку: ");
            string word = Console.ReadLine();
            if (dictionaries[dictionaryName].ContainsKey(word))
            {
                Console.WriteLine($"Переклади: {string.Join(", ", dictionaries[dictionaryName][word])}");
            }
            else
            {
                Console.WriteLine("Слово не знайдено.");
            }
        }
        else
        {
            Console.WriteLine($"Словник '{dictionaryName}' не знайдено.");
        }
    }

    private void ExportWord()
    {
        Console.Write("Введіть назву словника: ");
        string dictionaryName = Console.ReadLine();
        if (dictionaries.ContainsKey(dictionaryName))
        {
            Console.Write("Введіть слово для експорту: ");
            string word = Console.ReadLine();
            if (dictionaries[dictionaryName].ContainsKey(word))
            {
                string fileName = $"{word}.txt";
                File.WriteAllLines(fileName, dictionaries[dictionaryName][word]);
                Console.WriteLine($"Переклади слова '{word}' експортовано до файлу '{fileName}'.");
            }
            else
            {
                Console.WriteLine("Слово не знайдено.");
            }
        }
        else
        {
            Console.WriteLine($"Словник '{dictionaryName}' не знайдено.");
        }
    }

    private void LoadDictionaries()
    {
        if (File.Exists(dataFilePath))
        {
            string[] lines = File.ReadAllLines(dataFilePath);
            for (int i = 0; i < lines.Length; i += 2)
            {
                string dictionaryName = lines[i];
                string[] words = lines[i + 1].Split(';');
                dictionaries[dictionaryName] = new Dictionary<string, List<string>>();
                foreach (string wordData in words)
                {
                    if (string.IsNullOrEmpty(wordData)) continue;
                    string[] parts = wordData.Split(':');
                    string word = parts[0];
                    List<string> translations = parts[1].Split(',').ToList();
                    dictionaries[dictionaryName][word] = translations;
                }
            }
        }
    }

    private void SaveDictionaries()
    {
        List<string> lines = new List<string>();
        foreach (var dictionary in dictionaries)
        {
            lines.Add(dictionary.Key);
            lines.Add(string.Join(";", dictionary.Value.Select(kv => $"{kv.Key}:{string.Join(",", kv.Value)}")));
        }
        File.WriteAllLines(dataFilePath, lines);
    }

    public static void Main(string[] args)
    {
        new DictionaryApp().Run();
    }
}
