/*
* Licensed to the Apache Software Foundation (ASF) under one
* or more contributor license agreements.  See the NOTICE file
* distributed with this work for additional information
* regarding copyright ownership.  The ASF licenses this file
* to you under the Apache License, Version 2.0 (the
* "License"); you may not use this file except in compliance
* with the License.  You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/
using NUnit.Framework;
using Org.Apache.Hadoop.Conf;
using Sharpen;

namespace Org.Apache.Hadoop.FS.Contract.Rawlocal
{
	public class TestRawLocalContractUnderlyingFileBehavior : Assert
	{
		private static FilePath testDirectory;

		[BeforeClass]
		public static void Before()
		{
			RawlocalFSContract contract = new RawlocalFSContract(new Configuration());
			testDirectory = contract.GetTestDirectory();
			testDirectory.Mkdirs();
			NUnit.Framework.Assert.IsTrue(testDirectory.IsDirectory());
		}

		/// <exception cref="System.Exception"/>
		[NUnit.Framework.Test]
		public virtual void TestDeleteEmptyPath()
		{
			FilePath nonexistent = new FilePath(testDirectory, "testDeleteEmptyPath");
			NUnit.Framework.Assert.IsFalse(nonexistent.Exists());
			NUnit.Framework.Assert.IsFalse("nonexistent.delete() returned true", nonexistent.
				Delete());
		}
	}
}
