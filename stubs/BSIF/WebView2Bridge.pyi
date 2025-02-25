from _collections_abc import dict_keys
from typing import Callable, Final, Union
from System import Array, Delegate, _inbound_array
from System.Threading.Tasks import Task, TaskCompletionSource

class WebView2Bridge:
	class SyncCaller(Delegate[str, str, str]): ...
	class AsyncCaller(Delegate[None, str, str, TaskCompletionSource[str]]): ...
	def __init__(self, sync_caller: SyncCaller, async_caller: AsyncCaller, method_names: Union[_inbound_array[str], dict_keys[str, Callable]]):
		self.MethodNames: Final[Array[str]]
	def SyncCall(self, method_name: str, args_json: str) -> str:...
	def AsyncCall(self, method_name: str, args_json: str) -> Task[str]:...