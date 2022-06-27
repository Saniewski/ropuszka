#!/bin/bash

dotnet publish ../../src/Ropuszka.Migration.sln -c release -r osx.12-arm64 --self-contained -o ../../build/osx.12-arm64

exit 0

