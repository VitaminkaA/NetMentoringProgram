start "" C:\Users\Tatsiana_Panasiuk\Desktop\DotNetMentoringProgram\Module8\Task\LogParser.ConsoleApp\bin\Debug\netcoreapp3.1\LogParser.ConsoleApp.exe "SELECT Type as LogType, COUNT(1) as Count USING TRIM(SUBSTR(Text, 25, 5)) as Type INTO C:\Users\Tatsiana_Panasiuk\Desktop\DotNetMentoringProgram\Module8\Task\MvcMusicStore\Reports\Report-NumberOfRecords.csv FROM C:\Users\Tatsiana_Panasiuk\Desktop\DotNetMentoringProgram\Module8\Task\MvcMusicStore\logs\*.log WHERE Type IN ('INFO'; 'DEBUG'; 'ERROR') GROUP BY Type" 