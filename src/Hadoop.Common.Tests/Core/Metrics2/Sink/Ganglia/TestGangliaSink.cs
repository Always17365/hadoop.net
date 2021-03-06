using Org.Apache.Commons.Configuration;
using Org.Apache.Hadoop.Metrics2.Impl;


namespace Org.Apache.Hadoop.Metrics2.Sink.Ganglia
{
	public class TestGangliaSink
	{
		/// <exception cref="System.Exception"/>
		[Fact]
		public virtual void TestShouldCreateDatagramSocketByDefault()
		{
			SubsetConfiguration conf = new ConfigBuilder().Subset("test.sink.ganglia");
			GangliaSink30 gangliaSink = new GangliaSink30();
			gangliaSink.Init(conf);
			DatagramSocket socket = gangliaSink.GetDatagramSocket();
			NUnit.Framework.Assert.IsFalse("Did not create DatagramSocket", socket == null ||
				 socket is MulticastSocket);
		}

		/// <exception cref="System.Exception"/>
		[Fact]
		public virtual void TestShouldCreateDatagramSocketIfMulticastIsDisabled()
		{
			SubsetConfiguration conf = new ConfigBuilder().Add("test.sink.ganglia.multicast", 
				false).Subset("test.sink.ganglia");
			GangliaSink30 gangliaSink = new GangliaSink30();
			gangliaSink.Init(conf);
			DatagramSocket socket = gangliaSink.GetDatagramSocket();
			NUnit.Framework.Assert.IsFalse("Did not create DatagramSocket", socket == null ||
				 socket is MulticastSocket);
		}

		/// <exception cref="System.Exception"/>
		[Fact]
		public virtual void TestShouldCreateMulticastSocket()
		{
			SubsetConfiguration conf = new ConfigBuilder().Add("test.sink.ganglia.multicast", 
				true).Subset("test.sink.ganglia");
			GangliaSink30 gangliaSink = new GangliaSink30();
			gangliaSink.Init(conf);
			DatagramSocket socket = gangliaSink.GetDatagramSocket();
			Assert.True("Did not create MulticastSocket", socket != null &&
				 socket is MulticastSocket);
			int ttl = ((MulticastSocket)socket).GetTimeToLive();
			Assert.Equal("Did not set default TTL", 1, ttl);
		}

		/// <exception cref="System.Exception"/>
		[Fact]
		public virtual void TestShouldSetMulticastSocketTtl()
		{
			SubsetConfiguration conf = new ConfigBuilder().Add("test.sink.ganglia.multicast", 
				true).Add("test.sink.ganglia.multicast.ttl", 3).Subset("test.sink.ganglia");
			GangliaSink30 gangliaSink = new GangliaSink30();
			gangliaSink.Init(conf);
			DatagramSocket socket = gangliaSink.GetDatagramSocket();
			Assert.True("Did not create MulticastSocket", socket != null &&
				 socket is MulticastSocket);
			int ttl = ((MulticastSocket)socket).GetTimeToLive();
			Assert.Equal("Did not set TTL", 3, ttl);
		}
	}
}
