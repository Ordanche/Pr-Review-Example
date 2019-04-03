"./bin/SonarScanner.MSBuild.exe" begin /k:"Ordanche_Pr-Review-Example" /d:sonar.organization="ordanche-github" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="5a60c1f920227b60940537fb21c530e1542c7b42"
"MsBuild.exe" ../Demo.sln /t:Rebuild
"./bin/SonarScanner.MSBuild.exe" end /d:sonar.login="5a60c1f920227b60940537fb21c530e1542c7b42"