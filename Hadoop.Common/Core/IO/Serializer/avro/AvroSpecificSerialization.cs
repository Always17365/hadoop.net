using System;
using Org.Apache.Avro;
using Org.Apache.Avro.IO;
using Org.Apache.Avro.Specific;
using Org.Apache.Hadoop.Classification;
using Sharpen;

namespace Org.Apache.Hadoop.IO.Serializer.Avro
{
	/// <summary>Serialization for Avro Specific classes.</summary>
	/// <remarks>
	/// Serialization for Avro Specific classes. This serialization is to be used
	/// for classes generated by Avro's 'specific' compiler.
	/// </remarks>
	public class AvroSpecificSerialization : AvroSerialization<SpecificRecord>
	{
		[InterfaceAudience.Private]
		public override bool Accept(Type c)
		{
			return typeof(SpecificRecord).IsAssignableFrom(c);
		}

		[InterfaceAudience.Private]
		public override DatumReader<SpecificRecord> GetReader(Type clazz)
		{
			try
			{
				return new SpecificDatumReader(System.Activator.CreateInstance(clazz).GetSchema()
					);
			}
			catch (Exception e)
			{
				throw new RuntimeException(e);
			}
		}

		[InterfaceAudience.Private]
		public override Schema GetSchema(SpecificRecord t)
		{
			return t.GetSchema();
		}

		[InterfaceAudience.Private]
		public override DatumWriter<SpecificRecord> GetWriter(Type clazz)
		{
			return new SpecificDatumWriter();
		}
	}
}
