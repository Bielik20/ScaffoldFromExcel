# Scaffold from Excel
It is simple application for "scaffolding" chunks of code from excel. It was originally created as EnumsFormExcel (https://github.com/Bielik20/EnumsFromExcel/) but I decided to make it more flexible and crossplatform using .net core.

## Prerequisites
Only thing needed is EPPlus.Core. You can read about it here:
https://github.com/VahidN/EPPlus.Core

## Sample Files
I suggest trying to use sample files and find out what application does. Just drop the content of _SampleFiles folder (I trust you will find it) to Debug directory (one where main exe resides) and run application, after console prints "Scaffolding completed." you can inspect files located in Output folders. For additional information look below.

## Input
Program takes excel file to construct list of models. Every column is another model where Model consists of:
- string Title (first row)
- List<string> Items (all other rows)

Title is mandatory while items are not. Input file should be an excel file named "input.xlsx". Program supports multiple sheets.

## Syntax
I have introduced simple syntax for creating base files:
- FILL_TITLE - will be replaced by exact content of title cell.
- FILL_FTITLE - will be replaced by formated* version of title.
- START_LIST - entire line will be deleted. Used to indicate start of iteratiion through items.
- END_LIST - entire line will be deleted. Used to indicate end of iteratiion through items.
- FILL_ITEM - will be replaced by exact content of respective item cell. Works only inside START_LIST and END_LIST.
- FILL_FITEM - will be replaced by formated* version of respective item cell. Works only inside START_LIST and END_LIST.

START_LIST and END_LIST is essentially foreach loop. Program supports multiple loops but not nested ones.
*formated version - deletes ‘wierd’ characters leaving only letters, numbers and underscores. Additionally text is changed to TitleCase.

## Base ...
Base is essentially template for your code. You can construct them using syntax I described earlier. There are two folders where you put templates. Choice doesn’t affect how templates are interpreted, only format of output. Output file always share extension with its Base.

### Base Files
Every Model will be scaffolded into separate file (hence the name). Name of the output file will be:
> (formated version of title) + (name of BaseFile)

### Base Lines
Every Model will be scaffolded into separate lines (hence the name). Name of the output file will be:
> (name of BaseFile)

## License
Source code is released under the MIT license.

The MIT License (MIT)
Copyright (c) 2017 Bielik20

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
