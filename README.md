# Simple DB
## How it works

I have built a very simple database with a Hashmap-based index in C#.

When you launch the program you get a command interface where you can execute a series of commands:

1. help.
2. set.
3. get.

## How to use it

### Prerequisites

You need to have the .NET Core SDK installed on your machine in order to run this project that can be done from [here](https://dotnet.microsoft.com/download).

If you are using Windows it is recommended to run the program with the [Git Bash](https://git-scm.com/downloads) terminal or any other Linux-based terminal.

### Windows/Linux/Mac

1. Clone this repository in a location of your choice:

   ```````bash
   $ git clone https://github.com/kagejohn/db_assignment_01.git
   ```````

2. CD into the project folder:

   ```bash
   $ cd db_assignment_01/Assignment_1_DB/
   ```

3. Build the project:

   ```bash
   $ dotnet build
   ```

4. CD into the program folder:

   ```bash
   $ cd Assignment_1_DB/bin/Debug/netcoreapp2.1
   ```
   
5. Run the program:

   ```bash
   $ dotnet Assignment_1_DB.dll
   ```

6. Insert a value with a key in the database using the "set" command and its values the first parameter after the command is the key the second is the value:

   ```bash
   $ set 1 test
   ```
   It is also possible to update a given value after it has been stored simply run the "set"  command again on a stored key but with a new value.

7. Retrieve the value of the key you have just inserted in the database by using the "get" command:

   ``` bash
   $ get 1
   ```
