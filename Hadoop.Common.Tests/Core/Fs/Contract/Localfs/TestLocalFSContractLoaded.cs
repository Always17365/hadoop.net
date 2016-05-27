/*
* Licensed to the Apache Software Foundation (ASF) under one
*  or more contributor license agreements.  See the NOTICE file
*  distributed with this work for additional information
*  regarding copyright ownership.  The ASF licenses this file
*  to you under the Apache License, Version 2.0 (the
*  "License"); you may not use this file except in compliance
*  with the License.  You may obtain a copy of the License at
*
*       http://www.apache.org/licenses/LICENSE-2.0
*
*  Unless required by applicable law or agreed to in writing, software
*  distributed under the License is distributed on an "AS IS" BASIS,
*  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*  See the License for the specific language governing permissions and
*  limitations under the License.
*/
using System;
using Org.Apache.Hadoop.Conf;
using Org.Apache.Hadoop.FS.Contract;
using Sharpen;

namespace Org.Apache.Hadoop.FS.Contract.Localfs
{
	/// <summary>just here to make sure that the local.xml resource is actually loading</summary>
	public class TestLocalFSContractLoaded : AbstractFSContractTestBase
	{
		protected internal override AbstractFSContract CreateContract(Configuration conf)
		{
			return new LocalFSContract(conf);
		}

		/// <exception cref="System.Exception"/>
		[NUnit.Framework.Test]
		public virtual void TestContractWorks()
		{
			string key = GetContract().GetConfKey(SupportsAtomicRename);
			NUnit.Framework.Assert.IsNotNull("not set: " + key, GetContract().GetConf().Get(key
				));
			NUnit.Framework.Assert.IsTrue("not true: " + key, GetContract().IsSupported(SupportsAtomicRename
				, false));
		}

		/// <exception cref="System.Exception"/>
		[NUnit.Framework.Test]
		public virtual void TestContractResourceOnClasspath()
		{
			Uri url = this.GetType().GetClassLoader().GetResource(LocalFSContract.ContractXml
				);
			NUnit.Framework.Assert.IsNotNull("could not find contract resource", url);
		}
	}
}
