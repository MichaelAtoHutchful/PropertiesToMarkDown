using System.Text;

string? propertyFile;
string? addEnvVar;

do
{
    Console.WriteLine("Add Environmental Variables? Y/N");
    addEnvVar = Console.ReadLine();
    Console.WriteLine("Please Enter the path of your property file");
    propertyFile = Console.ReadLine();
} while (null == propertyFile);

var propertyFileContent = await File.ReadAllLinesAsync(propertyFile);
var envString = addEnvVar?.ToLower() == "y" ? "<th>Environment Variable</th>\n             " : string.Empty;
var stringBuilder = new StringBuilder();
stringBuilder.AppendLine("<table class=\"tableizer-table\">\n    <thead>\n        " +
    "<tr class=\"tableizer-firstrow\">\n            <th>Property Name</th>\n            " +
    $"{envString}<th>Recommended Value</th>\n            <th>Overridable</th>\n            " +
    "<th>Description</th>\n        </tr>\n    </thead>");
stringBuilder.AppendLine("    <tbody>");

foreach (var property in propertyFileContent)
{
    if (!string.IsNullOrWhiteSpace(property))
    {
        stringBuilder.AppendLine("        <tr>");
        var keyValuePair = property.Split('=');
        var key = keyValuePair[0];
        var value = keyValuePair[1];
        stringBuilder.AppendLine($"            <td>{key}</td>");
        if (addEnvVar?.ToLower() == "y")
        {
            stringBuilder.AppendLine($"            <td></td>"); 
        }
        stringBuilder.AppendLine($"            <td>{value}</td>");
        stringBuilder.AppendLine($"            <td>YES</td>");
        stringBuilder.AppendLine($"            <td></td>");
        stringBuilder.AppendLine("        </tr>");
    }
}

stringBuilder.AppendLine("    </tbody>");
stringBuilder.AppendLine("</table>");

Console.WriteLine(stringBuilder.ToString());


