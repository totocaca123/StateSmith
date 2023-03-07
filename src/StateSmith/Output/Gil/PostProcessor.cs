using System.Text;
using System.Text.RegularExpressions;

#nullable enable

namespace StateSmith.Output.Gil;

/// <summary>
/// Getting the whitespace right when transpiling to C is hard.
/// This class helps.
/// </summary>
public class PostProcessor
{
    public const string echoLineMarker = "//>>>>>ECHO:";
    public const string trimBlankLinesMarker = ">>>>>>>>trimBlankLinesMarker<<<<<<<<<<<<<<";
    public const string trimHorizontalWhiteSpaceMarker = ">>>>>>>>trimHorizontalWhiteSpaceMarker<<<<<<<<<<<<<<";
    public const string rmLeft2Marker = "<<<<<rm2<<<<<";
    public const string rmRight2Marker = ">>>>>rm2>>>>>";
    private static readonly Regex trimBlankLinesRegex;
    private static readonly Regex trimHwsRegex;
    private static readonly Regex rmLeft2Regex;
    private static readonly Regex rmRight2Regex;

    static PostProcessor()
    {
        var eolPattern = @"(?:\r\n|\r|\n)";
        var anyPattern = @"[\s\S]";

        trimBlankLinesRegex = new Regex(@$"(?xm)
            ^ \s* {trimBlankLinesMarker} .* {eolPattern}
            (?:
                ^ [ \t]* {eolPattern}
            )*
        ");

        trimHwsRegex = new Regex(@$"(?xm)
            [ \t]* {trimHorizontalWhiteSpaceMarker} [ \t]*
        ");

        rmLeft2Regex = new Regex(@$"(?x) {anyPattern} {anyPattern} {rmLeft2Marker} ");
        rmRight2Regex = new Regex(@$"(?x) {rmRight2Marker} {anyPattern} {anyPattern}");
    }

    public static string RmCommentOut(string code)
    {
        code = code.Replace("*/", $"*{rmRight2Marker}##/");

        return $"/*{PostProcessor.rmLeft2Marker}{code}{PostProcessor.rmRight2Marker}*/";
    }

    public static string PostProcess(string str)
    {
        str = trimBlankLinesRegex.Replace(str, "");
        str = trimHwsRegex.Replace(str, "");
        str = rmLeft2Regex.Replace(str, "");
        str = rmRight2Regex.Replace(str, "");
        str = str.Replace(echoLineMarker, "");

        return str;
    }

    public static void PostProcess(StringBuilder sb)
    {
        var input = sb.ToString();
        sb.Clear();
        var output = PostProcess(input);
        sb.Append(output);
    }
}