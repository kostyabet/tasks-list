namespace to_do_list_cs;
public struct Clock(int age, int month, int day, int hours, int minuts)
{
    public int Age = age;
    public int Month = month;
    public int Day = day;
    public int Hours = hours;
    public int Minuts = minuts;
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