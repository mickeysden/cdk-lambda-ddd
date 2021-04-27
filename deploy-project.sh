#!/bin/bash
cd lambdas/CdkLambdaApp.FunctionOne/test/CdkLambdaApp.FunctionOne.Tests && dotnet build && dotnet test &&
    cd ../../src/CdkLambdaApp.FunctionOne && dotnet build -c Release &&
    cd ../../../../

cdk deploy --profile jsree-dev