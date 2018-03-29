#!/usr/bin/env bash -e

appCenterLoginApiToken="2d8b457afe940e6fac55403aab2b19d8f467e661"

uiTestProjectName="DevOpsXF.UITests"
appFileName="com.binwell.DevOpsXF.apk"
locale="ru_RU"

if [ "$APPCENTER_BRANCH" == "master" ];
then
	msbuild $APPCENTER_SOURCE_DIRECTORY/$uiTestProjectName/ /p:Configuration=Release	
	appcenter test run uitest --app $appName --devices "slavachernikoff/smoke" --test-series "smoke" --include-category "Smoke" \
	--app-path $APPCENTER_OUTPUT_DIRECTORY/$appFileName --locale $locale --build-dir $APPCENTER_SOURCE_DIRECTORY/$uiTestProjectName/bin/Release \
	--token $appCenterLoginApiToken 
fi