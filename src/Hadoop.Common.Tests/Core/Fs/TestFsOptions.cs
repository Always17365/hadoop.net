using Org.Apache.Hadoop.Util;


namespace Org.Apache.Hadoop.FS
{
	public class TestFsOptions
	{
		[Fact]
		public virtual void TestProcessChecksumOpt()
		{
			Options.ChecksumOpt defaultOpt = new Options.ChecksumOpt(DataChecksum.Type.Crc32, 
				512);
			Options.ChecksumOpt finalOpt;
			// Give a null 
			finalOpt = Options.ChecksumOpt.ProcessChecksumOpt(defaultOpt, null);
			CheckParams(defaultOpt, finalOpt);
			// null with bpc
			finalOpt = Options.ChecksumOpt.ProcessChecksumOpt(defaultOpt, null, 1024);
			CheckParams(DataChecksum.Type.Crc32, 1024, finalOpt);
			Options.ChecksumOpt myOpt = new Options.ChecksumOpt();
			// custom with unspecified parameters
			finalOpt = Options.ChecksumOpt.ProcessChecksumOpt(defaultOpt, myOpt);
			CheckParams(defaultOpt, finalOpt);
			myOpt = new Options.ChecksumOpt(DataChecksum.Type.Crc32c, 2048);
			// custom config
			finalOpt = Options.ChecksumOpt.ProcessChecksumOpt(defaultOpt, myOpt);
			CheckParams(DataChecksum.Type.Crc32c, 2048, finalOpt);
			// custom config + bpc
			finalOpt = Options.ChecksumOpt.ProcessChecksumOpt(defaultOpt, myOpt, 4096);
			CheckParams(DataChecksum.Type.Crc32c, 4096, finalOpt);
		}

		private void CheckParams(Options.ChecksumOpt expected, Options.ChecksumOpt obtained
			)
		{
			Assert.Equal(expected.GetChecksumType(), obtained.GetChecksumType
				());
			Assert.Equal(expected.GetBytesPerChecksum(), obtained.GetBytesPerChecksum
				());
		}

		private void CheckParams(DataChecksum.Type type, int bpc, Options.ChecksumOpt obtained
			)
		{
			Assert.Equal(type, obtained.GetChecksumType());
			Assert.Equal(bpc, obtained.GetBytesPerChecksum());
		}
	}
}
