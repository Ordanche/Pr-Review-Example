"./bin/SonarScanner.MSBuild.exe" begin /k:"Ordanche_Pr-Review-Example" /o:"ordanche-github" /d:sonar.host.url=https://sonarcloud.io /d:sonar.scm.provider=git /d:sonar.login=XXXX
"MsBuild.exe" ../Demo.sln /t:Rebuild
"./bin/SonarScanner.MSBuild.exe" end /d:sonar.login=XXXX