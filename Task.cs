namespace to_do_list_cs;
public struct Clock(int year, int month, int day)
{
    public int Year = year;
    public int Month = month;
    public int Day = day;
}
public class Task
{
    private string? _headLine;
    private string _info;
    private Clock _time;
    public Task(string? headLine, string info, Clock clock)
    {
        _headLine = headLine;
        _info = info;
        _time = clock;
    }
}