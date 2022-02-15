using System;
using System.Reflection;
using System.Text.Json;


namespace AttributesLibrary
{
	public class Logger
	{
		public Logger() { }

		public void Track(object obj, string nameOfTheFile)
		{
			Type type = obj.GetType(); // we have to know the type of the project to get its properties
			PropertyInfo[] items = type.GetProperties(); // we have to get the properties in order to know the attributes
			FieldInfo[] fieldItems = type.GetFields();
			Dictionary<string, string> valuesToWrite = new Dictionary<string, string>();
			if (type.GetCustomAttribute<TrackingEntity>() != null) // checks if obj has customattribute "TrackingEntity"
			{
				foreach (FieldInfo field in fieldItems)
				{
					object[] fieldAttributes = field.GetCustomAttributes(false); // get attributes of each field
					{
						foreach (object attribute in fieldAttributes)
						{
							if (attribute is TrackingProperty) // if attribute is TrackingProperty, then add the property to the dictionary
							{
								if (((TrackingProperty)attribute).NameOfAttribute != null) // we are checking if the attribute has a name (not null)
								{
									valuesToWrite.Add(((TrackingProperty)attribute).NameOfAttribute, prop.GetValue(obj).ToString());
								}
								else
								{
									valuesToWrite.Add(nameof(prop), prop.GetValue(obj).ToString());
								}
							}
						}
					}
				}
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
									valuesToWrite.Add(((TrackingProperty)attribute).NameOfAttribute, prop.GetValue(obj).ToString());
								}
								else
								{
									valuesToWrite.Add(nameof(prop), prop.GetValue(obj).ToString());
								}
							}
						}
					}
				}
				if (valuesToWrite.Count != 0) // if there is no TrackingEntity, then the dictionary is going to be empty and then we are not going to print anything
				{
					string fileName = $"{nameOfTheFile}.json";
					string jsonString = JsonSerializer.Serialize(valuesToWrite);
					File.WriteAllText(fileName, jsonString);
					Console.WriteLine(File.ReadAllText(fileName)); // works
				}
			}
		}
	}
}