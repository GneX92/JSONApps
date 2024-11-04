using JSON;
using System.Text.Json;
using Spectre.Console.Json;
using Spectre.Console;

string [] directories = [];
List<DirInfo> directorylist = new();

try
{
    directories = Directory.GetDirectories( @"C:\Windows" );
}
catch ( Exception e )
{
}

try
{
    foreach ( string dir in directories )
    {
        DirInfo p = new();
        p.Name = Path.GetFullPath( dir );
        p.CreationDateTime = Directory.GetCreationTime( dir );
        string [] filecount = Directory.GetFiles( dir );
        p.FileCount = filecount.Length;
        directorylist.Add( p );
    }
}
catch ( Exception )
{
}

var options = new JsonSerializerOptions()
{
    WriteIndented = true ,
    PropertyNameCaseInsensitive = true
};

string json = JsonSerializer.Serialize( directorylist , options );

File.WriteAllText( @"C:\Users\ITA5-TN05\Desktop\Neuer Ordner\DirInfo.json" , json );

string getjson = File.ReadAllText( @"C:\Users\ITA5-TN05\Desktop\Neuer Ordner\DirInfo.json" );

List<DirInfo> readjson = JsonSerializer.Deserialize<List<DirInfo>>( getjson , options );

foreach ( DirInfo d in readjson )
    Console.WriteLine( d );

Console.ReadLine();
Console.Clear();

Console.WriteLine( getjson );

Console.ReadLine();
Console.Clear();

var table = new Table();

table.AddColumn( new TableColumn( "Directory" ).LeftAligned() );
table.AddColumn( new TableColumn( "Created" ).Centered() );
table.AddColumn( new TableColumn( "Files" ).RightAligned() );

table.Border( TableBorder.Rounded );
table.BorderColor( Color.Yellow );

foreach ( var d in readjson )
{
    table.AddRow( d.Name , d.CreationDateTime.ToString() , d.FileCount.ToString() );
}

AnsiConsole.Write( table );

Console.ReadLine();
Console.Clear();

var prettyjson = new JsonText( getjson );

AnsiConsole.Write( prettyjson );

Console.ReadLine();
Console.Clear();

var roottext = Emoji.Known.OpenFileFolder + @"C:\";

var root = new Tree( @"C:\" );
var windows = root.AddNode( @"Windows\" );

List<string> dirs = Directory.GetDirectories( @"C:\Windows" ).ToList();

foreach ( var d in readjson )
{
    string [] temp = d.Name.Split( @"\" );
    windows.AddNode( $"[yellow]{temp [ temp.Length - 1 ]}[/]" + $" created: {d.CreationDateTime}, {d.FileCount} files" );
}

AnsiConsole.Write( root );

Console.ReadLine();