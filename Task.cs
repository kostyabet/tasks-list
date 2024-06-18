namespace to_do_list_cs;
public struct Clock(int year, int month, int day)
{
    public int Year = year;
    public int Month = month;
    public int Day = day;
}
public class Task
{
    public Task(string headLine, string info, Clock clock)
    {
        HeadLine = headLine;
        Info = info;
        GetTime = clock;
    }
    /// <summary>
    /// Time format: xx.xx.20xx (day.month.year);
    /// </summary>
    public Clock GetTime { get; private set; }

    public string HeadLine { get; }
    public string Info { get; }
}