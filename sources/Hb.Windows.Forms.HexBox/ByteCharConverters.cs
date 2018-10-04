using System.Collections.Generic;
using System.Text;

namespace Hb.Windows.Forms
{
	/// <summary>
	/// The interface for objects that can translate between characters and bytes.
	/// </summary>
	public interface IByteCharConverter
    {
        /// <summary>
        /// Returns the character to display for the byte passed across.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        char ToChar(byte b);

        /// <summary>
        /// Returns the byte to use when the character passed across is entered during editing.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        byte ToByte(char c);
    }

    /// <summary>
    /// The default <see cref="IByteCharConverter"/> implementation.
    /// </summary>
    public class DefaultByteCharConverter : IByteCharConverter
    {
        /// <summary>
        /// Returns the character to display for the byte passed across.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public virtual char ToChar(byte b)
        {
            return b > 0x1F && !(b > 0x7E && b < 0xA0) ? (char)b : '.';
        }

        /// <summary>
        /// Returns the byte to use for the character passed across.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual byte ToByte(char c)
        {
            return (byte)c;
        }

        /// <summary>
        /// Returns a description of the byte char provider.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "ANSI (Default)";
        }
    }

	/// <summary>
	/// A byte char provider that can translate bytes encoded in selected codepage.
	/// Class initializes with code page identifier.
	/// </summary>
	public class CodePageByteCharProvider : IByteCharConverter
    {
		private static int ddd;
		/// <summary>
		/// Code page encoding. Note that some code pages is not always supported by .NET,
		/// the underlying platform has to provide support for it.
		/// </summary>
		public CodePageByteCharProvider(int cp)
		{
			ddd = cp; 
		}

			private Encoding _ebcdicEncoding = Encoding.GetEncoding(ddd);

        /// <summary>
        /// Returns the EBCDIC character corresponding to the byte passed across.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public virtual char ToChar(byte b)
        {
            string encoded = _ebcdicEncoding.GetString(new byte[] { b });
            return encoded.Length > 0 ? encoded[0] : '.';
        }

        /// <summary>
        /// Returns the byte corresponding to the EBCDIC character passed across.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual byte ToByte(char c)
        {
            byte[] decoded = _ebcdicEncoding.GetBytes(new char[] { c });
            return decoded.Length > 0 ? decoded[0] : (byte)0;
        }

        /// <summary>
        /// Returns a description of the byte char provider.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Select Code Page";
        }
    }

	/// <summary>
	/// Creates .net codepage name, display name and identifiers list. List is one byte character code pages
	/// </summary>
	public class CodePageNames
	{
		/// <summary>
		/// This is .net codepage names list. List type string
		/// </summary>
		public List<string> pages = new List<string>();

		/// <summary>
		/// This is .net codepage display names list. Shows long names, ist type string
		/// </summary>
		public List<string> displayNames = new List<string>();

		/// <summary>
		/// This is .net codepage identifiers list values as integer.
		/// </summary>
		public List<int> numbers = new List<int>();

		/// <summary>
		/// List Creating in initalization state.
		/// </summary>
		public CodePageNames()
		{
			foreach (EncodingInfo ei in Encoding.GetEncodings())
			{
				Encoding e = ei.GetEncoding();
				if (e.IsSingleByte) // Only one byte code pages
				{
					pages.Add(ei.Name);
					numbers.Add(ei.CodePage);
					//added at version 2.0.1
					displayNames.Add(ei.DisplayName);
				}
			}
		}
	}
}
