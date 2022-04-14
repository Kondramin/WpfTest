using System.Text;
using WpfTest.Interfaces;

namespace WpfTest.Services
{
    public class StringConverter : IStringConverter
    {
        public string ConvertToUrlString(string stringLine)
        {
            StringBuilder convertedStringBuilder = new StringBuilder();

            foreach (char c in stringLine)
            {
                if (!string.IsNullOrWhiteSpace(c.ToString()))
                {
                    if (c == ',')
                    {
                        convertedStringBuilder.Append("%");
                        continue;
                    }
                    convertedStringBuilder.Append(c.ToString().ToUpper());

                }
            }

            var result = convertedStringBuilder.ToString();

            return result;
        }
    }
}
