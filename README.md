# Winux

**Winux** is a modular Windows CLI tool that brings Linux-like commands to Windows 11 using C# (.NET 8).  

## Features

- Modular architecture: each command implements a common `iCommand` interface
- Basic Linux commands: `whoami`, `cat`, `touch`, `mkdir`, `ls`, `rm`, `cp`, `mv`, `pwd`, `echo`, `clear`
- Aliases for all commands (e.g., `dir` for `ls`, `del` for `rm`, `cls` for `clear`)
- Command flags and colorized output (`ls -l`, `rm -r`, `cp -f`, `mv -f`)
- Easy to extend with new commands

## Project Structure
```
commands/
cat.cs
mkdir.cs
touch.cs
whoami.cs
ls.cs
rm.cs
cp.cs
mv.cs
pwd.cs
echo.cs
clear.cs
core/
commandDispatcher.cs
iCommand.cs
Program.cs
winux.csproj
```

## Getting Started

### Run commands with dotnet

```bash
dotnet run -- whoami
dotnet run -- ls -l
dotnet run -- touch file.txt
dotnet run -- mkdir myfolder
