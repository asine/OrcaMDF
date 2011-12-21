using System;
using System.Text;

namespace OrcaMDF.Core.Engine.SqlTypes
{
	public class SqlNChar : SqlTypeBase
	{
		private readonly short length;

		public SqlNChar(short length, CompressionContext compression)
			: base(compression)
		{
			this.length = length;
		}

		public override bool IsVariableLength
		{
			get { return false; }
		}

		public override short? FixedLength
		{
			get { return length; }
		}

		public override object GetValue(byte[] value)
		{
			if (value.Length != length)
				throw new ArgumentException("Invalid value length: " + value.Length);

			return Encoding.Unicode.GetString(value);
		}
	}
}