namespace JSON;

internal class DirInfo
{
    public string Name { get; set; }

    public DateTime CreationDateTime { get; set; }

    public int FileCount { get; set; }

    public override string ToString() => $"{Name} | Created: {CreationDateTime} | Files: {FileCount}";
}