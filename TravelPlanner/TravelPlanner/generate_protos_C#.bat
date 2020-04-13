setlocal

set TOOLS_PATH=C:\Users\anton\.nuget\packages\grpc.tools\2.23.0\tools\windows_x64
set PROTOS_PATH=Protos
set OUTPUT_PATH=Generated

if not exist %OUTPUT_PATH% mkdir %OUTPUT_PATH%

for /R . %%f in (%PROTOS_PATH%\*.proto) do (
	%TOOLS_PATH%\protoc.exe --proto_path %PROTOS_PATH% --csharp_out %OUTPUT_PATH% %PROTOS_PATH%\%%~nf%%~xf 
	%TOOLS_PATH%\protoc.exe --proto_path %PROTOS_PATH% --grpc_out %OUTPUT_PATH% --plugin=protoc-gen-grpc=%TOOLS_PATH%\grpc_csharp_plugin.exe %PROTOS_PATH%\%%~nf%%~xf
)

endlocal