namespace BSIF.WebView2Bridge;

using System.Runtime.InteropServices;
using System.Collections.ObjectModel;

[ClassInterface(ClassInterfaceType.AutoDual)]
[ComVisible(true)]
public class WebView2Bridge(WebView2Bridge.Caller pythonCaller, string[] methodsName)
{
	public delegate string Caller(string methodName, string argsJson);
	private readonly Caller caller = pythonCaller;
	public readonly ReadOnlyCollection<string>? methodsName = new(methodsName);
	public string Call(string methodName, string argsJson)
	{
		return caller.Invoke(methodName, argsJson);
	}
}