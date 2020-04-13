# Trivia

## What is Triva?
As the *genius* (and hopefully just a working) title suggests, this is a trivia program written in C# for the .NET Core runtime environment. One of my non-programming friends wanted do a Trivia competition using questions about the people our group. As this will be used by non-programmers, I'm working on a web version so it's easy to use for them.

## How does it work?
The program reads a text (*.txt) file in a specific format.
### Format
```
<Question Type>
<Question>
<Answer 1>
<Answer 2>
...
<New Line>
```
#### General Information.
The type of the question (short answer, multiple choice, true false, fill blank) must be written the way it appears in the parentheses. Each question block must be seperated by a new line or it won't be parsed properly.
#### Question and Answer Specifics
The answers listed below the question are all considered possible answers and when checked are not case senitive except in special instances.
##### True or False Questions
The answer to a true or false question must be written as "true", "t", "false", "f".
##### Multiple Choice Questions
Since multiple choice questions only have one correct answer, the letter of the correct answer must be written below all the questions. The user's input is case insensitive.
### Running
You can put this question file in the application directory or paste the path into the program.

## How do I run it?
You can get the latest binaries from the [releases tab](https://github.com/MechaDragonX/Bheithir/releases). **Windows, Linux, and macOS builds for different types of environments are available.**

## Is it functional?
At the moment it should be... Check the [issues](https://github.com/MechaDragonX/Bheithir/issues) tab for any issues.

## When will this be done?
Well...the terminal version is functional, but I'm working on a web version...so let's say it's *in progress*.
