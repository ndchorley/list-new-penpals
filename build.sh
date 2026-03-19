#!/bin/bash

set -e

dotnet clean -c Release && dotnet test -c Release
