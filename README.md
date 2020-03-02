Example apps for .NET memory dump analysis
===============
Exercises for practising .NET memory dump analysis.

Copyright (c) 2020 Davis Mosenkovs

## Usage

Compile the examples using Visual Studio, run them, take memory dumps and try to diagnose the problems. It should be possible to base most troubleshooting decisions on the information in memory dumps. Try to look only into methods referred in memory dumps (and related methods).

In many cases it would be much easier to diagnose these problems by analysing source code, however **that would defeat the purpose** of these exercises (and in real-life situations there might be similar problems hidden in projects having many thousands of code lines).

Most examples are working really slow, some are also consuming CPU a lot.

Each example has a file called `solution.txt` with troubleshooting steps and solution. In these files there are 20 empty lines between steps (allowing to hide next steps outside properly sized editor window).

## Details on the exercises

#### Example1

This is the most simple example.

#### Example2

:warning: This example has no simple fix (algorithm used here is incomprehensible and makes no sense). It is important to understand what, where and why is happening.

#### Example3

:warning: This example has no simple fix (algorithm used here is incomprehensible and makes no sense). It is important to understand what, where and why is happening.

:warning: This might be the hardest example.

This is the "scapegoat method" example. Taking at least two memory dumps a few seconds apart is recommended.

:information_source: Usage of [WinDbg](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugger-download-tools) might be needed.

#### Example4

This example might (unintentionally) work properly on some systems/under some circumstances.
Please wait until message `15 seconds elapsed since all threads have been started.` is displayed before taking the memory dump. If computer gets slowed down too much decrease priority of `Example4.exe` using Task Manager.

#### Example5

This is a memory leak example.

After fixing the memory leak it can be used to examine garbage collection in action.

:information_source: Usage of [PerfView](https://github.com/microsoft/perfview) might be needed.
