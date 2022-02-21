using System;
using System.Reflection;
using System.Text.Json;

namespace Attributes
{
	public class Logger
	{


		public Logger() { }

		public void Track(object obj, string nameOfTheFile)
		{
			if (obj.GetType().GetProperty("TrackingEntity") == null) // before anything we check if the object itself has property TrackingEntity
			{
				Console.WriteLine("empty"); // if not we write empty
			}

			Type type = obj.GetType(); // we have to know the type of the project to get its properties
			PropertyInfo[] items = type.GetProperties(); // we have to get the properties in order to know the attributes

			Dictionary<string, string> valuesToWrite = new Dictionary<string, string>();

			foreach (PropertyInfo prop in items)
			{
				object[] attributes = prop.GetCustomAttributes(false); // get attributes of each property
				{
					foreach (object attribute in attributes)
					{
						if (attribute is TrackingProperty) // if attribute is TrackingProperty, then add the property to the dictionary
						{
							if (((TrackingProperty)attribute).NameOfAttribute != null) // we are checking if the attribute has a name (not null)
							{
								var key = ((TrackingProperty)attribute).NameOfAttribute;
								var value = prop.GetValue(obj).ToString(); // do to string, because the value might be integer.
								valuesToWrite.Add(key, value); // if an attribute has a name, we use it,
							}
							else
							{
								var key = nameof(prop);
								var value = prop.GetValue(obj).ToString(); // // do to string, because the value might be integer.
								valuesToWrite.Add(key, value); // if an attribute doesn't have a name, we use the name of the property.
							}
						}
					}
				}
			}

			string fileName = $"{nameOfTheFile}.json";
			string jsonString = JsonSerializer.Serialize(valuesToWrite);

			File.WriteAllText(fileName, jsonString);
			Console.WriteLine(File.ReadAllText(fileName)); // works
		}
	}
}

