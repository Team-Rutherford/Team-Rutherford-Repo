# Runs every time a package is installed in a project

param($installPath, $toolsPath, $package, $project)

Add-EFDefaultConnectionFactory $project 'Oracle.DataAccess.RdbEntity.RdbConnectionFactory, Oracle.DataAccess.Rdb, Version=7.3.2.1, Culture=neutral, PublicKeyToken=24caf6849861f483' -ConstructorArguments 'Oracle.DataAccess.RdbClient'
Add-EFProvider $project 'Oracle.DataAccess.RdbClient' 'Oracle.DataAccess.RdbClient.RdbProviderServices, Oracle.DataAccess.Rdb, Version=7.3.2.1, Culture=neutral, PublicKeyToken=24caf6849861f483'
