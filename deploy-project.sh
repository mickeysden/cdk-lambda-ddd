#!/bin/bash
cd src && dotnet test CdkLambdaApp.sln && dotnet build --no-dependencies -c Release && cd ../

cdk deploy --profile jsree-dev