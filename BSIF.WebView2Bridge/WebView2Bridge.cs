namespace BSIF.WebView2Bridge;

using System.Runtime.InteropServices;
using Python.Runtime;
using Microsoft.VisualBasic;

[ClassInterface(ClassInterfaceType.AutoDual)]
[ComVisible(true)]
public class WebView2Bridge(PyObject pythonApi)
{
	private readonly PyObject pythonApi = pythonApi;

	public dynamic Call(string methodName, object[] args)
	{
		PyObject result = pythonApi.InvokeMethod(methodName, args.Select(item => item.ToPython()).ToArray());
		return result;
	}

	public string TestJsType(object? any)
	{
		
		Type type = Type.GetTypeFromHandle(Type.GetTypeHandle(any));
		inspect = any;
		return type.IsCOMObject ? "COM Object" : type.Name;
	}

	public object? inspect = null;
}