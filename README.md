# MusicManager
A bot created in C# and with the use of Bot Framework and LUIS AI from Microsoft that can store tracks, albums and artists based on the commands given by the user.
You can also get back the list of all the tracks associated with an album or artist. (Some functionality already added, some being added at the moment...)

This project is made in Visual Studio 2017 and you can use git commands to clone this or just download and import it in Visual Studio as a project. In addition to having Visual Studio
on your machine, you also need to have the bot framework emulator that you can download from the Microsoft website.

The solution has two projects -

1. ConsoleApp1 - Involves basic skeleton code which does all the actual work - adding and getting of tracks/albums/artists.
2. MusicBot - This project connects the whole program with LUIS AI and uses the commands to get the intent.

More functionality being added as you read this...

Now everything in detail!

# Requirements
1. Visual Studio 2017
2. Bot Application, Bot Controller, and Bot Dialog .zip files. Install the templates by copying the .zip files to your Visual Studio 2017 project templates directory. (follow this link #3 - https://docs.microsoft.com/en-us/bot-framework/dotnet/bot-builder-dotnet-quickstart)
3. Bot Emulator (follow this link - https://emulator.botframework.com/)

# Step-by-step Guide
1. Download this project.
2. Import the project in Visual Studio 2017.
3. Build and run the project with any browser on your system. 
4. Once the program runs successfully, open bot emulator and navigate to http://localhost:3979/api/messages (ignore the User ID and Password fields).
5. Start typing in the commands and follow the bot!
6. If your commands cannot run for some reason, type in 'help' and the bot will return all the commands that it can work with.
