using System;
using System.Linq;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            var data = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            MusicAlbum(data);
        }

        #region Music Album

        static void MusicAlbum(string data)
        {
            var query = data
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Split(':', StringSplitOptions.RemoveEmptyEntries))
            .Select(x => (minutes: x[0], seconds: x[1]))
            .Select(x => int.Parse(x.minutes) * 60 + int.Parse(x.seconds))
            ;

            int num = query.Count();
            int avg = (int)Math.Ceiling(query.Average(x => (double)x));
            int sum = query.Sum();

            if (sum >= 60 * 60)
                Console.WriteLine($"{num} {avg / 60}:{avg % 60:D2} {sum / 60 / 60}:{sum / 60 % 60:D2}:{sum % 60:D2}");
            else
                Console.WriteLine($"{num} {avg / 60}:{avg % 60:D2} {sum / 60}:{sum % 60:D2}");
        }

        #endregion

        #region Sort by Date of Birth then Last Name
        static string SortByDateOfBirthThenLastName(string napis)
        {
            var query = napis
            .Split(';', StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .Select(x => x.Split(',', StringSplitOptions.RemoveEmptyEntries))
            .Select(x => (namesurname: x[0], date: x[1]))
            .Select(x => (namesurname: x.namesurname.Split(' ', StringSplitOptions.RemoveEmptyEntries), date: x.date))
            .Select(x => (name: x.namesurname[0].Trim(), surname: x.namesurname[1].Trim(), date: x.date.Trim()))
            .OrderBy(x => x.date)
            .ThenBy(x => x.surname)
            .Select(x => $"{x.name} {x.surname}, {x.date}")
            //.ToArray()
            ;
            return string.Join("; ", query);
        }
        #endregion

        #region Liczby Całkowite Naprzemiennie
        public static IEnumerable<int> LiczbyCalkowiteNaprzemiennie(int n)
        {
            var result = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
                if (i % 2 == 0) result[i] = -i;
                else result[i] = i;
            return result;
        }
        #endregion
    }
}