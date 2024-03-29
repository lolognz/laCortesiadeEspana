using System;
using System.IO;

public class LocalStorage : Storage
{

	private string tracesPathPrefix;
	private string tracesFile;
		
	public LocalStorage (string tracesPathPrefix)
	{
		this.tracesPathPrefix = tracesPathPrefix;
	}
				
	public void SetTracker (Tracker tracker)
	{
	}
		
	public void Start (Net.IRequestListener startListener)
	{
		string now = System.DateTime.Now.ToString ().Replace('/', '_').Replace(':', '_');
		tracesFile = tracesPathPrefix + now + ".csv";
		Write ("session," + now + "\n", startListener);
	}

	public void Send (String data, Net.IRequestListener flushListener)
	{
		Write (data, flushListener);
	}

	private void Write (String data, Net.IRequestListener requestListener)
	{
		try {
			File.AppendAllText (tracesFile, data);
			requestListener.Result ("");
		} catch (Exception e) {
			requestListener.Error (e.Message);
		}	
	}

}


