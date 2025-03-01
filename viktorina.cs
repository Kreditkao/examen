using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class User
{
    public string Login { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
    public List<QuizResult> Results { get; set; } = new List<QuizResult>();
}

public class QuizResult
{
    public string Category { get; set; }
    public int Score { get; set; }
    public DateTime Date { get; set; }
}

public class Question
{
    public string Text { get; set; }
    public List<string> Options { get; set; }
    public List<int> CorrectAnswers { get; set; }
}

public class Quiz
{
    public string Category { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();
}

public class QuizApp
{
    private List<User> users = new List<User>();
    private List<Quiz> quizzes = new List<Quiz>();
    private User currentUser;

    public QuizApp()
    {
        // Приклади вікторин
        quizzes.Add(new Quiz
        {
            Category = "Історія",
            Questions = new List<Question>
    {
        new Question
        {
            Text = "Коли було засновано Київ?",
            Options = new List<string> { "482", "882", "988", "1019" },
            CorrectAnswers = new List<int> { 0 }
        },
        new Question
        {
            Text = "Хто був першим князем Київської Русі?",
            Options = new List<string> { "Аскольд", "Дір", "Олег", "Ігор" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Коли відбулося хрещення Київської Русі?",
            Options = new List<string> { "882", "988", "1019", "1147" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Хто з князів Київської Русі отримав прізвисько 'Мудрий'?",
            Options = new List<string> { "Володимир Великий", "Ярослав Мудрий", "Святослав Хоробрий", "Володимир Мономах" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Коли відбулася битва на річці Калка?",
            Options = new List<string> { "1223", "1240", "1362", "1410" },
            CorrectAnswers = new List<int> { 0 }
        },
        new Question
        {
            Text = "Хто був першим королем Галицько-Волинського князівства?",
            Options = new List<string> { "Ярослав Осмомисл", "Роман Мстиславич", "Данило Галицький", "Лев Данилович" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Коли відбулася Грюнвальдська битва?",
            Options = new List<string> { "1362", "1410", "1569", "1648" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Коли була укладена Люблінська унія?",
            Options = new List<string> { "1385", "1569", "1648", "1709" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Хто був першим гетьманом України?",
            Options = new List<string> { "Дмитро Вишневецький", "Богдан Хмельницький", "Іван Виговський", "Петро Сагайдачний" },
            CorrectAnswers = new List<int> { 0 }
        },
        new Question
        {
            Text = "Коли почалася Національно-визвольна війна під проводом Богдана Хмельницького?",
            Options = new List<string> { "1596", "1648", "1709", "1768" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Коли відбулася Полтавська битва?",
            Options = new List<string> { "1648", "1709", "1768", "1812" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Коли відбулося скасування кріпацтва в Російській імперії?",
            Options = new List<string> { "1783", "1861", "1905", "1917" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Коли була створена Українська Центральна Рада?",
            Options = new List<string> { "1905", "1917", "1922", "1939" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Хто був першим президентом Української Народної Республіки?",
            Options = new List<string> { "Михайло Грушевський", "Павло Скоропадський", "Симон Петлюра", "Євген Коновалець" },
            CorrectAnswers = new List<int> { 0 }
        },
        new Question
        {
            Text = "Коли відбувся Акт злуки УНР та ЗУНР?",
            Options = new List<string> { "1917", "1919", "1922", "1939" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Коли відбувся Голодомор в Україні?",
            Options = new List<string> { "1921-1923", "1932-1933", "1946-1947", "1986" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Коли була створена Українська повстанська армія (УПА)?",
            Options = new List<string> { "1917", "1922", "1939", "1942" },
            CorrectAnswers = new List<int> { 3 }
        },
        new Question
        {
            Text = "Коли Україна проголосила незалежність?",
            Options = new List<string> { "1989", "1990", "1991", "1996" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Коли була прийнята Конституція України?",
            Options = new List<string> { "1991", "1996", "2004", "2014" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Коли розпочалася Революція Гідності?",
            Options = new List<string> { "2004", "2010", "2013", "2014" },
            CorrectAnswers = new List<int> { 2 }
        }
    }
        });

        quizzes.Add(new Quiz
        {
            Category = "Біологія",
            Questions = new List<Question>
    {
        new Question
        {
            Text = "Що таке ДНК?",
            Options = new List<string> { "Дезоксирибонуклеїнова кислота", "Рибонуклеїнова кислота", "Амінокислота", "Жирна кислота" },
            CorrectAnswers = new List<int> { 0 }
        },
        new Question
        {
            Text = "Який орган відповідає за дихання у людини?",
            Options = new List<string> { "Серце", "Легені", "Печінка", "Нирки" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Що таке фотосинтез?",
            Options = new List<string> { "Процес отримання енергії рослинами", "Процес дихання тварин", "Процес розмноження бактерій", "Процес перетравлення їжі" },
            CorrectAnswers = new List<int> { 0 }
        },
        new Question
        {
            Text = "Який вітамін синтезується в шкірі під впливом сонячного світла?",
            Options = new List<string> { "Вітамін А", "Вітамін В", "Вітамін С", "Вітамін D" },
            CorrectAnswers = new List<int> { 3 }
        },
        new Question
        {
            Text = "Що таке мітохондрії?",
            Options = new List<string> { "Органели клітини, що відповідають за енергетичний обмін", "Органели клітини, що відповідають за синтез білка", "Органели клітини, що відповідають за зберігання генетичної інформації", "Органели клітини, що відповідають за транспорт речовин" },
            CorrectAnswers = new List<int> { 0 }
        },
        new Question
        {
            Text = "Який процес розмноження характерний для бактерій?",
            Options = new List<string> { "Статеве розмноження", "Вегетативне розмноження", "Поділ клітини", "Спороутворення" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Що таке еволюція?",
            Options = new List<string> { "Процес зміни живих організмів з часом", "Процес фотосинтезу", "Процес дихання", "Процес розмноження" },
            CorrectAnswers = new List<int> { 0 }
        },
        new Question
        {
            Text = "Який газ виділяють рослини в процесі фотосинтезу?",
            Options = new List<string> { "Вуглекислий газ", "Кисень", "Азот", "Водень" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Що таке ген?",
            Options = new List<string> { "Ділянка ДНК, що кодує білок", "Клітина крові", "Орган рослини", "Вітамін" },
            CorrectAnswers = new List<int> { 0 }
        },
        new Question
        {
            Text = "Який орган відповідає за фільтрацію крові у людини?",
            Options = new List<string> { "Серце", "Легені", "Печінка", "Нирки" },
            CorrectAnswers = new List<int> { 3 }
        },
        new Question
        {
            Text = "Що таке фермент?",
            Options = new List<string> { "Білок, що каталізує хімічні реакції", "Вуглевод", "Жир", "Вітамін" },
            CorrectAnswers = new List<int> { 0 }
        },
        new Question
        {
            Text = "Який тип клітин крові відповідає за імунітет?",
            Options = new List<string> { "Еритроцити", "Лейкоцити", "Тромбоцити", "Нейрони" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Що таке гормон?",
            Options = new List<string> { "Хімічна речовина, що регулює функції організму", "Клітина крові", "Орган рослини", "Вітамін" },
            CorrectAnswers = new List<int> { 0 }
        },
        new Question
        {
            Text = "Який орган відповідає за травлення у людини?",
            Options = new List<string> { "Серце", "Легені", "Шлунок", "Нирки" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Що таке клітина?",
            Options = new List<string> { "Основна структурна і функціональна одиниця живого", "Орган рослини", "Вітамін", "Гормон" },
            CorrectAnswers = new List<int> { 0 }
        },
        new Question
        {
            Text = "Який процес забезпечує передачу спадкової інформації від батьків до нащадків?",
            Options = new List<string> { "Фотосинтез", "Дихання", "Розмноження", "Травлення" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Що таке екосистема?",
            Options = new List<string> { "Спільнота живих організмів і їхнього середовища", "Орган рослини", "Вітамін", "Гормон" },
            CorrectAnswers = new List<int> { 0 }
        },
        new Question
        {
            Text = "Який орган відповідає за зір у людини?",
            Options = new List<string> { "Серце", "Легені", "Очі", "Нирки" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Що таке вірус?",
            Options = new List<string> { "Не клітинна форма життя", "Клітина крові", "Орган рослини", "Вітамін" },
            CorrectAnswers = new List<int> { 0 }
        },
        new Question
        {
            Text = "Який процес забезпечує ріст і розвиток організму?",
            Options = new List<string> { "Фотосинтез", "Дихання", "Мітоз", "Травлення" },
            CorrectAnswers = new List<int> { 2 }
        }
    }
        });

        quizzes.Add(new Quiz
        {
            Category = "Географія",
            Questions = new List<Question>
    {
        new Question
        {
            Text = "Яка найдовша річка в світі?",
            Options = new List<string> { "Ніл", "Амазонка", "Янцзи", "Міссісіпі" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Яка найвища гора в світі?",
            Options = new List<string> { "Кіліманджаро", "Еверест", "Монблан", "Аконкагуа" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Який океан найбільший?",
            Options = new List<string> { "Атлантичний", "Індійський", "Північний Льодовитий", "Тихий" },
            CorrectAnswers = new List<int> { 3 }
        },
        new Question
        {
            Text = "Яка країна має найбільшу площу?",
            Options = new List<string> { "Китай", "Канада", "США", "Росія" },
            CorrectAnswers = new List<int> { 3 }
        },
        new Question
        {
            Text = "Яка столиця Франції?",
            Options = new List<string> { "Берлін", "Лондон", "Мадрид", "Париж" },
            CorrectAnswers = new List<int> { 3 }
        },
        new Question
        {
            Text = "Який континент найменший?",
            Options = new List<string> { "Африка", "Австралія", "Європа", "Південна Америка" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Яка країна відома своїми пірамідами?",
            Options = new List<string> { "Греція", "Індія", "Єгипет", "Мексика" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Яка країна є батьківщиною кенгуру?",
            Options = new List<string> { "Нова Зеландія", "Австралія", "Південна Африка", "Аргентина" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Яке море найсолоніше у світі?",
            Options = new List<string> { "Середземне", "Червоне", "Мертве", "Карибське" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Яка країна відома своїми самураями?",
            Options = new List<string> { "Китай", "Корея", "Японія", "В'єтнам" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Яка пустеля є найбільшою в світі?",
            Options = new List<string> { "Сахара", "Гобі", "Антарктична", "Атакама" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Яка країна є батьківщиною піци?",
            Options = new List<string> { "Греція", "Італія", "Іспанія", "Франція" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Яка країна відома своїми тюльпанами?",
            Options = new List<string> { "Бельгія", "Німеччина", "Нідерланди", "Данія" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Яка країна є батьківщиною чаю?",
            Options = new List<string> { "Індія", "Китай", "Японія", "Шрі-Ланка" },
            CorrectAnswers = new List<int> { 1 }
        },
        new Question
        {
            Text = "Який водоспад є найвищим у світі?",
            Options = new List<string> { "Ніагарський", "Вікторія", "Анхель", "Ігуасу" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Яка країна є батьківщиною футболу?",
            Options = new List<string> { "Бразилія", "Італія", "Англія", "Іспанія" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Яка країна відома своїми фіордами?",
            Options = new List<string> { "Швеція", "Фінляндія", "Норвегія", "Ісландія" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Яка країна є батьківщиною суші?",
            Options = new List<string> { "Китай", "Корея", "Японія", "В'єтнам" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Яка країна відома своїм Великим Бар'єрним рифом?",
            Options = new List<string> { "Таїланд", "Індонезія", "Австралія", "Філіппіни" },
            CorrectAnswers = new List<int> { 2 }
        },
        new Question
        {
            Text = "Яка країна є батьківщиною танго?",
            Options = new List<string> { "Бразилія", "Аргентина", "Іспанія", "Португалія" },
            CorrectAnswers = new List<int> { 1 }
        }
    }
        });
    }

    public void Run()
    {
        while (true)
        {
            if (currentUser == null)
            {
                Console.WriteLine("1. Вхід");
                Console.WriteLine("2. Реєстрація");
                Console.WriteLine("3. Вихід");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Login();
                        break;
                    case "2":
                        Register();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Неправильний вибір.");
                        break;
                }
            }
            else
            {
                ShowMainMenu();
            }
        }
    }

    private void Login()
    {
        Console.Write("Логін: ");
        string login = Console.ReadLine();
        Console.Write("Пароль: ");
        string password = Console.ReadLine();

        currentUser = users.FirstOrDefault(u => u.Login == login && u.Password == password);
        if (currentUser == null)
        {
            Console.WriteLine("Неправильний логін або пароль.");
        }
    }

    private void Register()
    {
        Console.Write("Логін: ");
        string login = Console.ReadLine();
        if (users.Any(u => u.Login == login))
        {
            Console.WriteLine("Логін вже існує.");
            return;
        }

        Console.Write("Пароль: ");
        string password = Console.ReadLine();
        Console.Write("Дата народження (рррр-мм-дд): ");
        DateTime birthDate = DateTime.Parse(Console.ReadLine());

        users.Add(new User { Login = login, Password = password, BirthDate = birthDate });
        Console.WriteLine("Реєстрація успішна.");
    }

    private void ShowMainMenu()
    {
        Console.WriteLine("1. Нова вікторина");
        Console.WriteLine("2. Результати вікторин");
        Console.WriteLine("3. Топ-20");
        Console.WriteLine("4. Налаштування");
        Console.WriteLine("5. Вихід");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                StartQuiz();
                break;
            case "2":
                ShowResults();
                break;
            case "3":
                ShowTop20();
                break;
            case "4":
                ShowSettings();
                break;
            case "5":
                currentUser = null;
                break;
            default:
                Console.WriteLine("Неправильний вибір.");
                break;
        }
    }



    private void StartQuiz()
    {
        Console.WriteLine("Оберіть категорію вікторини:");
        for (int i = 0; i < quizzes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {quizzes[i].Category}");
        }
        Console.WriteLine($"{quizzes.Count + 1}. Змішана вікторина");

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > quizzes.Count + 1)
        {
            Console.WriteLine("Неправильний вибір.");
            return;
        }

        List<Question> selectedQuestions = new List<Question>();
        if (choice == quizzes.Count + 1)
        {
            // Змішана вікторина
            Random rand = new Random();
            List<Question> allQuestions = quizzes.SelectMany(q => q.Questions).ToList();
            for (int i = 0; i < 20 && allQuestions.Count > 0; i++)
            {
                int randomIndex = rand.Next(allQuestions.Count);
                selectedQuestions.Add(allQuestions[randomIndex]);
                allQuestions.RemoveAt(randomIndex); // Щоб не повторювати питання
            }
        }
        else
        {
            // Вікторина за категорією
            selectedQuestions = quizzes[choice - 1].Questions.Take(20).ToList();
        }

        int score = 0;
        foreach (var question in selectedQuestions)
        {
            Console.WriteLine(question.Text);
            for (int i = 0; i < question.Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Options[i]}");
            }

            Console.Write("Ваша відповідь (через кому, якщо кілька): ");
            string[] answers = Console.ReadLine().Split(',');
            List<int> userAnswers = new List<int>();
            foreach (var answer in answers)
            {
                if (int.TryParse(answer.Trim(), out int userAnswer))
                {
                    userAnswers.Add(userAnswer - 1);
                }
            }

            if (userAnswers.SequenceEqual(question.CorrectAnswers))
            {
                score++;
            }
        }

        Console.WriteLine($"Вікторина завершена. Ваш результат: {score} з 20.");
        currentUser.Results.Add(new QuizResult { Category = (choice == quizzes.Count + 1) ? "Змішана" : quizzes[choice - 1].Category, Score = score, Date = DateTime.Now });
    }
    private void ShowResults()
    {
        if (currentUser.Results.Count == 0)
        {
            Console.WriteLine("Ви ще не проходили вікторини.");
            return;
        }

        Console.WriteLine("Результати вікторин:");
        foreach (var result in currentUser.Results)
        {
            Console.WriteLine($"{result.Date}: {result.Category} - {result.Score} з 20.");
        }
    }

    private void ShowTop20()
    {
        Console.WriteLine("Оберіть категорію для топ-20:");
        for (int i = 0; i < quizzes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {quizzes[i].Category}");
        }
        Console.WriteLine($"{quizzes.Count + 1}. Змішана вікторина");

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > quizzes.Count + 1)
        {
            Console.WriteLine("Неправильний вибір.");
            return;
        }

        string category = (choice == quizzes.Count + 1) ? "Змішана" : quizzes[choice - 1].Category;
        var top20 = users.SelectMany(u => u.Results)
            .Where(r => r.Category == category)
            .OrderByDescending(r => r.Score)
            .Take(20)
            .ToList();

        if (top20.Count == 0)
        {
            Console.WriteLine($"Немає результатів для категорії {category}.");
            return;
        }

        Console.WriteLine($"Топ-20 результатів для категорії {category}:");
        for (int i = 0; i < top20.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {top20[i].Score} з 20 ({top20[i].Date})");
        }
    }

    private void ShowSettings()
    {
        Console.WriteLine("1. Змінити пароль");
        Console.WriteLine("2. Змінити дату народження");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.Write("Новий пароль: ");
                currentUser.Password = Console.ReadLine();
                Console.WriteLine("Пароль змінено.");
                break;
            case "2":
                Console.Write("Нова дата народження (рррр-мм-дд): ");
                currentUser.BirthDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Дата народження змінена.");
                break;
            default:
                Console.WriteLine("Неправильний вибір.");
                break;
        }
    }
}



public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.Unicode;

        QuizApp app = new QuizApp();
        app.Run();
    }
}
