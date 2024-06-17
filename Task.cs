namespace to_do_list_cs;
public struct Clock(int year, int month, int day)
{
    public int Year = year;
    public int Month = month;
    public int Day = day;
}
public class Task
{
    private string _headLine;
    private string _info;

    public Task(string headLine, string info, Clock clock)
    {
        _headLine = headLine;
        _info = info;
        GetTime = clock;
    }
    /// <summary>
    /// Time format: xx.xx.20xx (day.month.year);
    /// </summary>
    public Clock GetTime { get; private set; }
}