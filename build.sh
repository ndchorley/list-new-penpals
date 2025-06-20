#!/bin/bash

set -e

dotnet clean && dotnet test && dotnet build --configuration Release
