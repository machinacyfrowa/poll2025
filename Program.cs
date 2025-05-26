string path = "C:\\Users\\pzawadzki\\source\\repos\\poll\\MOCK_DATA.csv";
int[] votes = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
using (StreamReader streamReader = new StreamReader(path))
{
    string? line;
    while ((line = streamReader.ReadLine()) != null)
    {
        string[] columns = line.Split(',');
        for (int i = 1; i < columns.Length; i++)
        {
            if (int.TryParse(columns[i], out int vote))
                votes[i] += vote;
        }      
    }
    Dictionary<string, int> results = new Dictionary<string, int>();
    for(int i = 1; i < votes.Length; i++)
    {
        results.Add($"Kandydat {i}", votes[i]);
    }
    results = results.OrderByDescending(x => x.Value).
                        ToDictionary<string, int>();
    int pool = results.Values.Sum();

    //w tym miejscu masz w liście votes zliczone głosy
    //możesz je teraz przetwarzać dalej, np. wyświetlić
    Console.WriteLine("Podsumowanie głosów:");
    foreach (var item in results)
    {
        Console.WriteLine("Kandydat: " + item.Key + ", uzyskał "
                            + item.Value + " głosów");
    }
}