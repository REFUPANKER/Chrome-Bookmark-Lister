using System.IO;
using System.Threading;
static void cwl(Object msg)
{
    System.Console.WriteLine(msg);
}
static void cw(Object msg)
{
    System.Console.Write(msg);
}

cwl("App started");
cwl("> Chrome Bookmark Finder/Lister");
string bookmarkPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\";
if (Directory.Exists(bookmarkPath + "Google\\Chrome\\") == false)
{
    cwl("Chrome Not exists in local appdata");
    return;
}
else
{
    // .\Local\Google\Chrome\User Data\Default\Bookmarks
    bookmarkPath += "Google\\Chrome\\User Data\\Default\\";
    cwl("Bookmark Location Might be there >");
    cw(bookmarkPath);
    bookmarkPath += "Bookmarks";
    cwl("");
}
try
{
    cwl(bookmarkPath);
    // Google/Chrome/UserData/Default/Bookmark file
    var reading = Task.Run(async () =>
    {
        cwl("Async read started\n");
        return await File.ReadAllTextAsync(bookmarkPath);
    });
    String[] objs=reading.Result.Split(",");
    for(int i=0;i<objs.Length;i++)
    {
        if (objs[i].Contains("url\":"))
        {
            objs[i]=objs[i].Replace(" ","").Replace("\"url\":","").Replace("}","").Replace("]","").Replace("\"","").Replace("\n","");
            cwl(objs[i]);
        }
    }

}
catch (System.Exception excp)
{
    cwl("\nError\n");
    cwl(excp);
}
finally
{
    cwl("\nApplication ended");
}
