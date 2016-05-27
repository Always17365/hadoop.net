using System.Collections.Generic;
using System.IO;
using Org.Apache.Hadoop.Conf;
using Org.Apache.Hadoop.FS;
using Org.Apache.Hadoop.Security;
using Sharpen;

namespace Org.Apache.Hadoop.Ipc
{
	public class TestIdentityProviders
	{
		public class FakeSchedulable : Schedulable
		{
			public FakeSchedulable(TestIdentityProviders _enclosing)
			{
				this._enclosing = _enclosing;
			}

			public virtual UserGroupInformation GetUserGroupInformation()
			{
				try
				{
					return UserGroupInformation.GetCurrentUser();
				}
				catch (IOException)
				{
					return null;
				}
			}

			private readonly TestIdentityProviders _enclosing;
		}

		[NUnit.Framework.Test]
		public virtual void TestPluggableIdentityProvider()
		{
			Configuration conf = new Configuration();
			conf.Set(CommonConfigurationKeys.IpcCallqueueIdentityProviderKey, "org.apache.hadoop.ipc.UserIdentityProvider"
				);
			IList<IdentityProvider> providers = conf.GetInstances<IdentityProvider>(CommonConfigurationKeys
				.IpcCallqueueIdentityProviderKey);
			NUnit.Framework.Assert.IsTrue(providers.Count == 1);
			IdentityProvider ip = providers[0];
			NUnit.Framework.Assert.IsNotNull(ip);
			NUnit.Framework.Assert.AreEqual(ip.GetType(), typeof(UserIdentityProvider));
		}

		/// <exception cref="System.IO.IOException"/>
		[NUnit.Framework.Test]
		public virtual void TestUserIdentityProvider()
		{
			UserIdentityProvider uip = new UserIdentityProvider();
			string identity = uip.MakeIdentity(new TestIdentityProviders.FakeSchedulable(this
				));
			// Get our username
			UserGroupInformation ugi = UserGroupInformation.GetCurrentUser();
			string username = ugi.GetUserName();
			NUnit.Framework.Assert.AreEqual(username, identity);
		}
	}
}
