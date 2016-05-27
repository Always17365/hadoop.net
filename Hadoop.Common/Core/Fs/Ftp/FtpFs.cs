using Org.Apache.Commons.Net.Ftp;
using Org.Apache.Hadoop.Conf;
using Org.Apache.Hadoop.FS;
using Sharpen;

namespace Org.Apache.Hadoop.FS.Ftp
{
	/// <summary>The FtpFs implementation of AbstractFileSystem.</summary>
	/// <remarks>
	/// The FtpFs implementation of AbstractFileSystem.
	/// This impl delegates to the old FileSystem
	/// </remarks>
	public class FtpFs : DelegateToFileSystem
	{
		/// <summary>
		/// This constructor has the signature needed by
		/// <see cref="Org.Apache.Hadoop.FS.AbstractFileSystem.CreateFileSystem(Sharpen.URI, Org.Apache.Hadoop.Conf.Configuration)
		/// 	"/>
		/// .
		/// </summary>
		/// <param name="theUri">which must be that of localFs</param>
		/// <param name="conf"/>
		/// <exception cref="System.IO.IOException"/>
		/// <exception cref="Sharpen.URISyntaxException"></exception>
		internal FtpFs(URI theUri, Configuration conf)
			: base(theUri, new FTPFileSystem(), conf, FsConstants.FtpScheme, true)
		{
		}

		/*Evolving for a release,to be changed to Stable */
		public override int GetUriDefaultPort()
		{
			return FTP.DefaultPort;
		}

		/// <exception cref="System.IO.IOException"/>
		public override FsServerDefaults GetServerDefaults()
		{
			return FtpConfigKeys.GetServerDefaults();
		}
	}
}
