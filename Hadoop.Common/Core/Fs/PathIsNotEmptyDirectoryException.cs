using Sharpen;

namespace Org.Apache.Hadoop.FS
{
	/// <summary>Generated by rm commands</summary>
	[System.Serializable]
	public class PathIsNotEmptyDirectoryException : PathExistsException
	{
		/// <param name="path">for the exception</param>
		public PathIsNotEmptyDirectoryException(string path)
			: base(path, "Directory is not empty")
		{
		}
	}
}
