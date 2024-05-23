using System.Xml.Serialization;

namespace SunamoBts;
public class RHSE
{
    public static string DumpAsXml(object output)
    {
        string objectAsXmlString;

        XmlSerializer xs = new(output.GetType());
        using (StringWriter sw = new())
        {
            try
            {
                xs.Serialize(sw, output);
                objectAsXmlString = sw.ToString();
            }
            catch (Exception ex)
            {
                objectAsXmlString = ex.ToString();
            }
        }

        return objectAsXmlString;
    }
}
