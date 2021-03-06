using Org.Apache.Hadoop.Security;


namespace Org.Apache.Hadoop.Ipc
{
	/// <summary>
	/// Interface which allows extracting information necessary to
	/// create schedulable identity strings.
	/// </summary>
	public interface Schedulable
	{
		UserGroupInformation GetUserGroupInformation();
	}
}
