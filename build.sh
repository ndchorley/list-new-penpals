#!/bin/bash

set -e

dotnet clean && dotnet test && dotnet publish

